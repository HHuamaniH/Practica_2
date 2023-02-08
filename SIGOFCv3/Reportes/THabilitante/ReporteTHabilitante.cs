using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
namespace SIGOFCv3.Reportes.THabilitante
{
    public class ReporteTHabilitante
    {
        public static ListResult GenerarReporteVerticeTH(string COD_THABILITANTE)
        {
            ListResult result = new ListResult();
            try
            {
                Log_THABILITANTE logTH = new Log_THABILITANTE();
                List<Ent_THABILITANTE> listadoVertice = logTH.ListarVerticeTHabilitante(COD_THABILITANTE);
                int i = 1;
                String insertar = "";
                String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";
                nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = RutaReporteSeguimiento + nombreFile;
                //File.Delete(rutaExcel);
                File.Copy(RutaReporteSeguimiento + "THabilitanteVertice.xlsx", rutaExcel); //pues si es mover 
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
                        foreach (var listaInf in listadoVertice)
                        {
                            insertar = "";
                            insertar = insertar + "'" + listaInf.VERTICE.Trim() + "'";
                            insertar = insertar + ",'" + listaInf.ZONA.Trim() + "'";
                            insertar = insertar + ",'" + listaInf.COORDENADA_ESTE.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.COORDENADA_NORTE.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.OBSERVACION + "'";
                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (listadoVertice.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                            cmd.ExecuteNonQuery();
                        }
                        //Cerramos la conexión
                        conn.Close();
                    }
                }
                //File.Delete(rutaExcel);  
                List<string> lstResult = new List<string> { nombreFile };
                result.AddResultado("Ok", true, lstResult);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
    }
}