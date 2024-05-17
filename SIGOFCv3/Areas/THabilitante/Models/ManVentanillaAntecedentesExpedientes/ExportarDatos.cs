﻿using CapaEntidad.ViewModel;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using CEntidad = CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE;
using CLogica = CapaLogica.DOC.Log_ANTECEDENTE_EXPEDIENTE;

namespace SIGOFCv3.Areas.THabilitante.Models.ManVentanillaAntecedentesExpedientes
{
    public class ExportarDatos
    {
        public static ListResult RegistroUsuario(CEntidad request)
        {
            ListResult result = new ListResult();

            try
            {
                
                CLogica exeCap = new CLogica();

                List<Dictionary<string, string>> olResult = exeCap.ReporteExcel(request);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "PlantillaAntecedentes.xlsx";

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
                                insertar = insertar + ",'" + (itemPart["DOC_REFERENCIA"].Trim() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["OBSERVACION"].Trim() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["RESOLUCION_POA"].Trim() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["FFECDOCUMENTO"].Trim() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUM_THABILITANTE"].Trim() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["DESCRIPCION"].Trim() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["CCODIFICACION"].Trim() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["FECHA_SITD"].Trim() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["CNOMOFICINA"].Trim() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ESTADO_AEXPEDIENTE"].Trim() ?? "") + "'";

                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olResult.Count + 1).ToString() + "] VALUES (" + insertar + ")";
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