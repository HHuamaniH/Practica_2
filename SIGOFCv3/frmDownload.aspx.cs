using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIGOFCv3
{
    public partial class frmDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // int? tipoDocumentoId = int.Parse(Request["cboTipoComprobante"]);
            string nombreArchivo = Request["nombreArchivo"];
            string nombreArchivoOriginal = Request["nombreOriginal"];
            string opcion = Request["opcion"];
            string FilePath = "";
            if (opcion == "0")
            {  //archivos que ya estan registrado en la BD  
                FilePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/"), nombreArchivo);
            }
            else if (opcion == "1")
            {
                FilePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos/Modulo/Supervision/Itinerario/Temp/"), nombreArchivo);
            }
            else if (opcion == "2")
            {
                //probiene de ruta antigua
                String RutaBITACORAAntigua = "~/Archivos/Archivo_Bitacora/";
                FilePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath(RutaBITACORAAntigua), nombreArchivo);
            }
            //opcion oficio
            else if (opcion == "3")
            {
                FilePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/Temp/"), nombreArchivo);
            }
            else if (opcion == "4")
            {
                FilePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos/Modulo/Supervision/Oficio/"), nombreArchivo);
            }
            else if (opcion == "5") //para descargar archivos de origen coactiva - temporales
            {
                FilePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Archivos/Temporales/"), nombreArchivo);
            }
            if (FilePath != "")
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.ContentType = "application/download";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
                HttpContext.Current.Response.Charset = "";
                //string strFileName = oCEntBitacora.ListBitacoras[Index].ListInfoGeo[ListIndex].NOMBRE_ARCH + "."
                //    + oCEntBitacora.ListBitacoras[Index].ListInfoGeo[ListIndex].EXTENSION_ARCH;
                //strFileName = strFileName.Replace(" ", "");
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivoOriginal);
                HttpContext.Current.Response.TransmitFile(FilePath);
                //HttpContext.Current.Response.End();
                HttpContext.Current.Response.Flush();
            }
        }
    }
}