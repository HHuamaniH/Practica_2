using SIGOFCv3.Helper;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.General.Controllers
{
    [RequiredAuthenticationFilter(Check = false)]
    public class EditorController : Controller
    {
        public string UrlBase {
            get {
                return string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            }
        }

        public string PathCkeditor {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["pathCkeditor"];
            }
        }

        public JsonResult ckEditor()
        {
            //string command = Request["command"];

            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase files = Request.Files;

                HttpPostedFileBase file = files[0];
                string extension = Path.GetExtension(file.FileName);
                string name = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), extension);

                //Configuracion base
                string folderBase = this.PathCkeditor;

                string folder = Server.MapPath("~/" + folderBase);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                file.SaveAs(folder + "/" + name);

                string url = string.Format("{0}{1}/{2}", this.UrlBase, folderBase, name);

                return Json(new { fileName = name, uploaded = 1, url = url });
            }

            return Json(new { error = new { message = "No hay imágenes para cargar" } });
        }
    }
}