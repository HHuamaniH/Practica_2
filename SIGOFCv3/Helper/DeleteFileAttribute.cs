using System.Web.Mvc;

namespace SIGOFCv3.Helper
{
    public class DeleteFileAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Flush();
            string filePath = (filterContext.Result as FilePathResult).FileName;
            //eliminar el archivo despues de desacargar
            System.IO.File.Delete(filePath);
        }
    }
}