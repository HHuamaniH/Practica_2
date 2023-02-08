using System.Web.Mvc;

namespace SIGOFCv3.Helper
{
    public class BinaryContentResultDowload : ActionResult
    {
        public BinaryContentResultDowload()
        { }

        public string ContentType { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {

            context.HttpContext.Response.ClearContent();
            context.HttpContext.Response.ContentType = ContentType;

            context.HttpContext.Response.AddHeader("content-disposition",

                                                   "attachment; filename=" + FileName);

            context.HttpContext.Response.BinaryWrite(Content);
            context.HttpContext.Response.End();
        }
    }
}