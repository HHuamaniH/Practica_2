using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using CEntidad = CapaEntidad.DOC.Ent_WS_OSINFOR;
using CLogica = CapaLogica.DOC.Log_WS_OSINFOR;


/// <summary>
/// Descripción breve de WSDataOSINFOR
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WSDataOSINFOR : System.Web.Services.WebService
{
    CLogica oCLogica = new CLogica();
    public autenticaUser usuario;

    public WSDataOSINFOR()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    [SoapHeader("usuario")]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string getlistaSupervisados(String varBusqueda)
    {
        List<Object> resultado = new List<object>();
        if (usuario != null)
        {
            if (usuario.IsValid())
            {
                resultado = devuelveSupervisiones(varBusqueda, usuario.userName);
            }
            else
            {
                resultado.Add("Error en la autenticación");
            }
        }
        else
        {
            resultado.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(resultado)); ;
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string getlistaSupervisados2(String usuario, String password, String varBusqueda)
    {
        autenticaUser usuarioBody = new autenticaUser();
        usuarioBody.userName = usuario;
        usuarioBody.password = password;
        List<Object> resultado = new List<object>();
        if (usuarioBody != null)
        {
            if (usuarioBody.IsValid())
            {
                resultado = devuelveSupervisiones(varBusqueda, usuario);
            }
            else
            {
                resultado.Add("Error en la autenticación");
            }
        }
        else
        {
            resultado.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(resultado));
    }


    private List<Object> devuelveSupervisiones(String varBusqueda, String Usuario)
    {

        List<Object> cSupervisiones = new List<Object>();
        List<CEntidad> listSupervisiones = new List<CEntidad>();
        CEntidad oCampos = new CEntidad();
        oCampos.BusCriterio = "SUPERVISIONES";
        oCampos.BusValor = varBusqueda.Trim();
        oCampos.USUARIO_LOGIN = "";
        //listSupervisionesregAccionReporteGTF("SEARCH", "CRITERIO=" + BusCriterio.Trim() + ";SEARCH_STRING=" + txtManBuscar.Text.Trim());
        listSupervisiones = oCLogica.RegMostrarSupervisiones(oCampos);
        foreach (var fila in listSupervisiones)
        {
            cSupervisiones.Add(new
            {
                COD_THABILITANTE = fila.COD_THABILITANTE,
                NUM_THABILITANTE = fila.NUM_THABILITANTE,
                TITULAR = fila.TITULAR,
                MODALIDAD = fila.MODALIDAD,
                CADUCADO_TH = fila.CADUCADO_TH,
                NUM_POA = fila.NUM_POA,
                NOMBRE_POA = fila.NOMBRE_POA,
                ARESOLUCION_NUM = fila.ARESOLUCION_NUM,

                COD_INFORME = fila.COD_INFORME,
                NUM_INFORME = fila.NUM_INFORME,
                FECHA_SUPERVISION_INI = fila.FECHA_SUPERVISION_INI,
                FECHA_SUPERVISION_FIN = fila.FECHA_SUPERVISION_FIN,

                NUM_RESOLUCION_INI = fila.NUM_RESOLUCION_INI_1,
                FECHA_EMISION_INI = fila.FECHA_EMISION_INI_1,
                MED_CAU = fila.MED_CAU_INI_1,
                INFRACCIONES_INI = fila.INFRACCIONES_INI_1,
                NUM_RESOLUCION_AMP = fila.NUM_RESOLUCION_AMP,
                FECHA_EMISION_AMP = fila.FECHA_EMISION_AMP,
                INFRACCIONES_AMP = fila.INFRACCIONES_AMP,
                NUM_RESOLUCION_VAIMP = fila.NUM_RESOLUCION_VAIMP,
                FECHA_EMISION_VAIMP = fila.FECHA_EMISION_VAIMP,
                INFRACCIONES_VAIMP = fila.INFRACCIONES_VAIMP,
                NUM_RESOLUCION_TER = fila.NUM_RESOLUCION_TER_1,
                FECHA_EMISION_TER = fila.FECHA_EMISION_TER_1,
                DETER_TER = fila.DETER_TER_1,
                MONTO_MULTA_TER = fila.MONTO_MULTA_TER_1,
                AMONESTACION = fila.AMONESTACION_TER_1,
                CADUCIDAD = fila.CADUCIDAD_TER_1,
                MED_PRECAU = fila.MED_PRECAU_TER_1,
                MED_CORREC = fila.MED_CORREC_TER_1,
                INFRACCIONES_TER = fila.INFRACCIONES_TER_1,
                NUM_RESOLUCION_RECONS = fila.NUM_RESOLUCION_RECONS,
                FECHA_EMISION_RECONS = fila.FECHA_EMISION_RECONS,
                DETER_RECONS = fila.DETER_RECONS,
                LEV_CADUCIDAD_RECONS = fila.LEV_CADUCIDAD_RECONS,
                CAMBIO_MULTA_RECONS = fila.CAMBIO_MULTA_RECONS,
                MONTO_MULTA_RECONS = fila.MONTO_MULTA_RECONS,
                NUM_RESOLUCION_RECTI = fila.NUM_RESOLUCION_RECTI,
                FECHA_EMISION_RECTI = fila.FECHA_EMISION_RECTI,
                MOTIVO_RECTI = fila.MOTIVO_RECTI,
                MONTO_MULTA_RECTI = fila.MONTO_MULTA_RECTI,
                NUM_RESOLUCION_TFFS = fila.NUM_RESOLUCION_TFFS_1,
                FECHA_EMISION_TFFS = fila.FECHA_EMISION_TFFS_1,
                ESTADO_PAU = fila.ESTADO_PAU,
                FECHA_ACTUALIZACION = fila.FECHA_ACTUALIZACION,
            });
        }

        return cSupervisiones;
    }


    [WebMethod]
    [SoapHeader("usuario")]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string getlistaTHCaducados(String varBusqueda)
    {
        List<Object> resultado = new List<object>();
        if (usuario != null)
        {
            if (usuario.IsValid())
            {
                resultado = devuelveCaducados(varBusqueda, usuario.userName);
            }
            else
            {
                resultado.Add("Error en la autenticación");
            }
        }
        else
        {
            resultado.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(resultado));
    }
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string getlistaTHCaducados2(String usuario, String password, String varBusqueda)
    {
        autenticaUser usuarioBody = new autenticaUser();
        usuarioBody.userName = usuario;
        usuarioBody.password = password;
        List<Object> resultado = new List<object>();
        if (usuario != null)
        {
            if (usuarioBody.IsValid())
            {
                resultado = devuelveCaducados(varBusqueda, usuario);
            }
            else
            {
                resultado.Add("Error en la autenticación");
            }
        }
        else
        {
            resultado.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(resultado));
    }
    private List<Object> devuelveCaducados(String varBusqueda, String Usuario)
    {
        List<Object> cCaducados = new List<Object>();
        List<CEntidad> listCaducadosTH = new List<CEntidad>();
        CEntidad oCampos = new CEntidad();
        oCampos.BusCriterio = "CADUCADOS";
        oCampos.BusValor = varBusqueda.Trim();
        //listSupervisionesregAccionReporteGTF("SEARCH", "CRITERIO=" + BusCriterio.Trim() + ";SEARCH_STRING=" + txtManBuscar.Text.Trim());
        // listCaducadosTH = oCLogica.RegTHCaducados(oCampos);
        foreach (var fila in listCaducadosTH)
        {
            cCaducados.Add(new
            {
                COD_THABILITANTE = fila.COD_THABILITANTE,
                NUM_THABILITANTE = fila.NUM_THABILITANTE,
                TITULAR = fila.TITULAR,
                MODALIDAD = fila.MODALIDAD
            });
        }
        return cCaducados;
    }
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string getlistaTHs(String usuario, String password)
    {
        autenticaUser usuarioBody = new autenticaUser();
        usuarioBody.userName = usuario;
        usuarioBody.password = password;
        List<Object> THs = new List<Object>();
        if (usuario != null)
        {
            if (usuarioBody.IsValid())
            {
                List<CEntidad> listCaducadosTH = new List<CEntidad>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusCriterio = "THS_SUPERVISADOS";
                oCampos.BusValor = "";
                oCampos.USUARIO_LOGIN = usuario;
                //listSupervisionesregAccionReporteGTF("SEARCH", "CRITERIO=" + BusCriterio.Trim() + ";SEARCH_STRING=" + txtManBuscar.Text.Trim());
                listCaducadosTH = oCLogica.RegTHs(oCampos);
                foreach (var fila in listCaducadosTH)
                {
                    THs.Add(new
                    {
                        //COD_THABILITANTE = fila.COD_THABILITANTE,
                        NUM_THABILITANTE = fila.NUM_THABILITANTE,
                        //TITULAR = fila.TITULAR,
                        FECHA_ACTUALIZACION = fila.FECHA_ACTUALIZACION
                    });
                }
            }
            else
            {
                THs.Add("Error en la autenticación");
            }
        }
        else
        {
            THs.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(THs)); ;
    }


}
