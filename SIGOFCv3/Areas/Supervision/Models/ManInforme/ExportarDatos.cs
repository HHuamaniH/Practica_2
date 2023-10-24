using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using CEntidad = CapaEntidad.DOC.Ent_INFORME;
using CLogica = CapaLogica.DOC.Log_INFORME;

using CapaLogica.DOC;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SIGOFCv3.Helper;
using System.Drawing;

namespace SIGOFCv3.Areas.Supervision.Models.ManInforme
{
    public class ExportarDatos
    {
        /// <summary>
        /// Exportar registro de cartas de notificación
        /// </summary>
        /// <param name="asCodUsuario"></param>
        /// <returns></returns>
        public static ListResult RegistroUsuario(string asCodUsuario)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                CLogica exeCap = new CLogica();
                paramCap.TIPO_REPORTE = "REGISTRO_USUARIO_ISUPERVISION";
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = exeCap.ReportesInforme(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "ISUPERVISION_Reg_Usu.xlsx";

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
                                insertar = insertar + ",'" + (itemPart["MODALIDAD_TIPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUM_THABILITANTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["TITULAR"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["APELLIDOS_NOMBRES"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["POA"] ?? "") + "'";
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

        public static ListResult RegistroUsuarioQuinquenal(string asCodUsuario)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                CLogica exeCap = new CLogica();
                paramCap.TIPO_REPORTE = "REGISTRO_USUARIO_IQUINQUENAL";
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = exeCap.ReportesInforme(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "ISUPERVISIONQ_Reg_Usu.xlsx";

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
                                insertar = insertar + ",'" + (itemPart["MODALIDAD_TIPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUM_THABILITANTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["TITULAR"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["RD_QUINQUENAL"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["TIPO"] ?? "") + "'";
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

        public static ListResult VerticeTHCampo(string asCodInforme, string asCodCNotificacion)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                CLogica exeCap = new CLogica();
                paramCap.TIPO_REPORTE = "VERTICE_THABILITANTE";
                paramCap.COD_INFORME = asCodInforme;
                paramCap.COD_CNOTIFICACION = asCodCNotificacion;

                List<Dictionary<string, string>> olResult = exeCap.ReportesInforme(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "THabilitanteVerticeCampo.xlsx";

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
                        int i = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var itemPart in olResult)
                            {
                                insertar = "";
                                insertar = insertar + "'" + (itemPart["COD_SISTEMA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["VERTICE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["VERTICE_CAMPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ZONA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ZONA_CAMPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["COORDENADA_ESTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["COORDENADA_ESTE_CAMPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["COORDENADA_NORTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["COORDENADA_NORTE_CAMPO"] ?? "") + "'";
                                insertar = insertar + ",'" + ((itemPart["OBSERVACION_CAMPO"] ?? "").Length > 254 ? itemPart["OBSERVACION_CAMPO"].Substring(0, 254) : itemPart["OBSERVACION_CAMPO"]) + "'";
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

        public static ListResult CoberturaBoscosa(string asCodInforme, string asCodCNotificacion)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                CLogica exeCap = new CLogica();
                paramCap.TIPO_REPORTE = "COBERTURA_BOSCOSA";
                paramCap.COD_INFORME = asCodInforme;
                paramCap.COD_CNOTIFICACION = asCodCNotificacion;

                List<Dictionary<string, string>> olResult = exeCap.ReportesInforme(paramCap);

                //if (olResult.Count > 0)
                //{
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "CoberturaBoscosa.xlsx";

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

                    //using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
                    //{
                    //    string insertar = "";
                    //    int i = 1;
                    //    //Abrimos la conexión
                    //    conn.Open();
                    //    //Creamos la ficha
                    //    using (OleDbCommand cmd = conn.CreateCommand())
                    //    {
                    //        cmd.CommandType = CommandType.Text;
                    //        //Construyendo las Cabeceras
                    //        foreach (var itemPart in olResult)
                    //        {
                    //            insertar = "";
                    //            insertar = insertar + "'" + (itemPart["ACTIVIDAD"] ?? "") + "'";
                    //            insertar = insertar + ",'" + (itemPart["AREA"] ?? "") + "'";                                
                    //            insertar = insertar + ",'" + (itemPart["ZONA"] ?? "") + "'";
                    //            insertar = insertar + ",'" + (itemPart["AUTORIZADO"] ?? "") + "'";
                    //            insertar = insertar + ",'" + (itemPart["COORDENADA_ESTE"] ?? "") + "'";
                    //            insertar = insertar + ",'" + (itemPart["COORDENADA_NORTE"] ?? "") + "'";
                    //            insertar = insertar + ",'" + ((itemPart["OBSERVACION"] ?? "").Length > 254 ? itemPart["OBSERVACION"].Substring(0, 254) : itemPart["OBSERVACION"]) + "'";
                    //            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (olResult.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                    //            cmd.ExecuteNonQuery();
                    //        }
                    //        //Cerramos la conexión
                    //        conn.Close();
                    //    }
                    //}

                    result.success = true;
                    result.msj = nombreFile;
                //}
                //else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        } 
        
        public static ListResult OtrosPuntosEval(string asCodInforme, string asCodCNotificacion)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                CLogica exeCap = new CLogica();
                paramCap.TIPO_REPORTE = "OTROS_PUNTOS_EVAL";
                paramCap.COD_INFORME = asCodInforme;
                paramCap.COD_CNOTIFICACION = asCodCNotificacion;

                List<Dictionary<string, string>> olResult = exeCap.ReportesInforme(paramCap);

                //if (olResult.Count > 0)
                //{
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "Otros_Puntos_Eval.xlsx";

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

                    //using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
                    //{
                    //    string insertar = "";
                    //    int i = 1;
                    //    //Abrimos la conexión
                    //    conn.Open();
                    //    //Creamos la ficha
                    //    using (OleDbCommand cmd = conn.CreateCommand())
                    //    {
                    //        cmd.CommandType = CommandType.Text;
                    //        //Construyendo las Cabeceras
                    //        foreach (var itemPart in olResult)
                    //        {
                    //            insertar = "";
                    //            insertar = insertar + "'" + (itemPart["EVALUACION"] ?? "") + "'";                                
                    //            insertar = insertar + ",'" + (itemPart["ZONA"] ?? "") + "'";                                
                    //            insertar = insertar + ",'" + (itemPart["COORDENADA_ESTE"] ?? "") + "'";
                    //            insertar = insertar + ",'" + (itemPart["COORDENADA_NORTE"] ?? "") + "'";
                    //            insertar = insertar + ",'" + ((itemPart["DESCRIPCION"] ?? "").Length > 254 ? itemPart["DESCRIPCION"].Substring(0, 254) : itemPart["OBSERVACION"]) + "'";
                    //            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (olResult.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                    //            cmd.ExecuteNonQuery();
                    //        }
                    //        //Cerramos la conexión
                    //        conn.Close();
                    //    }
                    //}

                    result.success = true;
                    result.msj = nombreFile;
               // }
               // else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public static ListResult VerticePOACampo(string asCodInforme, int aiNumPoa)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                CLogica exeCap = new CLogica();
                paramCap.TIPO_REPORTE = "VERTICE_POA";
                paramCap.COD_INFORME = asCodInforme;
                paramCap.NUM_POA = aiNumPoa;

                List<Dictionary<string, string>> olResult = exeCap.ReportesInforme(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "PoaVerticeCampo.xlsx";

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
                        int i = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var itemPart in olResult)
                            {
                                insertar = "";
                                insertar = insertar + "'" + (itemPart["COD_SISTEMA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["VERTICE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["VERTICE_CAMPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ZONA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ZONA_CAMPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["COORDENADA_ESTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["COORDENADA_ESTE_CAMPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["COORDENADA_NORTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["COORDENADA_NORTE_CAMPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["PCA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["PCA_CAMPO"] ?? "") + "'";
                                insertar = insertar + ",'" + ((itemPart["OBSERVACION"] ?? "").Length > 254 ? itemPart["OBSERVACION"].Substring(0, 254) : itemPart["OBSERVACION"]) + "'";
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

        public static ListResult DatosCampoMaderable(string asCodInforme)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica exeInf = new CLogica();
                List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> olEspecie = exeInf.RegMostrarMuestraDatosCampoMade(asCodInforme);
                if ((from p in olEspecie where p.COD_ESPECIES_CAMPO != "" select p).ToList<CapaEntidad.DOC.Ent_INFORME_MADERABLE>().Count() == olEspecie.Count)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "PoaMaderableCenso_Modificar_v2.xlsx";

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
                        int i = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var item in olEspecie)
                            {
                                insertar = "";
                                insertar = "'" + "M" + "|" + item.COD_THABILITANTE + "|" + item.NUM_POA + "|" + item.COD_ESPECIES + "|" + item.COD_SECUENCIAL + "'";
                                insertar = insertar + ",'" + item.POA + "'";
                                insertar = insertar + ",'" + item.BLOQUE + "'";
                                insertar = insertar + ",'" + item.BLOQUE_CAMPO + "'";
                                insertar = insertar + ",'" + item.FAJA + "'";
                                insertar = insertar + ",'" + item.FAJA_CAMPO + "'";
                                insertar = insertar + ",'" + item.CODIGO.ToString() + "'";
                                insertar = insertar + ",'" + item.CODIGO_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.DESC_ESPECIES + "'";
                                if (item.DESC_ESPECIES_CAMPO.Trim().Length <= 1)
                                {
                                    insertar = insertar + ",'" + "" + "'";
                                    insertar = insertar + ",'" + "" + "'";
                                }
                                else
                                {
                                    insertar = insertar + ",'" + item.DESC_ESPECIES_CAMPO.Substring(0, item.DESC_ESPECIES_CAMPO.IndexOf('|')).Trim() + "'";
                                    insertar = insertar + ",'" + item.DESC_ESPECIES_CAMPO.Substring(item.DESC_ESPECIES_CAMPO.IndexOf('|') + 1, item.DESC_ESPECIES_CAMPO.Length - item.DESC_ESPECIES_CAMPO.IndexOf('|') - 1).Trim() + "'";
                                }
                                insertar = insertar + ",'" + item.DESC_COINCIDE_ESPECIES.ToString() + "'";
                                insertar = insertar + ",'" + item.ZONA + "'";
                                insertar = insertar + ",'" + item.ZONA_CAMPO + "'";
                                insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                                insertar = insertar + ",'" + item.COORDENADA_ESTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                                insertar = insertar + ",'" + item.COORDENADA_NORTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.DAP.ToString() + "'";
                                insertar = insertar + ",'" + item.DAP_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.DAP_CAMPO1.ToString() + "'";
                                insertar = insertar + ",'" + item.DAP_CAMPO2.ToString() + "'";
                                insertar = insertar + ",'" + item.MMEDIR_DAP.ToString() + "'";
                                insertar = insertar + ",'" + item.AC.ToString() + "'";
                                insertar = insertar + ",'" + item.AC_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.DESC_EESTADO + "'";
                                insertar = insertar + ",'" + item.DESC_EESTADO_CAMPO + "'";
                                insertar = insertar + ",'" + item.DESC_ECONDICION + "'";
                                insertar = insertar + ",'" + item.DESC_ECONDICION_CAMPO + "'";
                                insertar = insertar + ",'" + item.CANT_SOBRE_ESTIMA_DIAMETRO.ToString() + "'";
                                insertar = insertar + ",'" + item.PORC_SOBRE_ESTIMA_DIAMETRO.ToString() + "'";
                                insertar = insertar + ",'" + item.CANT_SUB_ESTIMA_DIAMETRO.ToString() + "'";
                                insertar = insertar + ",'" + item.PORC_SUB_ESTIMA_DIAMETRO.ToString() + "'";
                                insertar = insertar + ",'" + item.PCA_POA.ToString() + "'";
                                insertar = insertar + ",'" + item.PCA.ToString() + "'";
                                insertar = insertar + ",'" + item.OBSERVACION + "'";
                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AJ" + (olEspecie.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }
                            //Cerramos la conexión
                            conn.Close();
                        }
                    }
                    result.success = true;
                    result.msj = nombreFile;
                }
                else
                {
                    throw new Exception("Primero debe finalizar la carga de Datos de Campo antes de poder descargar el consolidado de la Supervisión");
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }

            return result;
        }
        public static ListResult DatosCampoBosqueSeco(string asCodInforme)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica exeInf = new CLogica();
                List<CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO> olEspecie = exeInf.RegMostrarMuestraDatosCampoBosqueSeco(asCodInforme);
                if ((from p in olEspecie where p.COD_ESPECIES_CAMPO != "" select p).ToList<CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO>().Count() == olEspecie.Count)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "PoaBosqueSecoCenso_Modificar.xlsx";

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
                        int i = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var item in olEspecie)
                            {
                                insertar = "";
                                insertar = "'" + "M" + "|" + item.COD_THABILITANTE + "|" + item.NUM_POA + "|" + item.COD_ESPECIES + "|" + item.COD_SECUENCIAL + "'";
                                insertar = insertar + ",'" + item.DESC_ESPECIES + "'";
                                if (item.DESC_ESPECIES_CAMPO.Trim().Length <= 1)
                                {
                                    insertar = insertar + ",'" + "" + "'";
                                    insertar = insertar + ",'" + "" + "'";
                                }
                                else
                                {
                                    insertar = insertar + ",'" + item.DESC_ESPECIES_CAMPO.Substring(0, item.DESC_ESPECIES_CAMPO.IndexOf('|')).Trim() + "'";
                                    insertar = insertar + ",'" + item.DESC_ESPECIES_CAMPO.Substring(item.DESC_ESPECIES_CAMPO.IndexOf('|') + 1, item.DESC_ESPECIES_CAMPO.Length - item.DESC_ESPECIES_CAMPO.IndexOf('|') - 1).Trim() + "'";
                                }
                                insertar = insertar + ",'" + item.POA + "'";
                                insertar = insertar + ",'" + item.BLOQUE + "'";
                                insertar = insertar + ",'" + item.BLOQUE_CAMPO + "'";
                                insertar = insertar + ",'" + item.FAJA + "'";
                                insertar = insertar + ",'" + item.FAJA_CAMPO + "'";
                                insertar = insertar + ",'" + item.CODIGO + "'";
                                insertar = insertar + ",'" + item.CODIGO_CAMPO + "'";
                                insertar = insertar + ",'" + item.DAP.ToString() + "'";
                                insertar = insertar + ",'" + item.DAP_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.AC.ToString() + "'";
                                insertar = insertar + ",'" + item.AC_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + item.DESC_EESTADO + "'";
                                insertar = insertar + ",'" + item.DESC_EESTADO_CAMPO + "'";
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + item.ZONA + "'";
                                insertar = insertar + ",'" + item.ZONA_CAMPO + "'";
                                insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                                insertar = insertar + ",'" + item.COORDENADA_ESTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                                insertar = insertar + ",'" + item.COORDENADA_NORTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.DESC_ACATEGORIA_CITE + "'";
                                insertar = insertar + ",'" + item.DESC_ACATEGORIA_DS + "'";
                                insertar = insertar + ",'" + item.BS_ALTURA_TOTAL.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_DIAMETRO_RAMA_1.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_DIAMETRO_RAMA_2.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_DIAMETRO_RAMA_3.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_DIAMETRO_RAMA_4.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_DIAMETRO_RAMA_5.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_DIAMETRO_RAMA_6.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_DIAMETRO_RAMA_7.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_LONGITUD_RAMA_1.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_LONGITUD_RAMA_2.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_LONGITUD_RAMA_3.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_LONGITUD_RAMA_4.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_LONGITUD_RAMA_5.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_LONGITUD_RAMA_6.ToString() + "'";
                                insertar = insertar + ",'" + item.BS_LONGITUD_RAMA_7.ToString() + "'";
                                insertar = insertar + ",'" + item.OBSERVACION + "'";
                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AR" + (olEspecie.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }
                            //Cerramos la conexión
                            conn.Close();
                        }
                    }
                    result.success = true;
                    result.msj = nombreFile;
                }
                else
                {
                    throw new Exception("Primero debe finalizar la carga de Datos de Campo antes de poder descargar el consolidado de la Supervisión");
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }

            return result;
        }
        public static ListResult DatosCampoSemillero(string asCodInforme)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica exeInf = new CLogica();
                List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> olEspecie = exeInf.RegMostrarMuestraDatosCampoSemi(asCodInforme);
                if ((from p in olEspecie where p.COD_ESPECIES_CAMPO != "" select p).ToList<CapaEntidad.DOC.Ent_INFORME_SEMILLERO>().Count() == olEspecie.Count)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "PoaMaderableCenso_Modificar_semillero_v2.xlsx";

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
                        int i = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var item in olEspecie)
                            {
                                insertar = "";
                                insertar = "'" + "M" + "|" + item.COD_THABILITANTE + "|" + item.NUM_POA + "|" + item.COD_ESPECIES + "|" + item.COD_SECUENCIAL + "'";
                                insertar = insertar + ",'" + item.POA + "'";
                                insertar = insertar + ",'" + item.BLOQUE + "'";
                                insertar = insertar + ",'" + item.BLOQUE_CAMPO + "'";
                                insertar = insertar + ",'" + item.FAJA + "'";
                                insertar = insertar + ",'" + item.FAJA_CAMPO + "'";
                                insertar = insertar + ",'" + item.CODIGO.ToString() + "'";
                                insertar = insertar + ",'" + item.CODIGO_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.DESC_ESPECIES + "'";
                                if (item.DESC_ESPECIES_CAMPO.Trim().Length <= 1)
                                {
                                    insertar = insertar + ",'" + "" + "'";
                                    insertar = insertar + ",'" + "" + "'";
                                }
                                else
                                {
                                    insertar = insertar + ",'" + item.DESC_ESPECIES_CAMPO.Substring(0, item.DESC_ESPECIES_CAMPO.IndexOf('|')).Trim() + "'";
                                    insertar = insertar + ",'" + item.DESC_ESPECIES_CAMPO.Substring(item.DESC_ESPECIES_CAMPO.IndexOf('|') + 1, item.DESC_ESPECIES_CAMPO.Length - item.DESC_ESPECIES_CAMPO.IndexOf('|') - 1).Trim() + "'";
                                }
                                insertar = insertar + ",'" + item.DESC_COINCIDE_ESPECIES.ToString() + "'";
                                insertar = insertar + ",'" + item.ZONA + "'";
                                insertar = insertar + ",'" + item.ZONA_CAMPO + "'";
                                insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                                insertar = insertar + ",'" + item.COORDENADA_ESTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                                insertar = insertar + ",'" + item.COORDENADA_NORTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.DAP.ToString() + "'";
                                insertar = insertar + ",'" + item.DAP_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.DAP_CAMPO1.ToString() + "'";
                                insertar = insertar + ",'" + item.DAP_CAMPO2.ToString() + "'";
                                insertar = insertar + ",'" + item.MMEDIR_DAP.ToString() + "'";
                                insertar = insertar + ",'" + item.AC.ToString() + "'";
                                insertar = insertar + ",'" + item.AC_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + item.DESC_EESTADO + "'";
                                insertar = insertar + ",'" + item.DESC_EESTADO_CAMPO + "'";
                                insertar = insertar + ",'" + item.PCA_POA + "'";
                                insertar = insertar + ",'" + item.PCA + "'";

                                insertar = insertar + ",'" + item.DESC_EFENOLOGICO + "'";
                                insertar = insertar + ",'" + item.DESC_CFUSTE + "'";
                                insertar = insertar + ",'" + item.DESC_FCOPA + "'";
                                insertar = insertar + ",'" + item.DESC_PCOPA + "'";
                                insertar = insertar + ",'" + item.DESC_ESANITARIO + "'";
                                insertar = insertar + ",'" + item.DESC_ILIANAS + "'";
                                insertar = insertar + ",'" + item.CANT_SOBRE_ESTIMA_DIAMETRO.ToString() + "'";
                                insertar = insertar + ",'" + item.PORC_SOBRE_ESTIMA_DIAMETRO.ToString() + "'";
                                insertar = insertar + ",'" + item.CANT_SUB_ESTIMA_DIAMETRO.ToString() + "'";
                                insertar = insertar + ",'" + item.PORC_SUB_ESTIMA_DIAMETRO.ToString() + "'";
                                insertar = insertar + ",'" + item.OBSERVACION + "'";
                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AN" + (olEspecie.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }
                            //Cerramos la conexión
                            conn.Close();
                        }
                    }
                    result.success = true;
                    result.msj = nombreFile;
                }
                else
                {
                    throw new Exception("Primero debe finalizar la carga de Datos de Campo antes de poder descargar el consolidado de la Supervisión");
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }

            return result;
        }
        public static ListResult DatosCampoNoMaderable(string asCodInforme)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica exeInf = new CLogica();
                List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> olEspecie = exeInf.RegMostrarMuestraDatosCampoNoMade(asCodInforme);
                if ((from p in olEspecie where p.COD_ESPECIES_CAMPO != "" select p).ToList<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE>().Count() == olEspecie.Count)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "DatosCampoNoMaderable.xlsx";

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
                        int i = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var item in olEspecie)
                            {
                                insertar = "";
                                insertar = "'" + "N" + "|" + item.COD_THABILITANTE + "|" + item.NUM_POA + "|" + item.COD_ESPECIES + "|" + item.COD_SECUENCIAL + "'";
                                insertar = insertar + ",'" + item.DESC_ESPECIES + "'";
                                if (item.DESC_ESPECIES_CAMPO.Trim().Length <= 1)
                                {
                                    insertar = insertar + ",'" + "" + "'";
                                    insertar = insertar + ",'" + "" + "'";
                                }
                                else
                                {
                                    insertar = insertar + ",'" + item.DESC_ESPECIES_CAMPO.Substring(0, item.DESC_ESPECIES_CAMPO.IndexOf('|')).Trim() + "'";
                                    insertar = insertar + ",'" + item.DESC_ESPECIES_CAMPO.Substring(item.DESC_ESPECIES_CAMPO.IndexOf('|') + 1, item.DESC_ESPECIES_CAMPO.Length - item.DESC_ESPECIES_CAMPO.IndexOf('|') - 1).Trim() + "'";
                                }
                                insertar = insertar + ",'" + item.POA + "'";
                                insertar = insertar + ",'" + item.NUM_ESTRADA + "'";
                                insertar = insertar + ",'" + item.NUM_ESTRADA_CAMPO + "'";
                                insertar = insertar + ",'" + item.CODIGO + "'";
                                insertar = insertar + ",'" + item.CODIGO_CAMPO + "'";
                                //insertar = insertar + ",'" + item.DIAMETRO.ToString() + "'";
                                //insertar = insertar + ",'" + item.DIAMETRO_CAMPO.ToString() + "'";
                                //insertar = insertar + ",'" + item.ALTURA.ToString() + "'";
                                //insertar = insertar + ",'" + item.ALTURA_CAMPO.ToString() + "'";
                                //insertar = insertar + ",'" + item.PRODUCCION_LATAS.ToString() + "'";
                                //insertar = insertar + ",'" + item.PRODUCCION_LATAS_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + "" + "'";
                                //insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + item.ZONA + "'";
                                insertar = insertar + ",'" + item.ZONA_CAMPO + "'";
                                insertar = insertar + ",'" + item.COORDENADA_ESTE + "'";
                                insertar = insertar + ",'" + item.COORDENADA_ESTE_CAMPO + "'";
                                insertar = insertar + ",'" + item.COORDENADA_NORTE + "'";
                                insertar = insertar + ",'" + item.COORDENADA_NORTE_CAMPO + "'";
                                //insertar = insertar + ",'" + item.NUM_COCOS_ABIERTOS + "'";
                                //insertar = insertar + ",'" + item.NUM_COCOS_CERRADOS + "'";
                                //insertar = insertar + ",'" + item.DESC_CFUSTE + "'";
                                //insertar = insertar + ",'" + item.DESC_PCOPA + "'";
                                //insertar = insertar + ",'" + item.DESC_FCOPA + "'";
                                //insertar = insertar + ",'" + item.DESC_EFENOLOGICO + "'";
                                insertar = insertar + ",'" + item.DESC_EESTADO_CAMPO + "'";
                                insertar = insertar + ",'" + item.DESC_ESANITARIO + "'";
                                insertar = insertar + ",'" + item.DESC_ILIANAS + "'";
                                insertar = insertar + ",'" + item.DESC_ECONDICION_CAMPO + "'";
                                insertar = insertar + ",'" + item.OBSERVACION + "'";
                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":V" + (olEspecie.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }
                            //Cerramos la conexión
                            conn.Close();
                        }
                    }
                    result.success = true;
                    result.msj = nombreFile;
                }
                else
                {
                    throw new Exception("Primero debe finalizar la carga de Datos de Campo antes de poder descargar el consolidado de la Supervisión");
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }

            return result;
        }
        public static ListResult DatosTrozaCampo(string asCodInforme, Int32 aiNumPoa)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica exeInf = new CLogica();
                List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> olEspecie = exeInf.RegMostrarDatosTrozaCampo(asCodInforme, aiNumPoa);

                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = rutaBase + nombreFile;
                string rutaExcelBase = rutaBase + "TrozaCampo.xlsx";

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
                    int i = 1;
                    //Abrimos la conexión
                    conn.Open();
                    //Creamos la ficha
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        //Construyendo las Cabeceras
                        foreach (var item in olEspecie)
                        {
                            insertar = "";
                            insertar = insertar + "'" + item.CODIGO.ToString() + "'";
                            if (item.ESPECIES.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                            }
                            insertar = insertar + ",'" + item.ZONA.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                            insertar = insertar + ",'" + item.DAP1.ToString() + "'";
                            insertar = insertar + ",'" + item.DAP2.ToString() + "'";
                            insertar = insertar + ",'" + item.LC.ToString() + "'";
                            insertar = insertar + ",'" + (item.OBSERVACION.Length > 254 ? item.OBSERVACION.Substring(0, 254) : item.OBSERVACION) + "'";
                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olEspecie.Count + 1).ToString() + "] VALUES (" + insertar + ")";
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
        public static ListResult DatosMaderaAserrada(string asCodInforme, Int32 aiNumPoa)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica exeInf = new CLogica();
                List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> olEspecie = exeInf.RegMostrarDatosMaderaAserrada(asCodInforme, aiNumPoa);

                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = rutaBase + nombreFile;
                string rutaExcelBase = rutaBase + "MaderaAserradaCampo.xlsx";

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
                    int i = 1;
                    //Abrimos la conexión
                    conn.Open();
                    //Creamos la ficha
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        //Construyendo las Cabeceras
                        foreach (var item in olEspecie)
                        {
                            insertar = "";
                            insertar = insertar + "'" + item.CODIGO.ToString() + "'";
                            if (item.ESPECIES.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                            }
                            insertar = insertar + ",'" + item.PIEZAS.ToString() + "'";
                            insertar = insertar + ",'" + item.ZONA.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                            insertar = insertar + ",'" + item.ESPESOR.ToString() + "'";
                            insertar = insertar + ",'" + item.ANCHO.ToString() + "'";
                            insertar = insertar + ",'" + item.LARGO.ToString() + "'";
                            insertar = insertar + ",'" + (item.OBSERVACION.Length > 254 ? item.OBSERVACION.Substring(0, 254) : item.OBSERVACION) + "'";
                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olEspecie.Count + 1).ToString() + "] VALUES (" + insertar + ")";
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
        public static ListResult DatosCarrizoCampo(string asCodInforme, Int32 aiNumPoa)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica exeInf = new CLogica();
                List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> olEspecie = exeInf.RegMostrarDatosCarrizoCampo(asCodInforme, aiNumPoa);

                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = rutaBase + nombreFile;
                string rutaExcelBase = rutaBase + "DatosCampoNoMaderableCarrizo.xlsx";

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
                    int i = 1;
                    //Abrimos la conexión
                    conn.Open();
                    //Creamos la ficha
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        //Construyendo las Cabeceras
                        foreach (var item in olEspecie)
                        {
                            insertar = "";
                            //insertar = insertar + "'" + "" + "'";
                            //insertar = insertar + ",'" + "" + "'";
                            if (item.ESPECIES.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = "'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                            }
                            insertar = insertar + ",'" + item.TOTAL_UNIDAD_MUEST.ToString() + "'";
                            insertar = insertar + ",'" + item.TOTAL_UNIDADES_APROV.ToString() + "'";
                            insertar = insertar + ",'" + item.ZONA.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                            insertar = insertar + ",'" + item.PRODUCTO_EXTRAER.ToString() + "'";
                            insertar = insertar + ",'" + (item.OBSERVACION.Length > 254 ? item.OBSERVACION.Substring(0, 254) : item.OBSERVACION) + "'";
                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":I" + (olEspecie.Count + 1).ToString() + "] VALUES (" + insertar + ")";
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
        public static ListResult DatosPlantaMedicinal(string asCodInforme, Int32 aiNumPoa)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica exeInf = new CLogica();
                List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> olEspecie = exeInf.RegMostrarDatosCarrizoCampo(asCodInforme, aiNumPoa);

                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = rutaBase + nombreFile;
                string rutaExcelBase = rutaBase + "PoaCensoNoMaderablePlantaMedicinal.xlsx";

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
                    int i = 1;
                    //Abrimos la conexión
                    conn.Open();
                    //Creamos la ficha
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        //Construyendo las Cabeceras
                        foreach (var item in olEspecie)
                        {
                            insertar = "";
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                            if (item.ESPECIES.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                            }
                            insertar = insertar + ",'" + item.UNIDAD_MEDIDA.ToString() + "'";
                            insertar = insertar + ",'" + item.NUM_INDIVIDUOS.ToString() + "'";
                            insertar = insertar + ",'" + item.ZONA.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                            insertar = insertar + ",'" + (item.OBSERVACION.Length > 254 ? item.OBSERVACION.Substring(0, 254) : item.OBSERVACION) + "'";
                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":J" + (olEspecie.Count + 1).ToString() + "] VALUES (" + insertar + ")";
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
        public static ListResult DatosVerticeVerificado(string asCodInforme, Int32 aiNumPoa)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica exeInf = new CLogica();
                List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO> olEspecie = exeInf.RegMostrarDatosVerticeVerificado(asCodInforme, aiNumPoa);

                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = rutaBase + nombreFile;
                string rutaExcelBase = rutaBase + "PoaCensoNoMaderableVertices.xlsx";

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
                    int i = 1;
                    //Abrimos la conexión
                    conn.Open();
                    //Creamos la ficha
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        //Construyendo las Cabeceras
                        foreach (var item in olEspecie)
                        {
                            insertar = "";
                            insertar = insertar + "'" + item.VERTICE.ToString() + "'";
                            insertar = insertar + ",'" + item.VERTICE_CAMPO.ToString() + "'";
                            insertar = insertar + ",'" + item.ZONA.ToString() + "'";
                            insertar = insertar + ",'" + item.ZONA_CAMPO.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_ESTE_CAMPO.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_NORTE_CAMPO.ToString() + "'";
                            insertar = insertar + ",'" + (item.OBSERVACION.Length > 254 ? item.OBSERVACION.Substring(0, 254) : item.OBSERVACION) + "'";
                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":I" + (olEspecie.Count + 1).ToString() + "] VALUES (" + insertar + ")";
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

        public static ListResult PrevisualizarObservatorio(string asCodInforme, Int32 aiNumPoa)
        {
            ListResult result = new ListResult();
            try
            {
                CLogica exeInf = new CLogica();
                CEntidad entInf = new CEntidad();
                Int32 idRegistro = 0;
                string fileName = "";

                entInf.COD_DOCUMENTO_REPORT = asCodInforme;
                entInf.TIPO_DOCUMENTO_REPORT = "INFORME DE SUPERVISION";
                entInf.NUM_POA_REPORT = aiNumPoa;
                idRegistro = exeInf.RegPreProcesarObservatorio(entInf);

                if (idRegistro > 0)
                {
                    sigoWSObservatorio.WSObservatorioSoapClient ws = new sigoWSObservatorio.WSObservatorioSoapClient();
                    fileName = ws.escribirDetallePDFIndex(idRegistro, "~/PlantillaPDF/", "1");
                }
                else { throw new Exception("Este Plan no esta contemplado para el procesamiento del Observatorio OSINFOR"); }

                result.AddResultado(fileName, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public static ListResult DatosInforme(string asCodInforme)
        {
            ListResult result = new ListResult();
            try
            {
                if (string.IsNullOrEmpty(asCodInforme))
                    throw new Exception("Primero se debe registrar el informe de supervisión para poder descargar los datos");

                CEntidad oCEntidadInfTemp = new CEntidad();
                CLogica exeInf = new CLogica();

                oCEntidadInfTemp.BusValor = asCodInforme;
                oCEntidadInfTemp = exeInf.RegListDescargaExcel(oCEntidadInfTemp);
                int i = 1;
                String insertar = "";
                String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/InformeSup/");
                string nombreFile = "";
                nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = RutaReporteSeguimiento + nombreFile;
                System.IO.File.Copy(RutaReporteSeguimiento + "ReporteDescargaSupervision.xls", rutaExcel); //pues si es mover 
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
                        ///Construyendo las Cabeceras
                        ///POA
                        if (oCEntidadInfTemp.ListPOAs.Count > 0)
                        {
                            foreach (var listaInf in oCEntidadInfTemp.ListPOAs)
                            {
                                insertar = "";
                                insertar = "'" + listaInf.POA + "'";
                                insertar = insertar + ",'" + listaInf.NUMERO + "'";
                                insertar = insertar + ",'" + listaInf.VERTICE + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_ESTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_NORTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.PCA + "'";
                                insertar = insertar + ",'" + listaInf.TITULAR + "'";
                                insertar = insertar + ",'" + listaInf.COD_THABILITANTE + "'";
                                insertar = insertar + ",'" + (listaInf.NUM_POA == 0 ? "" : listaInf.NUM_POA.ToString()) + "'";
                                insertar = insertar + ",'" + listaInf.COD_INFORME.ToString() + "'";

                                cmd.CommandText = "INSERT INTO [shp_ver_pm$A" + i.ToString().Trim() + ":N" + (oCEntidadInfTemp.ListPOAs.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();

                                result.data = listaInf.NUMERO;
                            }
                        }
                        //campo
                        if (oCEntidadInfTemp.ListPOAsCampo.Count > 0)
                        {
                            foreach (var listaInf in oCEntidadInfTemp.ListPOAsCampo)
                            {
                                insertar = "";
                                insertar = "'" + listaInf.POA + "'";
                                insertar = insertar + ",'" + listaInf.NUMERO + "'";
                                insertar = insertar + ",'" + listaInf.VERTICE + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_ESTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_NORTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.PCA + "'";
                                insertar = insertar + ",'" + (listaInf.OBSERVACION.Length > 254 ? listaInf.OBSERVACION.Substring(0, 254) : listaInf.OBSERVACION) + "'";
                                insertar = insertar + ",'" + listaInf.COD_THABILITANTE + "'";
                                insertar = insertar + ",'" + (listaInf.NUM_POA == 0 ? "" : listaInf.NUM_POA.ToString()) + "'";
                                insertar = insertar + ",'" + listaInf.COD_INFORME.ToString() + "'";
                                insertar = insertar + ",'" + (listaInf.COD_SECUENCIAL == 0 ? "" : listaInf.COD_SECUENCIAL.ToString()) + "'";
                                cmd.CommandText = "INSERT INTO [shp_ver_campo$A" + i.ToString().Trim() + ":K" + (oCEntidadInfTemp.ListPOAsCampo.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();

                                result.data = listaInf.NUMERO;
                            }
                        }
                        //ARB APROBECHABLES
                        if (oCEntidadInfTemp.ListISupervMaderableAprov.Count > 0)
                        {
                            foreach (var listaInf in oCEntidadInfTemp.ListISupervMaderableAprov)
                            {
                                insertar = "";
                                insertar = "'" + listaInf.POA + "'";
                                insertar = insertar + ",'" + listaInf.NUMERO + "'";
                                insertar = insertar + ",'" + listaInf.FAJA + "'";
                                insertar = insertar + ",'" + listaInf.FAJA_CAMPO + "'";
                                insertar = insertar + ",'" + listaInf.CODIGO + "'";
                                insertar = insertar + ",'" + listaInf.CODIGO_CAMPO + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES + "'";
                                if (listaInf.DESC_ESPECIES_CAMPO.Split('|').Length == 2)
                                {
                                    insertar = insertar + ",'" + listaInf.DESC_ESPECIES_CAMPO.Split('|')[0].Trim() + "'"; //Nombre científico
                                    insertar = insertar + ",'" + listaInf.DESC_ESPECIES_CAMPO.Split('|')[1].Trim() + "'"; //Nombre común
                                }
                                else
                                {
                                    insertar = insertar + ",' '";
                                    insertar = insertar + ",' '";
                                }
                                insertar = insertar + ",'" + listaInf.COORDENADA_ESTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_ESTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_NORTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_NORTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.DAP_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.DAP_CAMPO1.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.DAP_CAMPO2.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.MMEDIR_DAP.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.AC_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.ESTADO_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.CONDICION_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + (listaInf.OBSERVACION.Length > 254 ? listaInf.OBSERVACION.Substring(0, 254) : listaInf.OBSERVACION) + "'";
                                insertar = insertar + ",'" + listaInf.COD_THABILITANTE + "'";
                                insertar = insertar + ",'" + listaInf.NUM_POA.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COD_INFORME.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COD_ESPECIES + "'";
                                insertar = insertar + ",'" + listaInf.COD_SECUENCIAL.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.FUENTE_FOTO.ToString() + "'";

                                cmd.CommandText = "INSERT INTO [shp_arb_sup$A" + i.ToString().Trim() + ":AA" + (oCEntidadInfTemp.ListISupervMaderableAprov.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();

                                result.data = listaInf.NUMERO;
                            }
                        }
                        //NO MADERABLE
                        if (oCEntidadInfTemp.ListISupervNoMaderableAprov.Count > 0)
                        {
                            foreach (var listaInf in oCEntidadInfTemp.ListISupervNoMaderableAprov)
                            {
                                insertar = "";
                                insertar = "'" + listaInf.POA + "'";
                                insertar = insertar + ",'" + listaInf.NUMERO + "'";
                                insertar = insertar + ",'" + listaInf.FAJA + "'";
                                insertar = insertar + ",'" + listaInf.FAJA_CAMPO + "'";
                                insertar = insertar + ",'" + listaInf.CODIGO + "'";
                                insertar = insertar + ",'" + listaInf.CODIGO_CAMPO + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES + "'";
                                if (listaInf.DESC_ESPECIES_CAMPO.Split('|').Length == 2)
                                {
                                    insertar = insertar + ",'" + listaInf.DESC_ESPECIES_CAMPO.Split('|')[0].Trim() + "'"; //Nombre científico
                                    insertar = insertar + ",'" + listaInf.DESC_ESPECIES_CAMPO.Split('|')[1].Trim() + "'"; //Nombre común
                                }
                                else
                                {
                                    insertar = insertar + ",' '";
                                    insertar = insertar + ",' '";
                                }
                                insertar = insertar + ",'" + listaInf.COORDENADA_ESTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_ESTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_NORTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_NORTE_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.DAP_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.AC_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.ESTADO_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.CONDICION_CAMPO.ToString() + "'";
                                insertar = insertar + ",'" + (listaInf.OBSERVACION.Length > 254 ? listaInf.OBSERVACION.Substring(0, 254) : listaInf.OBSERVACION) + "'";
                                insertar = insertar + ",'" + listaInf.COD_THABILITANTE + "'";
                                insertar = insertar + ",'" + listaInf.NUM_POA.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COD_INFORME.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COD_ESPECIES + "'";
                                insertar = insertar + ",'" + listaInf.COD_SECUENCIAL.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.FUENTE_FOTO.ToString() + "'";

                                cmd.CommandText = "INSERT INTO [shp_nomad_sup$A" + i.ToString().Trim() + ":X" + (oCEntidadInfTemp.ListISupervNoMaderableAprov.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();

                                result.data = listaInf.NUMERO;
                            }
                        }
                        //TROZA
                        if (oCEntidadInfTemp.ListTrozaCampo.Count > 0)
                        {
                            foreach (var listaInf in oCEntidadInfTemp.ListTrozaCampo)
                            {
                                insertar = "";
                                insertar = "'" + listaInf.POA + "'";
                                insertar = insertar + ",'" + listaInf.NUMERO + "'";
                                insertar = insertar + ",'" + listaInf.CODIGO + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_ESTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_NORTE.ToString() + "'";
                                insertar = insertar + ",'" + (listaInf.OBSERVACION.Length > 254 ? listaInf.OBSERVACION.Substring(0, 254) : listaInf.OBSERVACION) + "'";
                                insertar = insertar + ",'" + listaInf.COD_THABILITANTE + "'";
                                insertar = insertar + ",'" + listaInf.NUM_POA.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COD_INFORME.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COD_ESPECIES.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.FUENTE_FOTO.ToString() + "'";
                                cmd.CommandText = "INSERT INTO [shp_ptos_ref$A" + i.ToString().Trim() + ":L" + (oCEntidadInfTemp.ListTrozaCampo.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();

                                result.data = listaInf.NUMERO;
                            }
                        }
                        //HUAYRONAS
                        /*if (oCEntidadInfTemp.ListHuayronas.Count > 0)
                        {
                            foreach (var listaInf in oCEntidadInfTemp.ListHuayronas)
                            {
                                insertar = "";
                                insertar = "'" + listaInf.POA + "'";
                                insertar = insertar + ",'" + listaInf.NUMERO + "'";
                                insertar = insertar + ",'" + listaInf.CODIGO + "'";
                                insertar = insertar + ",'" + listaInf.CONDICION + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_ESTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COORDENADA_NORTE.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COD_THABILITANTE + "'";
                                insertar = insertar + ",'" + listaInf.NUM_POA.ToString() + "'";
                                insertar = insertar + ",'" + listaInf.COD_INFORME.ToString() + "'";
                                cmd.CommandText = "INSERT INTO [prod_carbon$A" + i.ToString().Trim() + ":K" + (oCEntidadInfTemp.ListHuayronas.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();

                                result.data = listaInf.NUMERO;
                            }
                        }*/

                    }
                    //Cerramos la conexión
                    conn.Close();
                }

                result.AddResultado(nombreFile, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        //llanos
        public static ListResult Consolidado(string asCodInf, int iNumPoa, string idPC)
        {
            ListResult result = new ListResult();

            try
            {
                Log_INFORME _log_INFORME = new Log_INFORME();
                List<Dictionary<string, string>> olResult = _log_INFORME.Consolidado(asCodInf, iNumPoa, idPC);

                /*if (olResult.Count > 0)
                {
                }
                else { throw new Exception("No se encontraron registros"); }*/

                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string rutaExcelBase = rutaBase + "PlantillaConsolidado.xlsx";
                FileInfo template = new FileInfo(rutaExcelBase);
                int rowStart = 5;
                using (var package = new ExcelPackage(template))
                {
                    var workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets.First();
                    int NumAuto = 0;
                    decimal VolAuto = 0;
                    int NumApro = 0;
                    decimal VolApro = 0;
                    int NumSemi = 0;
                    int NumTota = 0;
                    int NumAEPC = 0;
                    decimal VolAEPC = 0;
                    int NumATUC = 0;
                    decimal VolATUC = 0;
                    int NumATFC = 0;
                    decimal VolATFC = 0;
                    int NumAMOC = 0;
                    decimal VolAMOC = 0;
                    int NumAMFC = 0;
                    decimal VolAMFC = 0;
                    int NumACNC = 0;
                    decimal VolACNC = 0;
                    int NumANEC = 0;
                    int NumNEPC = 0;
                    decimal VolNEPC = 0;
                    int NumNTUC = 0;
                    decimal VolNTUC = 0;
                    int NumNCNC = 0;
                    decimal VolNCNC = 0;
                    int NumSEPC = 0;
                    int NumSTUC = 0;
                    decimal VolSTUC = 0;
                    int NumSMOC = 0;
                    decimal VolSMOC = 0;
                    int NumSCNC = 0;
                    int NumSNEC = 0;
                    int NumNEAC = 0;
                    int NumNESC = 0;
                    int NumTOTC = 0;
                    foreach (var item in olResult)
                    {
                        if (item["TIPO"] == "C")//Coinciden
                        {
                            worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = item["NOMBRE_CIENTIFICO"];
                            worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = Int32.Parse(item["NUM_PIEZAS"]);
                            worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_AUTORIZADO"]);
                            worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARBOLES"]);
                            worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_CENSO"]);
                            worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SEM"]);
                            worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_TOT"]);
                            worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_AEP"]);
                            worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_AEP"]);
                            worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_ATU"]);
                            worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_ATU"]);
                            worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_ATF"]);
                            worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_ATF"]);
                            worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_AMO"]);
                            worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_AMO"]);
                            worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_AMF"]);
                            worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_AMF"]);
                            worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_ACN"]);
                            worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_ACN"]);
                            worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_ANE"]);
                            worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NEP"]);
                            worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_NEP"]);
                            worksheet.Cells[HelperSigo.GetColum(23) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NTU"]);
                            worksheet.Cells[HelperSigo.GetColum(24) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_NTU"]);
                            worksheet.Cells[HelperSigo.GetColum(25) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NCN"]);
                            worksheet.Cells[HelperSigo.GetColum(26) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_NCN"]);
                            worksheet.Cells[HelperSigo.GetColum(27) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SEP"]);
                            worksheet.Cells[HelperSigo.GetColum(28) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_STU"]);
                            worksheet.Cells[HelperSigo.GetColum(29) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_STU"]);
                            worksheet.Cells[HelperSigo.GetColum(30) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SMO"]);
                            worksheet.Cells[HelperSigo.GetColum(31) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_SMO"]);
                            worksheet.Cells[HelperSigo.GetColum(32) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SCN"]);
                            worksheet.Cells[HelperSigo.GetColum(33) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SNE"]);
                            worksheet.Cells[HelperSigo.GetColum(34) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NEA"]);
                            worksheet.Cells[HelperSigo.GetColum(35) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NES"]);
                            worksheet.Cells[HelperSigo.GetColum(36) + rowStart.ToString()].Value = Int32.Parse(item["TOTAL_SUP"]);
                            rowStart = rowStart + 1;
                            NumAuto = NumAuto + Int32.Parse(item["NUM_PIEZAS"]);
                            VolAuto = VolAuto + decimal.Parse(item["VOLUMEN_AUTORIZADO"]);
                            NumApro = NumApro + Int32.Parse(item["NUM_ARBOLES"]);
                            VolApro = VolApro + decimal.Parse(item["VOLUMEN_CENSO"]);
                            NumSemi = NumSemi + Int32.Parse(item["NUM_ARB_SEM"]);
                            NumTota = NumTota + Int32.Parse(item["NUM_ARB_TOT"]);
                            NumAEPC = NumAEPC + Int32.Parse(item["NUM_ARB_AEP"]);
                            VolAEPC = VolAEPC + decimal.Parse(item["VOLUMEN_AEP"]);
                            NumATUC = NumATUC + Int32.Parse(item["NUM_ARB_ATU"]);
                            VolATUC = VolATUC + decimal.Parse(item["VOLUMEN_ATU"]);
                            NumATFC = NumATFC + Int32.Parse(item["NUM_ARB_ATF"]);
                            VolATFC = VolATFC + decimal.Parse(item["VOLUMEN_ATF"]);
                            NumAMOC = NumAMOC + Int32.Parse(item["NUM_ARB_AMO"]);
                            VolAMOC = VolAMOC + decimal.Parse(item["VOLUMEN_AMO"]);
                            NumAMFC = NumAMFC + Int32.Parse(item["NUM_ARB_AMF"]);
                            VolAMFC = VolAMFC + decimal.Parse(item["VOLUMEN_AMF"]);
                            NumACNC = NumACNC + Int32.Parse(item["NUM_ARB_ACN"]);
                            VolACNC = VolACNC + decimal.Parse(item["VOLUMEN_ACN"]);
                            NumANEC = NumANEC + Int32.Parse(item["NUM_ARB_ANE"]);
                            NumNEPC = NumNEPC + Int32.Parse(item["NUM_ARB_NEP"]);
                            VolNEPC = VolNEPC + decimal.Parse(item["VOLUMEN_NEP"]);
                            NumNTUC = NumNTUC + Int32.Parse(item["NUM_ARB_NTU"]);
                            VolNTUC = VolNTUC + decimal.Parse(item["VOLUMEN_NTU"]);
                            NumNCNC = NumNCNC + Int32.Parse(item["NUM_ARB_NCN"]);
                            VolNCNC = VolNCNC + decimal.Parse(item["VOLUMEN_NCN"]);
                            NumSEPC = NumSEPC + Int32.Parse(item["NUM_ARB_SEP"]);
                            NumSTUC = NumSTUC + Int32.Parse(item["NUM_ARB_STU"]);
                            VolSTUC = VolSTUC + decimal.Parse(item["VOLUMEN_STU"]);
                            NumSMOC = NumSMOC + Int32.Parse(item["NUM_ARB_SMO"]);
                            VolSMOC = VolSMOC + decimal.Parse(item["VOLUMEN_SMO"]);
                            NumSCNC = NumSCNC + Int32.Parse(item["NUM_ARB_SCN"]);
                            NumSNEC = NumSNEC + Int32.Parse(item["NUM_ARB_SNE"]);
                            NumNEAC = NumNEAC + Int32.Parse(item["NUM_ARB_NEA"]);
                            NumNESC = NumNESC + Int32.Parse(item["NUM_ARB_NES"]);
                            NumTOTC = NumTOTC + Int32.Parse(item["TOTAL_SUP"]);
                        }
                    }
                    #region "Total Coinciden"
                    string CelIni = HelperSigo.GetColum(1) + rowStart.ToString();
                    string CelFin = HelperSigo.GetColum(36) + rowStart.ToString();
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Font.Bold = true;
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238));//Total

                    worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = "TOTAL";
                    worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = NumAuto;
                    worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = VolAuto;
                    worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = NumApro;
                    worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = VolApro;
                    worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = NumSemi;
                    worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = NumTota;
                    worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = NumAEPC;
                    worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = VolAEPC;
                    worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = NumATUC;
                    worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = VolATUC;
                    worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = NumATFC;
                    worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = VolATFC;
                    worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = NumAMOC;
                    worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = VolAMOC;
                    worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = NumAMFC;
                    worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = VolAMFC;
                    worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = NumACNC;
                    worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = VolACNC;
                    worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = NumANEC;
                    worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Value = NumNEPC;
                    worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Value = VolNEPC;
                    worksheet.Cells[HelperSigo.GetColum(23) + rowStart.ToString()].Value = NumNTUC;
                    worksheet.Cells[HelperSigo.GetColum(24) + rowStart.ToString()].Value = VolNTUC;
                    worksheet.Cells[HelperSigo.GetColum(25) + rowStart.ToString()].Value = NumNCNC;
                    worksheet.Cells[HelperSigo.GetColum(26) + rowStart.ToString()].Value = VolNCNC;
                    worksheet.Cells[HelperSigo.GetColum(27) + rowStart.ToString()].Value = NumSEPC;
                    worksheet.Cells[HelperSigo.GetColum(28) + rowStart.ToString()].Value = NumSTUC;
                    worksheet.Cells[HelperSigo.GetColum(29) + rowStart.ToString()].Value = VolSTUC;
                    worksheet.Cells[HelperSigo.GetColum(30) + rowStart.ToString()].Value = NumSMOC;
                    worksheet.Cells[HelperSigo.GetColum(31) + rowStart.ToString()].Value = VolSMOC;
                    worksheet.Cells[HelperSigo.GetColum(32) + rowStart.ToString()].Value = NumSCNC;
                    worksheet.Cells[HelperSigo.GetColum(33) + rowStart.ToString()].Value = NumSNEC;
                    worksheet.Cells[HelperSigo.GetColum(34) + rowStart.ToString()].Value = NumNEAC;
                    worksheet.Cells[HelperSigo.GetColum(35) + rowStart.ToString()].Value = NumNESC;
                    worksheet.Cells[HelperSigo.GetColum(36) + rowStart.ToString()].Value = NumTOTC;
                    rowStart = rowStart + 1;
                    #endregion

                    #region "Cabecera No Coinciden"


                    CelIni = HelperSigo.GetColum(1) + rowStart.ToString();
                    CelFin = HelperSigo.GetColum(36) + rowStart.ToString();

                    worksheet.Cells[CelIni + ":" + CelFin].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Font.Bold = true;
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Font.Size = 8;
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Font.Name = "Arial";
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247)); //Cabecera                        

                    //worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = "Nombre cientifico";
                    //worksheet.Cells[CelIni + ":" + CelFin].Merge = true;

                    worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = "Nombre cientifico";
                    worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(23) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(24) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(25) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(26) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(27) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(28) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(29) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(30) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(31) + rowStart.ToString()].Value = "Vol. (m3)";
                    worksheet.Cells[HelperSigo.GetColum(32) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(33) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(34) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(35) + rowStart.ToString()].Value = "N° Árb.";
                    worksheet.Cells[HelperSigo.GetColum(36) + rowStart.ToString()].Value = "N° Árb.";
                    rowStart = rowStart + 1;
                    #endregion

                    NumAuto = 0;
                    VolAuto = 0;
                    NumApro = 0;
                    VolApro = 0;
                    NumSemi = 0;
                    NumTota = 0;
                    NumAEPC = 0;
                    VolAEPC = 0;
                    NumATUC = 0;
                    VolATUC = 0;
                    NumATFC = 0;
                    VolATFC = 0;
                    NumAMOC = 0;
                    VolAMOC = 0;
                    NumAMFC = 0;
                    VolAMFC = 0;
                    NumACNC = 0;
                    VolACNC = 0;
                    NumANEC = 0;
                    NumNEPC = 0;
                    VolNEPC = 0;
                    NumNTUC = 0;
                    VolNTUC = 0;
                    NumNCNC = 0;
                    VolNCNC = 0;
                    NumSEPC = 0;
                    NumSTUC = 0;
                    VolSTUC = 0;
                    NumSMOC = 0;
                    VolSMOC = 0;
                    NumSCNC = 0;
                    NumSNEC = 0;
                    NumNEAC = 0;
                    NumNESC = 0;
                    NumTOTC = 0;

                    foreach (var item in olResult)
                    {
                        if (item["TIPO"] == "N")
                        {
                            worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = item["NOMBRE_CIENTIFICO"];
                            worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = Int32.Parse(item["NUM_PIEZAS"]);
                            worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_AUTORIZADO"]);
                            worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARBOLES"]);
                            worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_CENSO"]);
                            worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SEM"]);
                            worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_TOT"]);
                            worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_AEP"]);
                            worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_AEP"]);
                            worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_ATU"]);
                            worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_ATU"]);
                            worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_ATF"]);
                            worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_ATF"]);
                            worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_AMO"]);
                            worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_AMO"]);
                            worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_AMF"]);
                            worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_AMF"]);
                            worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_ACN"]);
                            worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_ACN"]);
                            worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_ANE"]);
                            worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NEP"]);
                            worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_NEP"]);
                            worksheet.Cells[HelperSigo.GetColum(23) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NTU"]);
                            worksheet.Cells[HelperSigo.GetColum(24) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_NTU"]);
                            worksheet.Cells[HelperSigo.GetColum(25) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NCN"]);
                            worksheet.Cells[HelperSigo.GetColum(26) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_NCN"]);
                            worksheet.Cells[HelperSigo.GetColum(27) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SEP"]);
                            worksheet.Cells[HelperSigo.GetColum(28) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_STU"]);
                            worksheet.Cells[HelperSigo.GetColum(29) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_STU"]);
                            worksheet.Cells[HelperSigo.GetColum(30) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SMO"]);
                            worksheet.Cells[HelperSigo.GetColum(31) + rowStart.ToString()].Value = decimal.Parse(item["VOLUMEN_SMO"]);
                            worksheet.Cells[HelperSigo.GetColum(32) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SCN"]);
                            worksheet.Cells[HelperSigo.GetColum(33) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_SNE"]);
                            worksheet.Cells[HelperSigo.GetColum(34) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NEA"]);
                            worksheet.Cells[HelperSigo.GetColum(35) + rowStart.ToString()].Value = Int32.Parse(item["NUM_ARB_NES"]);
                            worksheet.Cells[HelperSigo.GetColum(36) + rowStart.ToString()].Value = Int32.Parse(item["TOTAL_SUP"]);
                            rowStart = rowStart + 1;
                            NumAuto = NumAuto + Int32.Parse(item["NUM_PIEZAS"]);
                            VolAuto = VolAuto + decimal.Parse(item["VOLUMEN_AUTORIZADO"]);
                            NumApro = NumApro + Int32.Parse(item["NUM_ARBOLES"]);
                            VolApro = VolApro + decimal.Parse(item["VOLUMEN_CENSO"]);
                            NumSemi = NumSemi + Int32.Parse(item["NUM_ARB_SEM"]);
                            NumTota = NumTota + Int32.Parse(item["NUM_ARB_TOT"]);
                            NumAEPC = NumAEPC + Int32.Parse(item["NUM_ARB_AEP"]);
                            VolAEPC = VolAEPC + decimal.Parse(item["VOLUMEN_AEP"]);
                            NumATUC = NumATUC + Int32.Parse(item["NUM_ARB_ATU"]);
                            VolATUC = VolATUC + decimal.Parse(item["VOLUMEN_ATU"]);
                            NumATFC = NumATFC + Int32.Parse(item["NUM_ARB_ATF"]);
                            VolATFC = VolATFC + decimal.Parse(item["VOLUMEN_ATF"]);
                            NumAMOC = NumAMOC + Int32.Parse(item["NUM_ARB_AMO"]);
                            VolAMOC = VolAMOC + decimal.Parse(item["VOLUMEN_AMO"]);
                            NumAMFC = NumAMFC + Int32.Parse(item["NUM_ARB_AMF"]);
                            VolAMFC = VolAMFC + decimal.Parse(item["VOLUMEN_AMF"]);
                            NumACNC = NumACNC + Int32.Parse(item["NUM_ARB_ACN"]);
                            VolACNC = VolACNC + decimal.Parse(item["VOLUMEN_ACN"]);
                            NumANEC = NumANEC + Int32.Parse(item["NUM_ARB_ANE"]);
                            NumNEPC = NumNEPC + Int32.Parse(item["NUM_ARB_NEP"]);
                            VolNEPC = VolNEPC + decimal.Parse(item["VOLUMEN_NEP"]);
                            NumNTUC = NumNTUC + Int32.Parse(item["NUM_ARB_NTU"]);
                            VolNTUC = VolNTUC + decimal.Parse(item["VOLUMEN_NTU"]);
                            NumNCNC = NumNCNC + Int32.Parse(item["NUM_ARB_NCN"]);
                            VolNCNC = VolNCNC + decimal.Parse(item["VOLUMEN_NCN"]);
                            NumSEPC = NumSEPC + Int32.Parse(item["NUM_ARB_SEP"]);
                            NumSTUC = NumSTUC + Int32.Parse(item["NUM_ARB_STU"]);
                            VolSTUC = VolSTUC + decimal.Parse(item["VOLUMEN_STU"]);
                            NumSMOC = NumSMOC + Int32.Parse(item["NUM_ARB_SMO"]);
                            VolSMOC = VolSMOC + decimal.Parse(item["VOLUMEN_SMO"]);
                            NumSCNC = NumSCNC + Int32.Parse(item["NUM_ARB_SCN"]);
                            NumSNEC = NumSNEC + Int32.Parse(item["NUM_ARB_SNE"]);
                            NumNEAC = NumNEAC + Int32.Parse(item["NUM_ARB_NEA"]);
                            NumNESC = NumNESC + Int32.Parse(item["NUM_ARB_NES"]);
                            NumTOTC = NumTOTC + Int32.Parse(item["TOTAL_SUP"]);
                        }
                    }

                    #region "Total NoCoinciden"
                    CelIni = HelperSigo.GetColum(1) + rowStart.ToString();
                    CelFin = HelperSigo.GetColum(36) + rowStart.ToString();
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Font.Bold = true;
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[CelIni + ":" + CelFin].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238));//Total

                    worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = "TOTAL";
                    worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = NumAuto;
                    worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = VolAuto;
                    worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = NumApro;
                    worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = VolApro;
                    worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = NumSemi;
                    worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = NumTota;
                    worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = NumAEPC;
                    worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = VolAEPC;
                    worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = NumATUC;
                    worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = VolATUC;
                    worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = NumATFC;
                    worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = VolATFC;
                    worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = NumAMOC;
                    worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = VolAMOC;
                    worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = NumAMFC;
                    worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = VolAMFC;
                    worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = NumACNC;
                    worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = VolACNC;
                    worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = NumANEC;
                    worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Value = NumNEPC;
                    worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Value = VolNEPC;
                    worksheet.Cells[HelperSigo.GetColum(23) + rowStart.ToString()].Value = NumNTUC;
                    worksheet.Cells[HelperSigo.GetColum(24) + rowStart.ToString()].Value = VolNTUC;
                    worksheet.Cells[HelperSigo.GetColum(25) + rowStart.ToString()].Value = NumNCNC;
                    worksheet.Cells[HelperSigo.GetColum(26) + rowStart.ToString()].Value = VolNCNC;
                    worksheet.Cells[HelperSigo.GetColum(27) + rowStart.ToString()].Value = NumSEPC;
                    worksheet.Cells[HelperSigo.GetColum(28) + rowStart.ToString()].Value = NumSTUC;
                    worksheet.Cells[HelperSigo.GetColum(29) + rowStart.ToString()].Value = VolSTUC;
                    worksheet.Cells[HelperSigo.GetColum(30) + rowStart.ToString()].Value = NumSMOC;
                    worksheet.Cells[HelperSigo.GetColum(31) + rowStart.ToString()].Value = VolSMOC;
                    worksheet.Cells[HelperSigo.GetColum(32) + rowStart.ToString()].Value = NumSCNC;
                    worksheet.Cells[HelperSigo.GetColum(33) + rowStart.ToString()].Value = NumSNEC;
                    worksheet.Cells[HelperSigo.GetColum(34) + rowStart.ToString()].Value = NumNEAC;
                    worksheet.Cells[HelperSigo.GetColum(35) + rowStart.ToString()].Value = NumNESC;
                    worksheet.Cells[HelperSigo.GetColum(36) + rowStart.ToString()].Value = NumTOTC;
                    rowStart = rowStart + 1;
                    #endregion

                    string modelRange = "A3:AJ" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    using (var memoryStream = new MemoryStream())
                    {
                        package.SaveAs(memoryStream);

                        result.success = true;
                        result.byteFile = memoryStream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }

        public static ListResult Maderable(string asCodInf, int iNumPoa, string idPC)
        {
            ListResult result = new ListResult();

            try
            {
                Log_INFORME _log_INFORME = new Log_INFORME();
                List<Dictionary<string, string>> olResult = _log_INFORME.Maderable(asCodInf, iNumPoa, idPC);

                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string rutaExcelBase = rutaBase + "PlantillaMaderable.xlsx";
                FileInfo template = new FileInfo(rutaExcelBase);
                int rowStart = 4;
                int contador = 0;

                using (var package = new ExcelPackage(template))
                {
                    var workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets.First();

                    foreach (var item in olResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item["CODIGO"];
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item["CODIGO_CAMPO"];
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item["NOMBRE_PMF"];
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item["NOMBRE_COMUN_PMF"];
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item["NOMBRE_SUP"];
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item["NOMBRE_COMUN_SUP"];
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = Int32.Parse(item["COORDENADA_ESTE_PMF"]);
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = Int32.Parse(item["COORDENADA_NORTE_PMF"]);
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = Int32.Parse(item["COORDENADA_ESTE_SUP"]);
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = Int32.Parse(item["COORDENADA_NORTE_SUP"]);
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = decimal.Parse(item["DAP_PMF"]);
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = decimal.Parse(item["DAP_SUP"]);
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = decimal.Parse(item["DAP1_SUP"]);
                        worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = decimal.Parse(item["DAP2_SUP"]);
                        worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = item["METOD_MEDIR_DAP"];
                        worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = decimal.Parse(item["AC_PMF"]);
                        worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = decimal.Parse(item["AC_SUP"]);
                        worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = decimal.Parse(item["VOL_PMF"]);
                        worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = decimal.Parse(item["VOL_SUP"]);
                        worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Value = item["COINCIDE_CODIGO"];
                        worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Value = item["COINCIDE_ESPECIES"];
                        worksheet.Cells[HelperSigo.GetColum(23) + rowStart.ToString()].Value = decimal.Parse(item["DAP_RP"]);
                        worksheet.Cells[HelperSigo.GetColum(24) + rowStart.ToString()].Value = decimal.Parse(item["AC_RP"]);
                        worksheet.Cells[HelperSigo.GetColum(25) + rowStart.ToString()].Value = decimal.Parse(item["COO_RP"]);
                        worksheet.Cells[HelperSigo.GetColum(26) + rowStart.ToString()].Value = item["ESTADO"];
                        worksheet.Cells[HelperSigo.GetColum(27) + rowStart.ToString()].Value = item["CONDICION"];
                        rowStart = rowStart + 1;
                    }

                    string modelRange = "A3:AA" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    using (var memoryStream = new MemoryStream())
                    {
                        package.SaveAs(memoryStream);

                        result.success = true;
                        result.byteFile = memoryStream.ToArray();
                    }
                }
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
 