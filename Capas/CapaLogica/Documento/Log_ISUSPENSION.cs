using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using CDatos = CapaDatos.DOC.Dat_ISUSPENSION;
using CEntidad = CapaEntidad.DOC.Ent_ISUSPENSION;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_ISUSPENSION
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CEntidad RegMostCombo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCampoEntrada);
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
        public CEntidad RegMostrarListaItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItem(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidarDatos(VM_InformeSuspension _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            //txtIdOficina
            //if (string.IsNullOrEmpty(_dto.txtFechaEmision)) throw new Exception("Seleccione la fecha de emisión");
            //if (_dto.tbSupervisor.Count == 0) throw new Exception("Ingrese profesional");
            if (_dto.txtFechaEmision == null) throw new Exception("Ingrese fecha de emisión");
            if (_dto.txtFechaActa == null) throw new Exception("Ingrese fecha de acta");
            if (_dto.txtNumInforme == null) throw new Exception("Ingrese número de informe");

            if (_dto.txtIdMotivo == "0000000") throw new Exception("Seleccione motivo de suspensión");
            if (_dto.txtIDOD == "0000000") throw new Exception("Seleccione Oficina Desconsentrada");
        }

        public ListResult GuardarDatos(VM_InformeSuspension _dto, string codCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                this.ValidarDatos(_dto);
                CEntidad oCEntidadInforme = new CEntidad();

                oCEntidadInforme.COD_INFORME = _dto.hdfCodInforme;
                oCEntidadInforme.NUM_THABILITANTE = null;
                oCEntidadInforme.NUM_POA = -1;
                oCEntidadInforme.CNOTIFICACION = null;
                oCEntidadInforme.COD_IMOTIVO = _dto.txtIdMotivo;
                oCEntidadInforme.FECHA_EMISION_DIRECCION = Convert.ToDateTime(_dto.txtFechaEmision);
                oCEntidadInforme.COD_UCUENTA = codCuenta;
                oCEntidadInforme.OBSERVACION = _dto.txtObservacion;
                oCEntidadInforme.COD_OD_REGISTRO = _dto.txtIDOD;
                //Variables de control de calidad
                oCEntidadInforme.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                oCEntidadInforme.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                oCEntidadInforme.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;
                oCEntidadInforme.FECHA_ACTA = Convert.ToDateTime(_dto.txtFechaActa);
                oCEntidadInforme.PUBLICAR = _dto.chkPublicar;
                oCEntidadInforme.COD_ITIPO = "0000002";
                oCEntidadInforme.COD_REQUE = 0;
                oCEntidadInforme.NUMERO = _dto.txtNumInforme;
                oCEntidadInforme.RegEstado = _dto.hdfRegEstado;
                oCEntidadInforme.OUTPUTPARAM01 = "";
                oCEntidadInforme.COD_THABILITANTE = _dto.hdfCodThabilitante;
                oCEntidadInforme.COD_CNOTIFICACION = _dto.hdfCodNotificacion;
                oCEntidadInforme.ListEliTABLA = _dto.tbEliTABLA;
                oCEntidadInforme.ListInformeDetSupervisor = _dto.tbSupervisor;

                var estado_final = this.ReglInsertarInforme(oCEntidadInforme);
                result.AddResultado("Informe de Suspensión se Guardo Correctamente", true);

            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String ReglInsertarInforme(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertar(cn, oCampoEntrada);
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
        //public List<CEntidad> Reg_Requere(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrar_Requerimiento(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #region MVC
        public VM_InformeSuspension InitDatosInforme(string asCodInforme, string asCodCNotificacion, string asCodUCuenta)
        {
            VM_InformeSuspension vmInf = new VM_InformeSuspension();

            try
            {
                vmInf.lblTituloCabecera = "Informe de Suspensión";

                CEntidad comInf = new CEntidad();
                comInf.BusFormulario = "INFORME_SUSPENSION";
                comInf.BusCriterio = "ISUPERVISION_GENERAL";
                comInf.COD_UCUENTA = asCodUCuenta;
                comInf = RegMostCombo(comInf);

                vmInf.ListOD = comInf.ListODs;
                vmInf.ListMotivo = comInf.ListISupervision_Motivo;

                if (String.IsNullOrEmpty(asCodInforme))
                {
                    CapaEntidad.DOC.Ent_CNOTIFICACION entCN = new CapaEntidad.DOC.Ent_CNOTIFICACION();
                    Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();
                    entCN = exeCN.RegMostCNotificacion_Consulta(
                        new CapaEntidad.DOC.Ent_CNOTIFICACION()
                        {
                            BusFormulario = "DATA_CNOTIFICACION",
                            BusCriterio = "CN_CODCN_ISUPERVISION",
                            BusValor = asCodCNotificacion
                        }).FirstOrDefault();

                    vmInf.lblTituloEstado = "Nuevo Registro";
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUMERO;
                    vmInf.vmInfCNotificacion.txtTHabilitante = entCN.NUM_THABILITANTE;

                    vmInf.vmControlCalidad = new VM_ControlCalidad_2();
                    vmInf.vmControlCalidad.ddlIndicadorId = "0000000";
                    vmInf.hdfCodNotificacion = entCN.COD_CNOTIFICACION;
                    vmInf.hdfCodThabilitante = entCN.COD_THABILITANTE;
                    vmInf.txtTHabilitante = entCN.NUM_THABILITANTE;
                    vmInf.txtCNotificacion = entCN.NUMERO;



                    vmInf.hdfRegEstado = 1;

                }
                else
                {
                    //Obtener datos del informe

                    CEntidad entInf = new CEntidad();
                    entInf.COD_INFORME = asCodInforme;
                    entInf = RegMostrarListaItem(entInf);

                    //vmInf.hdfCodInforme = asCodInforme;
                    vmInf.lblTituloEstado = "Modificando Registro";
                    vmInf.vmControlCalidad.ddlIndicadorId = entInf.COD_ESTADO_DOC;
                    vmInf.vmControlCalidad.chkObsSubsanada = (bool)entInf.OBSERV_SUBSANAR;
                    vmInf.vmControlCalidad.txtControlCalidadObservaciones = entInf.OBSERVACIONES_CONTROL.ToString();
                    vmInf.vmControlCalidad.txtUsuarioControl = entInf.USUARIO_CONTROL;
                    vmInf.vmControlCalidad.txtUsuarioRegistro = entInf.USUARIO_REGISTRO;

                    CapaEntidad.DOC.Ent_CNOTIFICACION entCN = new CapaEntidad.DOC.Ent_CNOTIFICACION();
                    Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();
                    entCN = exeCN.RegMostCNotificacion_Consulta(
                       new CapaEntidad.DOC.Ent_CNOTIFICACION()
                       {
                           BusFormulario = "DATA_CNOTIFICACION",
                           BusCriterio = "CN_CODCN_ISUPERVISION",
                           BusValor = entInf.COD_CNOTIFICACION
                       }).FirstOrDefault();

                    vmInf.hdfCodNotificacion = entCN.COD_CNOTIFICACION;
                    vmInf.hdfCodThabilitante = entCN.COD_THABILITANTE;
                    vmInf.txtTHabilitante = entCN.NUM_THABILITANTE;
                    vmInf.txtCNotificacion = entCN.NUMERO;

                    vmInf.hdfRegEstado = 0;
                    vmInf.hdfCodInforme = asCodInforme; //entInf.COD_INFORME;
                    vmInf.txtNumInforme = entInf.NUMERO;

                    vmInf.txtIdMotivo = entInf.COD_IMOTIVO;
                    vmInf.txtFechaEmision = entInf.FECHA_EMISION_DIRECCION.ToString();
                    vmInf.txtFechaActa = entInf.FECHA_ACTA.ToString();
                    vmInf.txtObservacion = entInf.OBSERVACION;
                    vmInf.txtIDOD = entInf.COD_OD_REGISTRO;
                    vmInf.chkPublicar = (bool)entInf.PUBLICAR;
                    vmInf.tbSupervisor = entInf.ListInformeDetSupervisor;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmInf;
        }
        public List<Dictionary<string, string>> registroUsuarioIS(CEntidad oCEntidad)
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
        public ListResult RegistroUsuario(string asCodUsuario)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                //CLogica exeCap = new CLogica();
                paramCap.BusFormulario = "REGISTRO_USUARIO";
                paramCap.BusCriterio = "INFORME_SUSPENSION";
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = registroUsuarioIS(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "ISUSPEN_REG.xlsx";

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
                                insertar = insertar + ",'" + (itemPart["FECHA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ANIO_REGISTRO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["MES_REGISTRO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["CNOTIFICACION"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["MODALIDAD_TIPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["THABILITANTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["SUPERVISION"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["USUARIO"] ?? "") + "'";
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
        #endregion

    }
}
