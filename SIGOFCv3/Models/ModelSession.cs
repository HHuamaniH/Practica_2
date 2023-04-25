using CapaEntidad.GENE;
using System.Collections.Generic;
using System.Web;
namespace SIGOFCv3.Models
{
    public static class ModelSession
    {
        private static string keySession = "LoginUsuario";

        /// <summary>
        /// Iniciamos la session de un determinado usuario
        /// </summary>
        public static void Initialize(List<Ent_USUARIO_CUENTA> listLogin)
        {
            if (listLogin.Count > 0)
            {
                string[] perfiles = listLogin[0].COD_SPERFILS.Split(',');
                if (perfiles.Length == 2)
                {
                    listLogin[0].COD_SPERFIL = perfiles[1];
                }
            }

            HttpContext.Current.Session[keySession] = listLogin;
        }
        /// <summary>
        /// Obtiene la session del usuario
        /// </summary>
        /// <returns></returns>
        public static List<Ent_USUARIO_CUENTA> GetSession()
        {
            return (List<Ent_USUARIO_CUENTA>)HttpContext.Current.Session[keySession];
        }
        /// <summary>
        /// Evalua si existe la session
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            return (HttpContext.Current.Session[keySession] == null) ? false : true;
        }
        /// <summary>
        /// Realiza el logout del usuario
        /// </summary>
        public static void Logout()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session[keySession] = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
    }
}