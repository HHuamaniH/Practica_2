using CapaEntidad.DOC;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidadUC = CapaEntidad.GENE.Ent_USUARIO_CUENTA;

namespace SIGOFCv3.Helper
{
    public class HelperSigo
    {
        public static string GetUrlLocal()
        {
            var request = HttpContext.Current.Request;
            var urlHelper = new UrlHelper(request.RequestContext);
            return request.Url.GetLeftPart(UriPartial.Authority) + urlHelper.Content("~");
        }
        public static IEnumerable<SelectListItem> LLenarCombos(List<Ent_BUSQUEDA> lista, string idSelect, bool vMostraPalabra_Seleccionar = false)
        {
            var listItem = from tmpLista in lista
                           select new SelectListItem
                           {
                               Selected = (tmpLista.CODIGO == idSelect) ? true : false,
                               Text = tmpLista.DESCRIPCION,
                               Value = tmpLista.CODIGO
                           };
            //var s= lista.Select(c => new SelectListItem { Value = c.CODIGO, Text = c.DESCRIPCION });
            return listItem;
        }

        public static String RevisaArchivos(String ruta, String busqueda)
        {
            String retorno = "";
            if (Directory.Exists(ruta))
            {
                string[] archivos = Directory.GetFiles(ruta, busqueda);
                if (archivos.Length == 1)
                {
                    FileInfo fi = new FileInfo(archivos[0]);
                    retorno = fi.Name;
                }
                else if (archivos.Length > 1)
                {
                    throw new Exception("Existe más de un archivo con el mismo nombre");
                }
                else if (archivos.Length == 0)
                {
                    throw new Exception("No existe el archivo seleccionado");
                }
            }
            else
            {
                return retorno;
            }
            return retorno;
        }
        public static String MesNombre(Int32 NumMes)
        {
            String MesNombre = "";
            switch (NumMes)
            {
                case 1:
                    MesNombre = "Enero";
                    break;
                case 2:
                    MesNombre = "Febrero";
                    break;
                case 3:
                    MesNombre = "Marzo";
                    break;
                case 4:
                    MesNombre = "Abril";
                    break;
                case 5:
                    MesNombre = "Mayo";
                    break;
                case 6:
                    MesNombre = "Junio";
                    break;
                case 7:
                    MesNombre = "Julio";
                    break;
                case 8:
                    MesNombre = "Agosto";
                    break;
                case 9:
                    MesNombre = "Setiembre";
                    break;
                case 10:
                    MesNombre = "Octubre";
                    break;
                case 11:
                    MesNombre = "Noviembre";
                    break;
                case 12:
                    MesNombre = "Diciembre";
                    break;
            }
            return MesNombre;
        }
        public static DataTable GetDatosExcel(HttpPostedFileBase file, string rutaDestino)
        {
            String ArchivoExtencion = Path.GetExtension(file.FileName).ToLower();
            //Validando Datos    
            String extencion = Path.GetExtension(ArchivoExtencion).Replace(".", "").ToLower();
            if (extencion != "xlsx" && extencion != "xls")
            {
                throw new Exception("Seleccione un archivo de excel");
            }
            String ArchivoNombreOriginal = file.FileName;
            String ArchivoNombreCopiar = String.Format("Excel{0}{1}", DateTime.Now.Ticks.ToString(), ArchivoExtencion);
            string pathDestino = Path.Combine(rutaDestino, ArchivoNombreCopiar);
            //guardando arrchivo
            file.SaveAs(pathDestino);
            //Validando hojas
            var LibroHojas = ExcelExtraeHojas(pathDestino);
            //
            if (LibroHojas.Count == 0)
            {
                throw new Exception("El Libro actual no contiene Hojas");
            }
            //else if (LibroHojas.Count > 1)
            //{
            //    throw new Exception("El Libro actual debe contener solo una Hojas");
            //}
            return ExcelLeerDatos(pathDestino, "Datos$", true);
        }
        #region "Conexion Excel"
        public static List<string> ExcelExtraeHojas(String ArchivoRutaDestino)
        {
            List<string> Resultado = new List<string>();
            String CadenaConexion = ExcelCadenaConexion(ArchivoRutaDestino, false);
            using (OleDbConnection cn = new OleDbConnection(CadenaConexion))
            {
                cn.Open();
                DataTable dbSchema = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string hoja = "";
                foreach (DataRow row in dbSchema.Rows)
                {
                    hoja = row.Field<String>("TABLE_NAME");

                    if (hoja.EndsWith("$"))
                        if (!hoja.StartsWith("hOculto"))
                            Resultado.Add(row.Field<String>("TABLE_NAME"));
                }
            }
            return Resultado;
        }
        public static String ExcelCadenaConexion(String ArchivoRuta, Boolean ColumnasCabezera)
        {
            try
            {
                String CadenaConexion = "";
                //Validando
                if (Archivo_Existe(ArchivoRuta) == false)
                {
                    throw new Exception("Archivo no Existe");
                }
                //
                String ArchivoExtencion = (Path.GetExtension(ArchivoRuta)).Replace(".", "").ToLower();
                String ArchivoCabezera = (ColumnasCabezera == true ? "HDR=YES" : "HDR=NO");
                if (ArchivoExtencion == "xlsx")
                {
                    CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ArchivoRuta + ";Extended Properties='Excel 12.0;" + ArchivoCabezera + ";'";
                }
                else if (ArchivoExtencion == "xls")
                {
                    CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ArchivoRuta + ";Extended Properties='Excel 8.0;" + ArchivoCabezera + "'";
                }
                return CadenaConexion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ExcelLeerDatos(String ArchivoRuta, String HojaNombre, Boolean ColumnasCabezera)
        {
            try
            {
                String CadenaConexion = ExcelCadenaConexion(ArchivoRuta, ColumnasCabezera);
                String SentenciaSQL = "SELECT * FROM [" + HojaNombre + "]";
                //
                using (OleDbConnection cn = new OleDbConnection(CadenaConexion))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(SentenciaSQL, cn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.SelectCommand.CommandType = CommandType.Text;
                            da.SelectCommand.CommandTimeout = 2000;
                            da.Fill(ds, "Excel");
                            return ds.Tables["Excel"];
                        }
                    }
                }
                //eliminando archivo
                //if(Archivo_Existe(ArchivoRuta))
                //{
                //    File.Delete(ArchivoRuta);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Boolean Archivo_Existe(String RutaNombre)
        {
            Boolean ReturnValue = File.Exists(RutaNombre);
            return ReturnValue;
        }
        public static string GetColum(Int32 value)
        {
            string column = string.Empty;
            switch (value)
            {
                case 1: column = "A"; break;
                case 2: column = "B"; break;
                case 3: column = "C"; break;
                case 4: column = "D"; break;
                case 5: column = "E"; break;
                case 6: column = "F"; break;
                case 7: column = "G"; break;
                case 8: column = "H"; break;
                case 9: column = "I"; break;
                case 10: column = "J"; break;
                case 11: column = "K"; break;
                case 12: column = "L"; break;
                case 13: column = "M"; break;
                case 14: column = "N"; break;
                case 15: column = "O"; break;
                case 16: column = "P"; break;
                case 17: column = "Q"; break;
                case 18: column = "R"; break;
                case 19: column = "S"; break;
                case 20: column = "T"; break;
                case 21: column = "U"; break;
                case 22: column = "V"; break;
                case 23: column = "W"; break;
                case 24: column = "X"; break;
                case 25: column = "Y"; break;
                case 26: column = "Z"; break;
                case 27: column = "AA"; break;
                case 28: column = "AB"; break;
                case 29: column = "AC"; break;
                case 30: column = "AD"; break;
                case 31: column = "AE"; break;
                case 32: column = "AF"; break;
                case 33: column = "AG"; break;
                case 34: column = "AH"; break;
                case 35: column = "AI"; break;
                case 36: column = "AJ"; break;
                case 37: column = "AK"; break;
                case 38: column = "AL"; break;
                case 39: column = "AM"; break;
                case 40: column = "AN"; break;
                case 41: column = "AO"; break;
                case 42: column = "AP"; break;
                case 43: column = "AQ"; break;
                case 44: column = "AR"; break;
                case 45: column = "AS"; break;
                case 46: column = "AT"; break;
                case 47: column = "AU"; break;
                case 48: column = "AV"; break;
                case 49: column = "AW"; break;
                case 50: column = "AX"; break;
                case 51: column = "AY"; break;
                case 52: column = "AZ"; break;
                case 53: column = "BA"; break;
                case 54: column = "BB"; break;
                case 55: column = "BC"; break;
                case 56: column = "BD"; break;
                case 57: column = "BE"; break;
                case 58: column = "BF"; break;
                case 59: column = "BG"; break;
                case 60: column = "BH"; break;
                case 61: column = "BI"; break;
                case 62: column = "BJ"; break;
                case 63: column = "BK"; break;
                case 64: column = "BL"; break;
                case 65: column = "BM"; break;
                case 66: column = "BN"; break;
                case 67: column = "BO"; break;
                case 68: column = "BP"; break;
                case 69: column = "BQ"; break;
                case 70: column = "BR"; break;
                case 71: column = "BS"; break;
                case 72: column = "BT"; break;
                case 73: column = "BU"; break;
                case 74: column = "BV"; break;
                case 75: column = "BW"; break;
                case 76: column = "BX"; break;
                case 77: column = "BY"; break;
                case 78: column = "BZ"; break;
                case 79: column = "CA"; break;
                case 80: column = "CB"; break;
                case 81: column = "CC"; break;
                case 82: column = "CD"; break;
                case 83: column = "CE"; break;
                case 84: column = "CF"; break;
                case 85: column = "CG"; break;
                case 86: column = "CH"; break;
                case 87: column = "CI"; break;
                case 88: column = "CJ"; break;
                case 89: column = "CK"; break;
                case 90: column = "CL"; break;
                case 91: column = "CM"; break;
                case 92: column = "CN"; break;
                case 93: column = "CO"; break;
                case 94: column = "CP"; break;
                case 95: column = "CQ"; break;
                case 96: column = "CR"; break;
                case 97: column = "CS"; break;
                case 98: column = "CT"; break;
                case 99: column = "CU"; break;
                case 100: column = "CV"; break;
                case 101: column = "CW"; break;
                case 102: column = "CX"; break;
                case 103: column = "CY"; break;
                case 104: column = "CZ"; break;
                case 105: column = "DA"; break;
                case 106: column = "DB"; break;
                case 107: column = "DC"; break;
                case 108: column = "DD"; break;
                case 109: column = "DE"; break;
                case 110: column = "DF"; break;
                case 111: column = "DG"; break;
                case 112: column = "DH"; break;
                case 113: column = "DI"; break;
                case 114: column = "DJ"; break;
                case 115: column = "DK"; break;
                case 116: column = "DL"; break;
                case 117: column = "DM"; break;
                case 118: column = "DN"; break;
                case 119: column = "DO"; break;
            }
            return column;
        }
        #endregion

        public static VM_Menu_Rol GetRol(string _grupo, string _menu)
        {
            CEntidadUC result = new CEntidadUC();
            var data = ModelSession.GetSession();
            VM_Menu_Rol mr = new VM_Menu_Rol();
            if (data != null)
            {
                result = (CEntidadUC)data[0];
                bool _break = false;
                if (result.ListUCDMMENU.Count > 0)
                {
                    mr.PERFIL = result.COD_SPERFIL;
                    foreach (var item in result.ListUCDMMENU)
                    {
                        if (item.ListMENUGRUPO.Count > 0)
                        {
                            foreach (var row in item.ListMENUGRUPO)
                            {
                                if (row.GRUPO == _grupo)//"MODULO TITULO HABILITANTE"
                                {
                                    if (row.ListMENUPADRE.Count > 0)
                                    {
                                        foreach (var fila in row.ListMENUPADRE)
                                        {
                                            if (fila.ListMENUMENU.Count > 0)
                                            {
                                                foreach (var menu in fila.ListMENUMENU)
                                                {
                                                    if (menu.MENU_HIJO == _menu)//"Título Habilitante"
                                                    {
                                                        mr.NCODROL = menu.NCODROL;
                                                        mr.VALIAS = menu.VALIASROL;
                                                        _break = true;
                                                    }
                                                    if (menu.MENU_HIJO == "")
                                                    {
                                                        if (menu.MENU_PADRE == _menu)//"Título Habilitante"
                                                        {
                                                            mr.NCODROL = menu.NCODROL;
                                                            mr.VALIAS = menu.VALIASROL;
                                                            _break = true;
                                                        }
                                                    }

                                                    if (_break) break;

                                                }
                                            }
                                            if (_break) break;
                                        }
                                    }
                                    if (_break) break;

                                }
                                if (_break) break;
                            }
                        }
                    }


                }

            }
            return mr;
        }
    }

}