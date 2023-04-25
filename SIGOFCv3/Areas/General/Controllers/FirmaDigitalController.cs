using iTextSharp.text;
using iTextSharp.text.pdf;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.General.Controllers
{
    [RequiredAuthenticationFilter(Check = false)]
    public class FirmaDigitalController : Controller
    {
        public string UrlBase {
            get {
                return string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            }
        }

        public string PathInvoker {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["pathInvoker"];
            }
        }

        [HttpGet]
        public PartialViewResult getModal()
        {
            return PartialView("~/Areas/General/Views/FirmaDigital/_FirmaModal.cshtml");
        }

        [HttpGet]
        public string getArguments(string name)
        {
            return string.Format("{0}.pdf", string.IsNullOrEmpty(name) ? Guid.NewGuid().ToString() : name);
        }

        [HttpPost]
        public string postArguments(InvokerEntity obj)
        {
            var data = new Dictionary<string, object>();
            data["app"] = "pdf";
            data["clientId"] = "C055ro760vqfrRnSA4wqp9I-R0w";
            data["clientSecret"] = "p4C-cDBenxvDHLSrAZ9P";
            data["idFile"] = "001";
            data["type"] = obj.type;
            data["protocol"] = "S"; /*T=http, S=https (SE RECOMIENDA HTTPS)*/
            data["fileDownloadUrl"] = obj.fileDownloadUrl ?? ""; // Si type = W, es obligatorio para indicar el lugar de donde descargar el documento
            //data["fileDownloadLogoUrl"] = string.Format("{0}{1}", this.UrlBase, "content/images/logo/osinfor.png");
            data["fileDownloadStampUrl"] = string.Format("{0}{1}{2}", this.UrlBase, "content/images/logo/", obj.logo ?? "osinfor-logo.png");
            data["fileUploadUrl"] = string.Format("{0}General/FirmaDigital/upload?folder={1}", this.UrlBase, obj.folder ?? this.PathInvoker);
            data["contentFile"] = "doc_signature.pdf";
            data["reason"] = obj.reason;
            data["isSignatureVisible"] = "true";
            data["stampAppearanceId"] = "0";
            data["pageNumber"] = obj.pageNumber;
            data["posx"] = obj.posx;
            data["posy"] = obj.posy;
            data["fontSize"] = "7";
            data["dcfilter"] = ""; // ".*FIR.*|.*FAU.*";
            data["timestamp"] = "false";
            data["outputFile"] = obj.outputFile; //"firmado[R].pdf";
            data["maxFileSize"] = "104857600";

            var serializer = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serializer));
        }
        [HttpPost]
        public void upload(string folder)
        {
            var file = Request.Files["001"];

            if (file != null)
            {
                var path = Server.MapPath(string.Format("~/{0}", folder));
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                var filename = System.IO.Path.Combine(path, file.FileName);

                if (System.IO.File.Exists(filename)) System.IO.File.Delete(filename);

                file.SaveAs(filename);
            }
        }

        [HttpPost]
        public ActionResult PdfExtractPages(string sourcePdfPath, int pageNumber)
        {
            // Intialize a new PdfReader instance with the contents of the source Pdf file:
            sourcePdfPath = Server.MapPath(string.Format("~/{0}", sourcePdfPath));

            if (!System.IO.File.Exists(sourcePdfPath))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Archivo no encontrado");
            }

            PdfReader reader = new PdfReader(sourcePdfPath);

            int pageCount = reader.NumberOfPages;

            if (pageNumber > pageCount)
            {
                pageNumber = pageCount;
            }

            using (var ms = new MemoryStream())
            {
                // Capture the correct size and orientation for the page:
                Document document = new Document(reader.GetPageSizeWithRotation(pageNumber));

                //PdfWriter writer = PdfWriter.GetInstance(document, ms);
                //writer.CloseStream = false;

                PdfCopy copy = new PdfCopy(document, ms) { CloseStream = false };

                //string outputFile = @"C:\\pagina.pdf";
                //PdfCopy copy = new PdfCopy(document, new FileStream(outputFile, FileMode.Create));

                document.Open();

                // Extract the desired page number                    
                copy.AddPage(copy.GetImportedPage(reader, pageNumber));

                document.Close();
                reader.Close();

                //return ms.GetBuffer();
                //return Convert.ToBase64String(ms.ToArray());
                string page = Convert.ToBase64String(ms.ToArray());
                return Json(new { page, pageCount });
            }
        }

        public string UrlBaseTest()
        {
            return this.UrlBase;
        }
    }

    public class InvokerEntity
    {
        public string type { get; set; }
        public string fileDownloadUrl { get; set; }
        public string reason { get; set; }
        public int pageNumber { get; set; }
        public int posx { get; set; }
        public int posy { get; set; }
        public string outputFile { get; set; }
        public string logo { get; set; }
        public string folder { get; set; }
    }
}