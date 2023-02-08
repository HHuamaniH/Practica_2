using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using CEntBusqueda = CapaEntidad.DOC.Ent_BUSQUEDA;
using CEntEspecies = CapaEntidad.GENE.Ent_ESPECIES;
using CEntInforme = CapaEntidad.DOC.Ent_INFORME;
using CEntMuestra = CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE;
using CEntWSOSINFOR = CapaEntidad.DOC.Ent_WS_OSINFOR;
using CLogBusqueda = CapaLogica.DOC.Log_BUSQUEDA;
using CLogEspecies = CapaLogica.GENE.Log_ESPECIES;
using CLogInforme = CapaLogica.DOC.Log_INFORME;
using CLogMuestra = CapaLogica.DOC.Log_CNOTIFICACION;
using CLogWSOSINFOR = CapaLogica.DOC.Log_WS_OSINFOR;

/// <summary>
/// Descripción breve de WSSupervisión
/// </summary>
[WebService(Namespace = "http://microsoft.com/webservices/")]
public class WSSupervision : System.Web.Services.WebService
{
    CLogBusqueda oCLogBusqueda = new CLogBusqueda();
    CLogEspecies oCLogEspecies = new CLogEspecies();
    CLogMuestra oCLogMuestra = new CLogMuestra();
    CLogInforme oCLogInforme = new CLogInforme();
    CLogWSOSINFOR oCLogWSOSINFOR = new CLogWSOSINFOR();
    public autenticaUser usuario;
    public objMaderable datoMaderable;
    public objNoMaderable datoNoMaderable;

    [WebMethod]
    [SoapHeader("usuario")]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string listaCNotificaciones()
    {
        List<Object> cNotificaciones = new List<Object>();
        if (usuario != null)
        {
            if (usuario.IsValid())
            {
                List<CEntBusqueda> listNotificacion = new List<CEntBusqueda>();
                CEntBusqueda oCampos = new CEntBusqueda();
                oCampos.BusFormulario = "CARTA_NOTIFICACION";
                oCampos.BusCriterio = "CNOTIF_SIN_INF";
                oCampos.BusValor = "";
                listNotificacion = oCLogBusqueda.RegMostrarLista(oCampos);
                foreach (var fila in listNotificacion)
                {
                    cNotificaciones.Add(new
                    {
                        COD_CNOTIFICACION = fila.CODIGO,
                        NUM_CNOTIFICACION = fila.NUMERO,
                        NUM_THABILITANTE = fila.PARAMETRO02,
                        TITULAR = fila.PARAMETRO03,
                        POA_SUPERVISAR = fila.PARAMETRO05,
                        CN_TIPO = fila.PARAMETRO12
                    });
                }
            }
            else
            {
                cNotificaciones.Add("Error en la autenticación");
            }
        }
        else
        {
            cNotificaciones.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(cNotificaciones));
    }

    [WebMethod]
    [SoapHeader("usuario")]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string listaInformes()
    {
        List<Object> cInformes = new List<Object>();
        if (usuario != null)
        {
            if (usuario.IsValid())
            {
                List<CEntBusqueda> listInformes = new List<CEntBusqueda>();
                CEntBusqueda oCampos = new CEntBusqueda();
                oCampos.BusFormulario = "INFORME_SUPERVISION";
                oCampos.BusCriterio = "INF_NUMERO_PENDIENTE";
                oCampos.BusValor = "";
                listInformes = oCLogBusqueda.RegMostrarLista(oCampos);
                foreach (var fila in listInformes)
                {
                    cInformes.Add(new
                    {
                        COD_INFORME = fila.CODIGO,
                        NUMERO = fila.NUMERO,
                        NUM_CNOTIFICACION = fila.PARAMETRO01,
                        MODALIDAD_TIPO = fila.PARAMETRO02,
                        NUM_THABILITANTE = fila.PARAMETRO03,
                        TITULAR = fila.PARAMETRO09,
                        SUPERVISOR = fila.PARAMETRO04,
                        POA = fila.PARAMETRO11
                    });
                }
            }
            else
            {
                cInformes.Add("Error en la autenticación");
            }
        }
        else
        {
            cInformes.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(cInformes));
    }

    [WebMethod]
    [SoapHeader("usuario")]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string listaMuestra(String codCN, String tipo)
    {
        List<CEntMuestra> listMuestra = new List<CEntMuestra>();
        List<Object> lMuestra = new List<Object>();
        CEntMuestra oCampos = new CEntMuestra();
        if (usuario != null)
        {
            if (usuario.IsValid())
            {
                oCampos.COD_CNOTIFICACION = codCN;

                switch (tipo)
                {
                    case "M":
                        listMuestra = (from p in oCLogMuestra.RegMostrarPoaDetMadCensoLista(oCampos).ListSDETMADERABLE where (Boolean)p.ESTADO_MUESTRA == true select p).ToList<CEntMuestra>();
                        foreach (var fila in listMuestra)
                        {
                            lMuestra.Add(new
                            {
                                NUM_POA = fila.NUM_POA,
                                POA = fila.POA,
                                COD_ESPECIES = fila.COD_ESPECIES,
                                DESC_ESPECIES = fila.DESC_ESPECIES,
                                COD_SECUENCIAL = fila.COD_SECUENCIAL,
                                BLOQUE = fila.BLOQUE,
                                FAJA = fila.FAJA,
                                CODIGO = fila.CODIGO,
                                VOLUMEN = fila.VOLUMEN,
                                DAP = fila.DAP,
                                AC = fila.AC,
                                DMC = fila.DMC,
                                DESC_ECONDICION = fila.DESC_ECONDICION,
                                DESC_EESTADO = fila.DESC_EESTADO,
                                ZONA = fila.ZONA,
                                COORDENADA_ESTE = fila.COORDENADA_ESTE,
                                COORDENADA_NORTE = fila.COORDENADA_NORTE,
                                CODIGO_GPS = fila.CODIGO_GPS,
                                COD_SISTEMA = fila.COD_SISTEMA,
                                OBSERVACION = fila.OBSERVACION
                            });
                        }
                        break;
                    case "NM":
                        listMuestra = (from p in oCLogMuestra.RegMostrarPoaDetNoMadCensoLista(oCampos).ListSDETMADERABLE where (Boolean)p.ESTADO_MUESTRA == true select p).ToList<CEntMuestra>();
                        foreach (var fila in listMuestra)
                        {
                            lMuestra.Add(new
                            {
                                NUM_POA = fila.NUM_POA,
                                POA = fila.POA,
                                COD_ESPECIES = fila.COD_ESPECIES,
                                DESC_ESPECIES = fila.DESC_ESPECIES,
                                COD_SECUENCIAL = fila.COD_SECUENCIAL,
                                NUM_ESTRADA = fila.NUM_ESTRADA,
                                CODIGO = fila.CODIGO,
                                DIAMETRO = fila.DIAMETRO,
                                ALTURA = fila.ALTURA,
                                PRODUCCION_LATAS = fila.PRODUCCION_LATAS,
                                DESC_ECONDICION = fila.DESC_ECONDICION,
                                ZONA = fila.ZONA,
                                COORDENADA_ESTE = fila.COORDENADA_ESTE,
                                COORDENADA_NORTE = fila.COORDENADA_NORTE,
                                CODIGO_GPS = fila.CODIGO_GPS,
                                COD_SISTEMA = fila.COD_SISTEMA,
                                OBSERVACION = fila.OBSERVACION
                            });
                        }
                        break;
                }

            }
            else
            {
                lMuestra.Add("Error en la autenticación");
            }
        }
        else
        {
            lMuestra.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(lMuestra));
    }

    [WebMethod]
    [SoapHeader("datoMaderable")]
    [SoapHeader("usuario")]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string cargaDatosCampoMaderable()
    {
        string retorno = "";
        CEntInforme oCampos = new CEntInforme();
        //CEntInforme oCEntidadInforme = new CEntInforme();
        if (usuario != null)
        {
            if (usuario.IsValid())
            {
                //oCampos.COD_SECUENCIAL = 0;
                oCampos.BLOQUE_CAMPO = datoMaderable.BLOQUE_CAMPO;
                oCampos.FAJA_CAMPO = datoMaderable.FAJA_CAMPO;
                oCampos.CODIGO_CAMPO = datoMaderable.CODIGO_CAMPO;
                oCampos.DAP_CAMPO = datoMaderable.DAP_CAMPO;
                oCampos.AC_CAMPO = datoMaderable.AC_CAMPO;
                oCampos.ESTADO_CAMPO = datoMaderable.ESTADO_CAMPO;
                oCampos.COD_INFORME = datoMaderable.COD_INFORME;
                oCampos.ZONA_CAMPO = datoMaderable.ZONA_CAMPO == "" ? null : datoMaderable.ZONA_CAMPO;
                oCampos.COORDENADA_ESTE_CAMPO = datoMaderable.COORDENADA_ESTE_CAMPO;
                oCampos.COORDENADA_NORTE_CAMPO = datoMaderable.COORDENADA_NORTE_CAMPO;
                oCampos.COD_CFUSTE = datoMaderable.COD_CFUSTE;
                oCampos.COD_PCOPA = datoMaderable.COD_PCOPA;
                oCampos.COD_FCOPA = datoMaderable.COD_FCOPA;
                oCampos.COD_EFENOLOGICO = datoMaderable.COD_EFENOLOGICO;
                oCampos.COD_ESANITARIO = datoMaderable.COD_ESANITARIO;
                oCampos.COD_ILIANAS = datoMaderable.COD_ILIANAS;
                oCampos.DESC_CFUSTE = datoMaderable.DESC_CFUSTE;
                oCampos.DESC_PCOPA = datoMaderable.DESC_PCOPA;
                oCampos.DESC_FCOPA = datoMaderable.DESC_FCOPA;
                oCampos.DESC_EFENOLOGICO = datoMaderable.DESC_EFENOLOGICO;
                oCampos.DESC_ESANITARIO = datoMaderable.DESC_ESANITARIO;
                oCampos.DESC_ILIANAS = datoMaderable.DESC_ILIANAS;
                //oCampos.GRADO_AMENAZA = Fila[23].ToString().Trim();
                oCampos.COD_SISTEMA = datoMaderable.COD_SISTEMA;
                oCampos.OBSERVACION_CAMPO = datoMaderable.OBSERVACION_CAMPO;
                oCampos.COD_ESPECIES_CAMPO = datoMaderable.COD_ESPECIES_CAMPO;
                oCampos.ESPECIES = String.Format("{0} | {1}", datoMaderable.ESPECIES_NCIENTIFICO, datoMaderable.ESPECIES_NCOMUN);

                //oCEntidadInforme.ListINFORMEItemsDetalle.Add(oCampos);
                retorno = oCLogInforme.RegCargaMaderableWS(oCampos);
            }
            else
            {
                retorno = "Error en la autenticación";
            }
        }
        else
        {
            retorno = "Error en la autenticación";
        }
        return retorno;
    }
    [WebMethod]
    [SoapHeader("datoNoMaderable")]
    [SoapHeader("usuario")]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string cargaDatosCampoNoMaderable()
    {
        string retorno = "";
        CEntInforme oCampos = new CEntInforme();
        //CEntInforme oCEntidadInforme = new CEntInforme();
        if (usuario != null)
        {
            if (usuario.IsValid())
            {
                //oCampos.COD_SECUENCIAL = 0;
                oCampos.NUM_ESTRADA = datoNoMaderable.NUM_ESTRADA;
                oCampos.CODIGO_CAMPO = datoNoMaderable.CODIGO;
                oCampos.DIAMETRO_CAMPO = datoNoMaderable.DIAMETRO;
                oCampos.ALTURA_CAMPO = datoNoMaderable.ALTURA;
                oCampos.PRODUCCION_LATAS_CAMPO = datoNoMaderable.PRODUCCION_LATAS;
                oCampos.CONDICION_CAMPO = datoNoMaderable.CONDICION_CAMPO;
                oCampos.ESTADO_CAMPO = datoNoMaderable.ESTADO_CAMPO;
                oCampos.COD_INFORME = datoNoMaderable.COD_INFORME;
                oCampos.ZONA_CAMPO = datoNoMaderable.ZONA == "" ? null : datoNoMaderable.ZONA;
                oCampos.COORDENADA_ESTE_CAMPO = datoNoMaderable.COORDENADA_ESTE;
                oCampos.COORDENADA_NORTE_CAMPO = datoNoMaderable.COORDENADA_NORTE;
                oCampos.NUM_COCOS_ABIERTOS = datoNoMaderable.NUM_COCOS_ABIERTOS;
                oCampos.NUM_COCOS_CERRADOS = datoNoMaderable.NUM_COCOS_CERRADOS;
                oCampos.DESC_CFUSTE = datoNoMaderable.DESC_CFUSTE;
                oCampos.DESC_PCOPA = datoNoMaderable.DESC_PCOPA;
                oCampos.DESC_FCOPA = datoNoMaderable.DESC_FCOPA;
                oCampos.DESC_EFENOLOGICO = datoNoMaderable.DESC_EFENOLOGICO;
                oCampos.DESC_ESANITARIO = datoNoMaderable.DESC_ESANITARIO;
                oCampos.DESC_ILIANAS = datoNoMaderable.DESC_ILIANAS;
                oCampos.OBSERVACION_CAMPO = datoNoMaderable.OBSERVACION_CAMPO;
                oCampos.COD_SISTEMA = datoNoMaderable.COD_SISTEMA;
                oCampos.COD_ESPECIES_CAMPO = datoNoMaderable.COD_ESPECIES_CAMPO;
                oCampos.ESPECIES = String.Format("{0} | {1}", datoNoMaderable.ESPECIES_NCIENTIFICO, datoNoMaderable.ESPECIES_NCOMUN);

                retorno = oCLogInforme.RegCargaNoMaderableWS(oCampos);

            }
            else
            {
                retorno = "Error en la autenticación";
            }
        }
        else
        {
            retorno = "Error en la autenticación";
        }
        return retorno;
    }

    //[WebMethod]
    //[SoapHeader("usuario")]
    //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    //public string listaEspNCientifico()
    //{
    //    List<CEntEspecies> listEspecies = new List<CEntEspecies>();
    //    CEntEspecies oCampos = new CEntEspecies();
    //    List<Object> retorno = new List<Object>();

    //    if (usuario != null)
    //    {
    //        if (usuario.IsValid())
    //        {

    //            oCampos.BusFormulario = "GESTION_ESPECIES";
    //            oCampos.BusCriterio = "ESPECIES_NCIENTIFICO";
    //            oCampos.BusValor = "";
    //            listEspecies = oCLogEspecies.RegMostrarListaEspNCientifico(oCampos);
    //            foreach (var fila in listEspecies)
    //            {
    //                retorno.Add(new
    //                {
    //                    COD_ENCIENTIFICO = fila.COD_ENCIENTIFICO,
    //                    NOMBRE_CIENTIFICO = fila.NOMBRE_CIENTIFICO,
    //                    TIPO = fila.TIPO,
    //                    COD_GENERO = fila.COD_GENERO,
    //                    COD_AGRADO_CITE = fila.COD_AGRADO_CITE,
    //                    COD_AGRADO_DS = fila.COD_AGRADO_DS,
    //                    FECHA_CREACION = fila.FECHA_CREACION,
    //                    FECHA_MODIFICAR = fila.FECHA_MODIFICAR
    //                });
    //            }
    //        }
    //        else
    //        {
    //            retorno.Add("Error en la autenticación");
    //        }
    //    }
    //    else
    //    {
    //        retorno.Add("Error en la autenticación");
    //    }
    //    return (new JavaScriptSerializer().Serialize(retorno));
    //}
    //[WebMethod]
    //[SoapHeader("usuario")]
    //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    //public string listaEspNComun()
    //{
    //    List<CEntEspecies> listEspecies = new List<CEntEspecies>();
    //    CEntEspecies oCampos = new CEntEspecies();
    //    List<Object> retorno = new List<Object>();

    //    if (usuario != null)
    //    {
    //        if (usuario.IsValid())
    //        {

    //            oCampos.BusFormulario = "GESTION_ESPECIES";
    //            oCampos.BusCriterio = "ESPECIES_NCOMUN";
    //            oCampos.BusValor = "";
    //            listEspecies = oCLogEspecies.RegMostrarListaEspNComun(oCampos);
    //            foreach (var fila in listEspecies)
    //            {
    //                retorno.Add(new
    //                {
    //                    COD_ENCIENTIFICO = fila.COD_ENCIENTIFICO,
    //                    COD_ESPECIES = fila.COD_ESPECIES,
    //                    NOMBRE_COMUN = fila.NOMBRE_COMUN,
    //                    FECHA_CREACION = fila.FECHA_CREACION,
    //                    FECHA_MODIFICAR = fila.FECHA_MODIFICAR,
    //                    FUENTE = fila.FUENTE
    //                });
    //            }
    //        }
    //        else
    //        {
    //            retorno.Add("Error en la autenticación");
    //        }
    //    }
    //    else
    //    {
    //        retorno.Add("Error en la autenticación");
    //    }
    //    return (new JavaScriptSerializer().Serialize(retorno));
    //}


    [WebMethod]
    [SoapHeader("usuario")]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string listaDatosPOAs(String codCN)
    {
        List<CEntWSOSINFOR> listDatosPOAs = new List<CEntWSOSINFOR>();
        CEntWSOSINFOR oCampos = new CEntWSOSINFOR();
        List<Object> retorno = new List<Object>();

        if (usuario != null)
        {
            if (usuario.IsValid())
            {
                oCampos.BusCriterio = "POA_INFO_GENERAL";
                oCampos.BusValor = codCN;
                listDatosPOAs = oCLogWSOSINFOR.RegMostrarDatosPOAs(oCampos);
                foreach (var fila in listDatosPOAs)
                {
                    retorno.Add(new
                    {
                        MODALIDAD = fila.MODALIDAD,
                        NUM_THABILITANTE = fila.NUM_THABILITANTE,
                        TITULAR = fila.TITULAR,
                        OD = fila.OD,
                        ARESOLUCION_NUM = fila.ARESOLUCION_NUM,
                        NOMBRE_POA = fila.NOMBRE_POA,
                        NUM_PCOMPLEMENTARIO = fila.NUM_PCOMPLEMENTARIO,
                        AREA_POA = fila.AREA_POA,
                        PCA = fila.PCA,
                        ZAFRA_PCA = fila.ZAFRA_PCA,
                        INICIO_VIGENCIA = fila.INICIO_VIGENCIA,
                        FIN_VIGENCIA = fila.FIN_VIGENCIA,
                        DEPARTAMENTO = fila.DEPARTAMENTO,
                        PROVINCIA = fila.PROVINCIA,
                        DISTRITO = fila.DISTRITO,
                        FECHA_SUPERVISION_INI = fila.FECHA_SUPERVISION_INI,
                        FECHA_SUPERVISION_FIN = fila.FECHA_SUPERVISION_FIN
                    });
                }
            }
            else
            {
                retorno.Add("Error en la autenticación");
            }
        }
        else
        {
            retorno.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(retorno));
    }
    [WebMethod]
    [SoapHeader("usuario")]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public string listaDatosPOAs_v3(String codFN)
    {
        List<CEntWSOSINFOR> listDatosPOAs = new List<CEntWSOSINFOR>();
        CEntWSOSINFOR oCampos = new CEntWSOSINFOR();
        List<Object> retorno = new List<Object>();

        if (usuario != null)
        {
            if (usuario.IsValid())
            {
                oCampos.BusCriterio = "POA_INFO_GENERAL_V3";
                oCampos.BusValor = codFN;
                listDatosPOAs = oCLogWSOSINFOR.RegMostrarDatosPOAs(oCampos);
                foreach (var fila in listDatosPOAs)
                {
                    retorno.Add(new
                    {
                        MODALIDAD = fila.MODALIDAD,
                        NUM_THABILITANTE = fila.NUM_THABILITANTE,
                        TITULAR = fila.TITULAR,
                        OD = fila.OD,
                        ARESOLUCION_NUM = fila.ARESOLUCION_NUM,
                        NOMBRE_POA = fila.NOMBRE_POA,
                        NUM_PCOMPLEMENTARIO = fila.NUM_PCOMPLEMENTARIO,
                        AREA_POA = fila.AREA_POA,
                        PCA = fila.PCA,
                        ZAFRA_PCA = fila.ZAFRA_PCA,
                        INICIO_VIGENCIA = fila.INICIO_VIGENCIA,
                        FIN_VIGENCIA = fila.FIN_VIGENCIA,
                        DEPARTAMENTO = fila.DEPARTAMENTO,
                        PROVINCIA = fila.PROVINCIA,
                        DISTRITO = fila.DISTRITO,
                        FECHA_SUPERVISION_INI = fila.FECHA_SUPERVISION_INI,
                        FECHA_SUPERVISION_FIN = fila.FECHA_SUPERVISION_FIN
                    });
                }
            }
            else
            {
                retorno.Add("Error en la autenticación");
            }
        }
        else
        {
            retorno.Add("Error en la autenticación");
        }
        return (new JavaScriptSerializer().Serialize(retorno));
    }

    public WSSupervision()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}