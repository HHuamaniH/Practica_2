using CapaEntidad.ViewModel;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;
using CEntidad = CapaEntidad.DOC.Ent_CNOTIFICACION;
using CLogica = CapaLogica.DOC.Log_CNOTIFICACION;

namespace SIGOFCv3.Areas.Supervision.Models.ManCNotificacion
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
                paramCap.TIPO_REPORTE = "REGISTRO_USUARIO";
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = exeCap.ReportesCNotificacion(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "CNOTIFICACION_Reg_Usu.xlsx";

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
                                insertar = insertar + ",'" + (itemPart["TITULAR"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["PERSONA_NOTIFICADOR"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["MAE_CNTIPO"] ?? "") + "'";
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

        public static ListResult DatosGenerales(string asCodCNotificacion)
        {
            ListResult result = new ListResult();

            try
            {
                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = rutaBase + nombreFile;
                string rutaExcelBase = rutaBase + "CN_Datos_POA.xlsx";

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
                        //Construyendo las Cabeceras
                        sigoWSSupervision.WSSupervisionSoapClient ws = new sigoWSSupervision.WSSupervisionSoapClient();
                        sigoWSSupervision.autenticaUser authUsuario = new sigoWSSupervision.autenticaUser();
                        authUsuario.userName = "XXXXXXX";
                        authUsuario.password = "yyyyyyyyyyy";

                        var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(ws.listaDatosPOAs(authUsuario, asCodCNotificacion)), new System.Xml.XmlDictionaryReaderQuotas());
                        List<XNode> nodos = XElement.Load(jsonReader).Nodes().ToList();

                        foreach (var fila in nodos)
                        {
                            insertar = "";
                            insertar = insertar + "'" + fila.XPathSelectElement("MODALIDAD").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("NUM_THABILITANTE").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("TITULAR").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("OD").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("MODALIDAD").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("ARESOLUCION_NUM").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("NOMBRE_POA").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("NUM_PCOMPLEMENTARIO").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("AREA_POA").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("PCA").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("ZAFRA_PCA").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("INICIO_VIGENCIA").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("FIN_VIGENCIA").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("DEPARTAMENTO").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("PROVINCIA").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("DISTRITO").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("FECHA_SUPERVISION_INI").Value + "'";
                            insertar = insertar + ",'" + fila.XPathSelectElement("FECHA_SUPERVISION_FIN").Value + "'";

                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (nodos.Count() + 1).ToString() + "] VALUES (" + insertar + ")";
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

        public static ListResult MuestraMaderable(string asCodCNotificacion)
        {
            ListResult result = new ListResult();

            try
            {
                CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE paramsCN = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
                CLogica exeCN = new CLogica();
                List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> lstCenso = new List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE>();

                paramsCN.COD_CNOTIFICACION = asCodCNotificacion;
                lstCenso = exeCN.RegMostrarPoaDetMadCensoLista(paramsCN).ListSDETMADERABLE;
                var lstMuestra = (from dat in lstCenso
                                  where (dat.NUM_MUESTRA == 1 && (bool)dat.ESTADO_MUESTRA == true)
                                      || (dat.NUM_MUESTRA == 2 && (bool)dat.ESTADO_MUESTRA2 == true)
                                      || (dat.NUM_MUESTRA == 3 && (bool)dat.ESTADO_MUESTRA3 == true)
                                  select dat).ToList();

                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = rutaBase + nombreFile;
                string rutaExcelBase = rutaBase + "CN_Muestra_Maderable.xlsx";

                int rowStart = 2;
                using (var package = new ExcelPackage(new FileInfo(rutaExcelBase)))
                {
                    var workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets.First();

                    int column = 0;

                    foreach (var item in lstMuestra)
                    {
                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (rowStart - 1).ToString();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUM_POA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DESC_ESPECIES;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.POA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.BLOQUE;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.FAJA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CODIGO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.VOLUMEN;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DAP;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.AC;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DMC;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DESC_ECONDICION;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DESC_EESTADO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ZONA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_ESTE;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_NORTE;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PCA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CODIGO_GPS;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COD_SISTEMA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.OBSERVACION.Length > 255 ? item.OBSERVACION.ToString().Substring(0, 255) : item.OBSERVACION;
                        rowStart++;
                    }

                    package.SaveAs(new FileInfo(rutaExcel));
                }

                /*
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
                        foreach (var item in lstMuestra)
                        {
                            insertar = "";
                            insertar = insertar + "'" + (ind++).ToString() + "'";
                            insertar = insertar + ",'" + item.NUM_POA.ToString() + "'";
                            insertar = insertar + ",'" + item.DESC_ESPECIES + "'";
                            insertar = insertar + ",'" + item.POA + "'";
                            insertar = insertar + ",'" + item.BLOQUE + "'";
                            insertar = insertar + ",'" + item.FAJA + "'";
                            insertar = insertar + ",'" + item.CODIGO + "'";
                            insertar = insertar + ",'" + item.VOLUMEN.ToString() + "'";
                            insertar = insertar + ",'" + item.DAP.ToString() + "'";
                            insertar = insertar + ",'" + item.AC.ToString() + "'";
                            insertar = insertar + ",'" + item.DMC.ToString() + "'";
                            insertar = insertar + ",'" + item.DESC_ECONDICION.ToString() + "'";
                            insertar = insertar + ",'" + item.DESC_EESTADO.ToString() + "'";
                            insertar = insertar + ",'" + item.ZONA.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                            insertar = insertar + ",'" + item.PCA.ToString() + "'";
                            insertar = insertar + ",'" + item.CODIGO_GPS.ToString() + "'";
                            insertar = insertar + ",'" + item.COD_SISTEMA.ToString() + "'";
                            insertar = insertar + ",'" + (item.OBSERVACION.Length > 255 ? item.OBSERVACION.ToString().Substring(0, 255) : item.OBSERVACION.ToString()) + "'";

                            cmd.CommandText = "INSERT INTO [Muestra$A" + i.ToString().Trim() + ":Z" + (lstMuestra.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                            cmd.ExecuteNonQuery();
                        }
                        //Cerramos la conexión
                        conn.Close();
                    }
                }*/

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

        public static ListResult MuestraNoMaderable(string asCodCNotificacion)
        {
            ListResult result = new ListResult();

            try
            {
                CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE paramsCN = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
                CLogica exeCN = new CLogica();
                List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> lstCenso = new List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE>();

                paramsCN.COD_CNOTIFICACION = asCodCNotificacion;
                lstCenso = exeCN.RegMostrarPoaDetNoMadCensoLista(paramsCN).ListSDETMADERABLE;
                var lstMuestra = (from dat in lstCenso
                                  where (dat.NUM_MUESTRA == 1 && (bool)dat.ESTADO_MUESTRA == true)
                                      || (dat.NUM_MUESTRA == 2 && (bool)dat.ESTADO_MUESTRA2 == true)
                                      || (dat.NUM_MUESTRA == 3 && (bool)dat.ESTADO_MUESTRA3 == true)
                                  select dat).ToList();

                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = rutaBase + nombreFile;
                string rutaExcelBase = rutaBase + "CN_Muestra_NoMaderable.xlsx";

                int rowStart = 2;
                using (var package = new ExcelPackage(new FileInfo(rutaExcelBase)))
                {
                    var workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets.First();

                    int column = 0;

                    foreach (var item in lstMuestra)
                    {
                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (rowStart - 1).ToString();                        
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DESC_ESPECIES;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUM_POA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUM_ESTRADA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CODIGO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DIAMETRO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ALTURA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PRODUCCION_LATAS;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DESC_ECONDICION;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ZONA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_ESTE;         
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_NORTE;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CODIGO_GPS;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COD_SISTEMA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.OBSERVACION.Length > 255 ? item.OBSERVACION.ToString().Substring(0, 255) : item.OBSERVACION;
                        rowStart++;
                    }

                    package.SaveAs(new FileInfo(rutaExcel));
                }

                /*
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
                        foreach (var item in lstMuestra)
                        {
                            insertar = "";
                            insertar = insertar + "'" + (ind++).ToString() + "'";
                            insertar = insertar + ",'" + item.DESC_ESPECIES + "'";
                            insertar = insertar + ",'" + item.NUM_POA.ToString() + "'";
                            insertar = insertar + ",'" + item.NUM_ESTRADA + "'";
                            insertar = insertar + ",'" + item.CODIGO + "'";
                            insertar = insertar + ",'" + item.DIAMETRO.ToString() + "'";
                            insertar = insertar + ",'" + item.ALTURA.ToString() + "'";
                            insertar = insertar + ",'" + item.PRODUCCION_LATAS.ToString() + "'";
                            insertar = insertar + ",'" + item.DESC_ECONDICION.ToString() + "'";
                            insertar = insertar + ",'" + item.ZONA.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
                            insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
                            insertar = insertar + ",'" + item.CODIGO_GPS.ToString() + "'";
                            insertar = insertar + ",'" + item.COD_SISTEMA.ToString() + "'";
                            insertar = insertar + ",'" + (item.OBSERVACION.Length > 255 ? item.OBSERVACION.ToString().Substring(0, 255) : item.OBSERVACION.ToString()) + "'";

                            cmd.CommandText = "INSERT INTO [Muestra$A" + i.ToString().Trim() + ":Z" + (lstMuestra.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                            cmd.ExecuteNonQuery();
                        }
                        //Cerramos la conexión
                        conn.Close();
                    }
                }*/

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