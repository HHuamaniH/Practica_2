using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using CEntidad = CapaEntidad.DOC.Ent_CAPACITACION;
using CLogica = CapaLogica.DOC.Log_CAPACITACION;

namespace SIGOFCv3.Areas.Capacitacion.Models.ManCapacitacion
{
    public class ExportarDatos
    {
        /// <summary>
        /// Exportar registro de capacitaciones
        /// </summary>
        /// <param name="asCodUsuario">Código del usuario que realiza la consulta</param>
        /// <param name="asTipoCapacitacion">[CAPACITACION,OTROS_EVENTOS]</param>
        /// <returns></returns>
        public static ListResult RegistroUsuario(string asCodUsuario, string asTipoCapacitacion)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                CLogica exeCap = new CLogica();
                paramCap.TIPO_REPORTE = "REGISTRO_USUARIO";
                paramCap.COD_CAPATIPO = asTipoCapacitacion == "OTROS_EVENTOS" ? "0000006" : "";
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = exeCap.ReportesCapacitacion(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "CAPACITACION_Reg_Usu.xlsx";

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
                        string insertar = "", campo = "";
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
                                insertar = insertar + ",'" + (itemPart["COD_CAPACITACION"] ?? "") + "'";
                                campo = (itemPart["NOMBRE"] ?? "");
                                insertar = insertar + ",'" + (campo.Length > 254 ? campo.Substring(0, 254) : campo) + "'";
                                insertar = insertar + ",'" + (itemPart["TIPO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ANIO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["FECHA_INICIO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["FECHA_FIN"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["DURACION"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["SUMA_POI"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["METODOLOGIA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ORGANIZADOR"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["OD"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["N_PARTICIPANTES"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["N_REGISTRADOS"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["N_MASCULINO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["N_FEMENINO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["DEPARTAMENTO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["PROVINCIA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["DISTRITO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["LUGAR"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["SECTOR"] ?? "") + "'";
                                campo = (itemPart["PUBLICO_OBJETIVO"] ?? "");
                                insertar = insertar + ",'" + (campo.Length > 254 ? campo.Substring(0, 254) : campo) + "'";
                                insertar = insertar + ",'" + (itemPart["ZONA_UTM"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["CESTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["CNORTE"] ?? "") + "'";
                                campo = (itemPart["TEMA"] ?? "");
                                insertar = insertar + ",'" + (campo.Length > 254 ? campo.Substring(0, 254) : campo) + "'";
                                insertar = insertar + ",'" + (itemPart["MARCO_COVENIO"] ?? "") + "'";
                                campo = (itemPart["INSTITUCION_CONVENIO"] ?? "");
                                insertar = insertar + ",'" + (campo.Length > 254 ? campo.Substring(0, 254) : campo) + "'";
                                campo = (itemPart["COMUNIDAD_NATIVA"] ?? "");
                                insertar = insertar + ",'" + (campo.Length > 254 ? campo.Substring(0, 254) : campo) + "'";
                                campo = (itemPart["ETNIA"] ?? "");
                                insertar = insertar + ",'" + (campo.Length > 254 ? campo.Substring(0, 254) : campo) + "'";
                                campo = (itemPart["FINANCIA"] ?? "");
                                insertar = insertar + ",'" + (campo.Length > 254 ? campo.Substring(0, 254) : campo) + "'";
                                insertar = insertar + ",'" + (itemPart["USUARIO_REGISTRO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["FECHA_REGISTRO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ESTADO_CALIDAD"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["USUARIO_CONTROL"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["FECHA_CONTROL"] ?? "") + "'";
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
    }
}