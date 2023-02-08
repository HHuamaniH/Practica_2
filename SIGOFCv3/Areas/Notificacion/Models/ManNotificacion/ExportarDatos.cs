using CapaEntidad.ViewModel;
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
using CEntidad = CapaEntidad.DOC.Ent_NOTIFICACION;
using CLogica = CapaLogica.DOC.Log_NOTIFICACION;

namespace SIGOFCv3.Areas.Notificacion.Models.ManNotificacion
{
    public class ExportarDatos
    {
        /// <summary>
        /// Exportar registro de cartas de notificación
        /// </summary>
        /// <param name="asCodUsuario"></param>
        /// <returns></returns>
        //public static ListResult RegistroUsuario(string asCodUsuario)
        //{
        //    ListResult result = new ListResult();

        //    try
        //    {
        //        CEntidad paramCap = new CEntidad();
        //        CLogica exeCap = new CLogica();
        //        paramCap.TIPO_REPORTE = "REGISTRO_USUARIO";
        //        paramCap.COD_UCUENTA = asCodUsuario;

        //        List<Dictionary<string, string>> olResult = exeCap.ReportesNotificacion(paramCap);

        //        if (olResult.Count > 0)
        //        {
        //            string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
        //            string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
        //            string rutaExcel = rutaBase + nombreFile;
        //            string rutaExcelBase = rutaBase + "NOTIFICACION_Reg_Usu_v3.xlsx";

        //            try
        //            {
        //                File.Delete(@rutaExcel);
        //                File.Copy(@rutaExcelBase, @rutaExcel);
        //            }
        //            catch (IOException ix)
        //            {
        //                throw new Exception(ix.Message);
        //            }

        //            //Creamos la cadena de conexión con el fichero excel
        //            OleDbConnectionStringBuilder cb = new OleDbConnectionStringBuilder();
        //            cb.DataSource = rutaExcel;
        //            if (Path.GetExtension(rutaExcel).ToUpper() == ".XLS")
        //            {
        //                cb.Provider = "Microsoft.Jet.OLEDB.4.0";
        //                cb.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=0;");
        //            }
        //            else if (Path.GetExtension(rutaExcel).ToUpper() == ".XLSX")
        //            {
        //                cb.Provider = "Microsoft.ACE.OLEDB.12.0";
        //                cb.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=0;");
        //            }

        //            using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
        //            {
        //                string insertar = "";
        //                string eval = "";
        //                int i = 1, ind = 1;
        //                //Abrimos la conexión
        //                conn.Open();
        //                //Creamos la ficha
        //                using (OleDbCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandType = CommandType.Text;
        //                    //Construyendo las Cabeceras
        //                    foreach (var itemPart in olResult)
        //                    {

        //                        insertar = "'" + (ind++).ToString() + "'";
        //                        insertar = insertar + ",'" + (itemPart["FECHA_REGISTRO"] ?? "") + "'";
        //                        insertar = insertar + ",'" + (itemPart["ANIO_REGISTRO"] ?? "") + "'";
        //                        insertar = insertar + ",'" + (itemPart["MES_REGISTRO"] ?? "") + "'";
        //                        insertar = insertar + ",'" + (itemPart["NUM_NOTIFICACION"] ?? "") + "'";
        //                        insertar = insertar + ",'" + (itemPart["TIPO"] ?? "") + "'";
        //                        insertar = insertar + ",'" + (itemPart["FECHA_EMISION"] ?? "") + "'";
        //                        insertar = insertar + ",'" + (itemPart["NOTIFICADOR"] ?? "") + "'";
        //                        eval = itemPart["NUM_THABILITANTE"] ?? "";
        //                        eval = eval.Replace("'", "").Replace('"', ' ');
        //                        insertar = insertar + ",'" + (eval == "" ? "" : eval.Length > 254 ? eval.Substring(0, 254) : eval) + "'";
        //                        eval = itemPart["TITULAR"] ?? "";
        //                        eval = eval.Replace("'", "").Replace('"', ' ');
        //                        insertar = insertar + ",'" + (eval == "" ? "" : eval.Length > 254 ? eval.Substring(0, 254) : eval) + "'";
        //                        eval = itemPart["NOMBRE_POA"] ?? "";
        //                        eval = eval.Replace("'", "").Replace('"', ' ');
        //                        insertar = insertar + ",'" + (eval == "" ? "" : eval.Length > 254 ? eval.Substring(0, 254) : eval) + "'";
        //                        eval = itemPart["NUM_INFORME"] ?? "";
        //                        eval = eval.Replace("'", "").Replace('"', ' ');
        //                        insertar = insertar + ",'" + (eval == "" ? "" : eval.Length > 254 ? eval.Substring(0, 254) : eval) + "'";
        //                        eval = itemPart["NUM_EXPEDIENTE"] ?? "";
        //                        eval = eval.Replace("'", "").Replace('"', ' ');
        //                        insertar = insertar + ",'" + (eval == "" ? "" : eval.Length > 254 ? eval.Substring(0, 254) : eval) + "'";
        //                        eval = itemPart["NUM_RESOLUCION"] ?? "";
        //                        eval = eval.Replace("'", "").Replace('"', ' ');
        //                        insertar = insertar + ",'" + (eval == "" ? "" : eval.Length > 254 ? eval.Substring(0, 254) : eval) + "'";
        //                        eval = itemPart["NUM_ILEGAL"] ?? "";
        //                        eval = eval.Replace("'", "").Replace('"', ' ');
        //                        insertar = insertar + ",'" + (eval == "" ? "" : eval.Length > 254 ? eval.Substring(0, 254) : eval) + "'";
        //                        insertar = insertar + ",'" + (itemPart["DESTINO"] ?? "") + "'";
        //                        insertar = insertar + ",'" + (itemPart["USUARIO"] ?? "") + "'";
        //                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (olResult.Count + 1).ToString() + "] VALUES (" + insertar + ")";
        //                        cmd.ExecuteNonQuery();
        //                    }

        //                    //Cerramos la conexión
        //                    conn.Close();
        //                }
        //            }
        //            result.success = true;
        //            result.msj = nombreFile;
        //        }
        //        else { throw new Exception("No se encontraron registros"); }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.success = false;
        //        result.msj = ex.Message;
        //    }
        //    return result;
        //}

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
                        authUsuario.userName = "EPIMENTEL";
                        authUsuario.password = "Niarfe22971278%";

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

        //public static ListResult MuestraMaderable(string asCodNotificacion)
        //{
        //    ListResult result = new ListResult();

        //    try
        //    {
        //        CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE paramsCN = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
        //        CLogica exeCN = new CLogica();
        //        List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> lstCenso = new List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE>();

        //        paramsCN.COD_FISNOTI = asCodNotificacion;
        //        lstCenso = exeCN.RegMostrarPoaDetMadCensoLista_v3(paramsCN);
        //        var lstMuestra = (from dat in lstCenso
        //                          where (dat.NUM_MUESTRA == 1 && (bool)dat.ESTADO_MUESTRA == true)
        //                              || (dat.NUM_MUESTRA == 2 && (bool)dat.ESTADO_MUESTRA2 == true)
        //                              || (dat.NUM_MUESTRA == 3 && (bool)dat.ESTADO_MUESTRA3 == true)
        //                          select dat).ToList();

        //        string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
        //        string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
        //        string rutaExcel = rutaBase + nombreFile;
        //        string rutaExcelBase = rutaBase + "CN_Muestra_Maderable.xlsx";

        //        try
        //        {
        //            File.Delete(@rutaExcel);
        //            File.Copy(@rutaExcelBase, @rutaExcel);
        //        }
        //        catch (IOException ix)
        //        {
        //            throw new Exception(ix.Message);
        //        }

        //        //Creamos la cadena de conexión con el fichero excel
        //        OleDbConnectionStringBuilder cb = new OleDbConnectionStringBuilder();
        //        cb.DataSource = rutaExcel;
        //        if (Path.GetExtension(rutaExcel).ToUpper() == ".XLS")
        //        {
        //            cb.Provider = "Microsoft.Jet.OLEDB.4.0";
        //            cb.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=0;");
        //        }
        //        else if (Path.GetExtension(rutaExcel).ToUpper() == ".XLSX")
        //        {
        //            cb.Provider = "Microsoft.ACE.OLEDB.12.0";
        //            cb.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=0;");
        //        }

        //        using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
        //        {
        //            string insertar = "";
        //            int i = 1, ind = 1;
        //            //Abrimos la conexión
        //            conn.Open();
        //            //Creamos la ficha
        //            using (OleDbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandType = CommandType.Text;
        //                //Construyendo las Cabeceras
        //                foreach (var item in lstMuestra)
        //                {
        //                    insertar = "";
        //                    insertar = insertar + "'" + (ind++).ToString() + "'";
        //                    insertar = insertar + ",'" + item.NUM_POA.ToString() + "'";
        //                    insertar = insertar + ",'" + item.DESC_ESPECIES + "'";
        //                    insertar = insertar + ",'" + item.POA + "'";
        //                    insertar = insertar + ",'" + item.BLOQUE + "'";
        //                    insertar = insertar + ",'" + item.FAJA + "'";
        //                    insertar = insertar + ",'" + item.CODIGO + "'";
        //                    insertar = insertar + ",'" + item.VOLUMEN.ToString() + "'";
        //                    insertar = insertar + ",'" + item.DAP.ToString() + "'";
        //                    insertar = insertar + ",'" + item.AC.ToString() + "'";
        //                    insertar = insertar + ",'" + item.DMC.ToString() + "'";
        //                    insertar = insertar + ",'" + item.DESC_ECONDICION.ToString() + "'";
        //                    insertar = insertar + ",'" + item.DESC_EESTADO.ToString() + "'";
        //                    insertar = insertar + ",'" + item.ZONA.ToString() + "'";
        //                    insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
        //                    insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
        //                    insertar = insertar + ",'" + item.CODIGO_GPS.ToString() + "'";
        //                    insertar = insertar + ",'" + item.COD_SISTEMA.ToString() + "'";
        //                    insertar = insertar + ",'" + (item.OBSERVACION.Length > 255 ? item.OBSERVACION.ToString().Substring(0, 255) : item.OBSERVACION.ToString()) + "'";

        //                    cmd.CommandText = "INSERT INTO [Muestra$A" + i.ToString().Trim() + ":Z" + (lstMuestra.Count + 1).ToString() + "] VALUES (" + insertar + ")";
        //                    cmd.ExecuteNonQuery();
        //                }
        //                //Cerramos la conexión
        //                conn.Close();
        //            }
        //        }

        //        result.success = true;
        //        result.msj = nombreFile;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.success = false;
        //        result.msj = ex.Message;
        //    }

        //    return result;
        //}

        //public static ListResult MuestraNoMaderable(string asCodNotificacion)
        //{
        //    ListResult result = new ListResult();

        //    try
        //    {
        //        CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE paramsCN = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
        //        CLogica exeCN = new CLogica();
        //        List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> lstCenso = new List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE>();

        //        paramsCN.COD_FISNOTI = asCodNotificacion;
        //        lstCenso = exeCN.RegMostrarPoaDetNoMadCensoLista_v3(paramsCN);
        //        var lstMuestra = (from dat in lstCenso
        //                          where (dat.NUM_MUESTRA == 1 && (bool)dat.ESTADO_MUESTRA == true)
        //                              || (dat.NUM_MUESTRA == 2 && (bool)dat.ESTADO_MUESTRA2 == true)
        //                              || (dat.NUM_MUESTRA == 3 && (bool)dat.ESTADO_MUESTRA3 == true)
        //                          select dat).ToList();

        //        string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
        //        string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
        //        string rutaExcel = rutaBase + nombreFile;
        //        string rutaExcelBase = rutaBase + "CN_Muestra_NoMaderable.xlsx";

        //        try
        //        {
        //            File.Delete(@rutaExcel);
        //            File.Copy(@rutaExcelBase, @rutaExcel);
        //        }
        //        catch (IOException ix)
        //        {
        //            throw new Exception(ix.Message);
        //        }

        //        //Creamos la cadena de conexión con el fichero excel
        //        OleDbConnectionStringBuilder cb = new OleDbConnectionStringBuilder();
        //        cb.DataSource = rutaExcel;
        //        if (Path.GetExtension(rutaExcel).ToUpper() == ".XLS")
        //        {
        //            cb.Provider = "Microsoft.Jet.OLEDB.4.0";
        //            cb.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=0;");
        //        }
        //        else if (Path.GetExtension(rutaExcel).ToUpper() == ".XLSX")
        //        {
        //            cb.Provider = "Microsoft.ACE.OLEDB.12.0";
        //            cb.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=0;");
        //        }

        //        using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
        //        {
        //            string insertar = "";
        //            int i = 1, ind = 1;
        //            //Abrimos la conexión
        //            conn.Open();
        //            //Creamos la ficha
        //            using (OleDbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandType = CommandType.Text;
        //                //Construyendo las Cabeceras
        //                foreach (var item in lstMuestra)
        //                {
        //                    insertar = "";
        //                    insertar = insertar + "'" + (ind++).ToString() + "'";
        //                    insertar = insertar + ",'" + item.DESC_ESPECIES + "'";
        //                    insertar = insertar + ",'" + item.NUM_POA.ToString() + "'";
        //                    insertar = insertar + ",'" + item.NUM_ESTRADA + "'";
        //                    insertar = insertar + ",'" + item.CODIGO + "'";
        //                    insertar = insertar + ",'" + item.DIAMETRO.ToString() + "'";
        //                    insertar = insertar + ",'" + item.ALTURA.ToString() + "'";
        //                    insertar = insertar + ",'" + item.PRODUCCION_LATAS.ToString() + "'";
        //                    insertar = insertar + ",'" + item.DESC_ECONDICION.ToString() + "'";
        //                    insertar = insertar + ",'" + item.ZONA.ToString() + "'";
        //                    insertar = insertar + ",'" + item.COORDENADA_ESTE.ToString() + "'";
        //                    insertar = insertar + ",'" + item.COORDENADA_NORTE.ToString() + "'";
        //                    insertar = insertar + ",'" + item.CODIGO_GPS.ToString() + "'";
        //                    insertar = insertar + ",'" + item.COD_SISTEMA.ToString() + "'";
        //                    insertar = insertar + ",'" + (item.OBSERVACION.Length > 255 ? item.OBSERVACION.ToString().Substring(0, 255) : item.OBSERVACION.ToString()) + "'";

        //                    cmd.CommandText = "INSERT INTO [Muestra$A" + i.ToString().Trim() + ":Z" + (lstMuestra.Count + 1).ToString() + "] VALUES (" + insertar + ")";
        //                    cmd.ExecuteNonQuery();
        //                }
        //                //Cerramos la conexión
        //                conn.Close();
        //            }
        //        }

        //        result.success = true;
        //        result.msj = nombreFile;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.success = false;
        //        result.msj = ex.Message;
        //    }

        //    return result;
        //}
    }
}