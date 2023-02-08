using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_SUPERVISION_GENERAL;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_SUPERVISION_GENERAL;
using Oracle.ManagedDataAccess.Client;
using CapaEntidad.ViewModel;
using System.IO;
using System.Data.OleDb;
using System.Web;
using System.Data;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_SUPERVISION_GENERAL
    {

        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarSUPERVISION_det(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarSUPERVISION_anio(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //mostrar supervision general por linea LogInformeSupervisionLinea
        //public List<CEntidad> MostrarSupervision_General(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarSupervision_General(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<CEntidad> LogInformeSupervisionLinea(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatInformeSupervisionLinea(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //mostrar suspensiones generales por linea
        public List<CEntidad> LogInformeSuspensionLinea(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatInformeSuspensionLinea(cn, oCampoEntrada);
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
        //public CEntidad log_RegMostrarSUPERVISOR_SUPER(CEntidad oCampoEntrada)
        //{
        //	try
        //	{
        //		using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //		{
        //			cn.Open();
        //			return oCDatos.RegMostrarSUPERVISOR_SUPERVISION(cn, oCampoEntrada);
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}

        public CEntidad RegMostrarListSupervisionXsupervisorResumen(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    oCampoEntrada.TIPO_REPORTE = "RESUMEN";
                    cn.Open();
                    return oCDatos.RegMostrarListSupervisionXsupervisorResumen(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> RegMostrarListSupervisionXsupervisorDetalle(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    oCampoEntrada.TIPO_REPORTE = "DETALLE";
                    cn.Open();
                    return oCDatos.RegMostrarListSupervisionXsupervisorDetalle(cn, oCampoEntrada);
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
        public CEntidad log_RegMostrarActividadSil(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarACTIVIDAD_SIL(cn, oCampoEntrada);
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
        public CEntidad log_RegMostrarProgramadoSuper(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarPROGRAMADO_SUPER(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegMostrarSupervision_AnioDetalle(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarSupervisionXAnio(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<CEntidad> RegMostrarSupervision_ModalidadDetalle(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarSupervisionXModalidad(cn, oCampoEntrada);
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
        //public CEntidad MostrarSupervision_Detalle(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarSupervision_Detalle(cn, oCampoEntrada);
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
        public CEntidad Mostrar_Historial_Supervisor(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarHistorial(cn, oCampoEntrada);
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
        //public CEntidad RegMostComboNoFauna()
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostComboNoFauna(cn);
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
        public List<CEntidad> LogGeneralZafraSupervisado(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatMostrarZafraSupervisado(cn, oCampoEntrada);
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
        public List<CEntidad> LogDetalleZafraSupervisado(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatDetalleZafraSupervisado(cn, oCampoEntrada);
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
        public List<CEntidad> LogArbolesAdicionales(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatArbolesAdicionales(cn, oCampoEntrada);
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
        public List<CEntidad> LogDetArbolesAdicionalesTitulares(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatDetArbolesAdicionalesTitulares(cn, oCampoEntrada);
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
        public List<CEntidad> Log_MostrarCategoriaDiametrica(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_MostrarCategoriaDiametrica(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> Log_SupervisionTotal(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatSupTotal(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> Log_SupervisionTotalAnio(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatSupTotalAnio(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> Log_SupervisionArboles(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.dat_SupervisionArboles(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> Log_SupervisionArbolesAnio(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.dat_SupervisionArboleAnio(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> Log_ResumenTH(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.dat_ResumenTH(cn, oCampoEntrada);
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
        public List<CEntidad> LogTitulares(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatTitulares(cn, oCampoEntrada);
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
        public CEntidad LogPOasTituloHabilitante(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatPoasTHabilitante(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo que obtiene la lista de arboles supervisados la busqueda se hace por región 
        /// fecha de modificacion 28/08/2017
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> LogReporteArbolesSupervisados(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatReporte_Supervision_Arboles(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad LogReportDispObligaciones(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatReporte_DispObligaciones(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ListResult DescargaResumen(List<CEntidad> listSupModResumen)
        {
            ListResult result = new ListResult();
            try
            {
                int i = 1;
                String insertar = "";
                String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                //Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";
                nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = RutaReporteSeguimiento + nombreFile;
                File.Copy(RutaReporteSeguimiento + "Report_SupervisionesXsupervisorResumen.xlsx", rutaExcel);
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
                        int contador = 1;
                        foreach (var listaInf in listSupModResumen)
                        {
                            insertar = contador++.ToString();

                            insertar = insertar + ",'" + listaInf.SUPERVISOR.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_ZOOL.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_ZOOC.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_CRES.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_CCT.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_TARA.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_BS.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_CMADE.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_NMCAST.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_NMSHIR.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_FYR.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_ECO.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_CONS.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_CFAUNA.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_PP.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_CCNN.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_CCCC.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_BL.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_NMAGU.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.CANT_SISAG.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.TOTALDOUBLE.ToString() + "'";

                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listSupModResumen.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                            cmd.ExecuteNonQuery();
                        }

                        //Cerramos la conexión
                        conn.Close();
                    }
                }

                result.success = true;
                result.msj = nombreFile;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }

        public ListResult DescargaDetalle(List<CEntidad> listSupModResumen)
        {
            ListResult result = new ListResult();

            try
            {
                int i = 1;
                String insertar = "";
                String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";
                nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = RutaReporteSeguimiento + nombreFile;
                File.Copy(RutaReporteSeguimiento + "Report_SupervisionesXsupervisorDetalle.xlsx", rutaExcel);
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
                        int contador = 1;
                        foreach (var listaInf in listSupModResumen)
                        {
                            insertar = contador++.ToString();

                            insertar = insertar + ",'" + listaInf.NUM_THABILITANTE.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.TITULAR.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.MODALIDAD.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.DEPARTAMENTO.ToString() + "'";
                            insertar = insertar + ",'" + (listaInf.SUPERVISOR.Length > 255 ? listaInf.SUPERVISOR.ToString().Substring(0, 255) : listaInf.SUPERVISOR.ToString()) + "'";
                            insertar = insertar + ",'" + listaInf.FECHA_INICIO.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.FECHA_FIN.ToString() + "'";

                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listSupModResumen.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                            cmd.ExecuteNonQuery();
                        }

                        //Cerramos la conexión
                        conn.Close();
                    }
                }
                result.success = true;
                result.msj = nombreFile;
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
