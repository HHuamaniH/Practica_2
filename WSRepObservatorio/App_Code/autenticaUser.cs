using System;
using CEntidad = CapaEntidad.GENE.Ent_USUARIO_CUENTA;
using CLogica = CapaLogica.GENE.Log_USUARIO_CUENTA;
//using CEntidad = CapaEntidad.GENE.Ent_USUARIO_CUENTA;

/// <summary>
/// Descripción breve de autenticaUser
/// </summary>
public class autenticaUser : System.Web.Services.Protocols.SoapHeader
{

    CLogica oCLogUsuario = new CLogica();
    CEntidad oCEntUsuario = new CEntidad();

    public string userName { get; set; }
    public string password { get; set; }

    public bool IsValid()
    {
        try
        {
            oCEntUsuario.USUARIO_LOGIN = userName;
            oCEntUsuario.USUARIO_CONTRASENA = password;
            oCEntUsuario.COD_SMODULOS = "0000001";
            oCEntUsuario.OUTPUTPARAM01 = "";
            oCEntUsuario.OUTPUTPARAM02 = "";
            // oCLogUsuario.RegLoginValidando(oCEntUsuario);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public autenticaUser()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}