using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using Archivo = CapaEntidad.DOC.Archivo;

namespace SIGOFCv3.Helper
{
    public class Ftp
    {
        protected string fileDafult;
        protected string server;
        protected string user;
        protected string password;
        protected string dominio;
        System.Web.HttpContext curContext = System.Web.HttpContext.Current;


        public Ftp()
        {
            fileDafult = Convert.ToBase64String(System.IO.File.ReadAllBytes(curContext.Server.MapPath("~/Content/images/logo") + "\\arbol osinfor blanco con verde.png"));
            server = ConfigurationManager.AppSettings["FTPServer"].ToString();
            user = ConfigurationManager.AppSettings["FTPUser"].ToString();
            password = ConfigurationManager.AppSettings["FTPPassword"].ToString();
            dominio = ConfigurationManager.AppSettings["FTPDominio"].ToString();
        }

        public Archivo FtpFileUpload(string fullPath, string filePath, string concatServerUrl)
        {
            FtpWebRequest request;
            try
            {
                string requestUriString = server + concatServerUrl + filePath;
                request = WebRequest.Create(requestUriString) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(user, password);
                request.ConnectionGroupName = "group";
                using (FileStream fs = System.IO.File.OpenRead(fullPath))
                {
                    byte[] array = new byte[fs.Length];
                    fs.Read(array, 0, array.Length);
                    fs.Close();
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(array, 0, array.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
                return new Archivo
                {
                    mensaje = "OK",
                    validation = true,
                    path = requestUriString
                };
            }
            catch (Exception ex)
            {
                return new Archivo()
                {
                    mensaje = $"{ex.Source} \n {ex.Message} \n {ex.StackTrace}\n",
                    validation = false
                };
            }
        }

        private bool CheckIfFileExistsOnServer(string vFoto)
        {
            var request = (FtpWebRequest)WebRequest.Create(server + vFoto);
            request.Credentials = new NetworkCredential(user, password);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            FtpWebResponse ftpWebResponse;
            try
            {
                ftpWebResponse = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                ftpWebResponse = (FtpWebResponse)ex.Response;
                if (ftpWebResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
            }
            return false;
        }

        public List<string> ConvertstringToArray(string data, char split)
        {
            List<string> list = new List<string>();
            foreach (var z in data.Split(split))
                list.Add(z.ToUpper());
            return list;
        }

        public Archivo FTPaBase64(string vFile)
        {
            Archivo archivo = new Archivo();
            using (WebClient webClient = new WebClient())
            {
                webClient.Credentials = new NetworkCredential(user, password);
                if (!CheckIfFileExistsOnServer(vFile))
                {
                    archivo.file = Convert.FromBase64String(fileDafult);
                    archivo.encode64 = fileDafult;
                    archivo.validation = true;
                    archivo.mensaje = "No Existe El Archivo";
                    archivo.mineType = "image/png";
                    archivo.path = "No_Archivo.png";
                    return archivo;
                }
                byte[] C = webClient.DownloadData(server + vFile);
                archivo.file = C;
                archivo.encode64 = Convert.ToBase64String(C);
                archivo.validation = true;
                archivo.mensaje = "Se Obtuvo el Archivo";
                archivo.mineType = MimeTypeMap.GetMimeType(Path.GetExtension(vFile));
                archivo.path = vFile.Split(new[] { "___" }, StringSplitOptions.None).Last();
                return archivo;
            }
        }

        private static string ValidateBase64EncodedString(string inputText)
        {
            string stringToValidate = inputText;
            stringToValidate = stringToValidate.Replace('-', '+'); // 62nd char of encoding
            stringToValidate = stringToValidate.Replace('_', '/'); // 63rd char of encoding
            switch (stringToValidate.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: stringToValidate += "=="; break; // Two pad chars
                case 3: stringToValidate += "="; break; // One pad char
                default:
                    throw new System.Exception(
             "Illegal base64url string!");
            }

            return stringToValidate;
        }
    }
}