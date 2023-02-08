using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_WS_OSINFOR;
using CLogica = CapaLogica.DOC.Log_WS_OSINFOR;

namespace WSSIGOsfc.Controllers
{
    public class INTERController : Controller
    {
        CLogica oCLogica = new CLogica();
        // GET: INTER
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult listaSancionCaducidad(string varBusqueda)
        {
            List<Object> resultado = new List<object>();
            resultado = devuelveListaSancionCaduc(varBusqueda);
            if (resultado.Count == 0)
            {
                if (varBusqueda == "TOTAL")
                { resultado.Add("Hubo un error en la consulta, vuelva a intentar en otro momento"); }
                else
                {
                    resultado.Add("No se encontraron resultados para la búsqueda");
                }
            }
            return Json(resultado);
        }
        private List<Object> devuelveListaSancionCaduc(String varBusqueda)
        {
            List<Object> cDetailSancionados = new List<Object>();
            List<CEntidad> listDetailSancionados = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            oCampos.BusCriterio = "SANCION_CADUCADOS";
            oCampos.BusValor = varBusqueda.Trim();

            listDetailSancionados = oCLogica.RegDetalleSancioCaduc(oCampos);
            foreach (var fila in listDetailSancionados)
            {
                cDetailSancionados.Add(new
                {
                    COD_THABILITANTE = fila.COD_THABILITANTE,
                    TITULAR = fila.TITULAR,
                    DOCUMENTO = fila.DOCUMENTO,
                    NUM_THABILITANTE = fila.NUM_THABILITANTE,
                    MODALIDAD = fila.MODALIDAD,
                    DEPARTAMENTO = fila.DEPARTAMENTO,
                    PROVINCIA = fila.PROVINCIA,
                    DISTRITO = fila.DISTRITO,
                    NUM_RESOLUCION_TER = fila.NUM_RESOLUCION_TER_1,
                    INFRACCIONES_TER = fila.INFRACCIONES_TER_1,
                    NUM_RESOLUCION_RECONS = fila.NUM_RESOLUCION_RECONS,
                    CADUCADO_TH = fila.CADUCADO_TH.ToString(),
                });
            }
            return cDetailSancionados;
        }
        public JsonResult detalleIniPAU(string usuario, string password, string varBusqueda)
        {
            autenticaUser usuarioBody = new autenticaUser();
            usuarioBody.userName = usuario;
            usuarioBody.password = password;
            List<Object> resultado = new List<object>();
            if (usuarioBody != null)
            {
                if (usuarioBody.IsValid())
                {
                    resultado = devuelveDetalleIniPAU(varBusqueda, usuario);
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
            if (resultado.Count == 0)
            { resultado.Add("No se encontraron resultados para la búsqueda"); }
            return Json(resultado);
        }
        private List<Object> devuelveDetalleIniPAU(String varBusqueda, String Usuario)
        {
            List<Object> cDetailIniPAU = new List<Object>();
            List<CEntidad> listDetailIniPAU = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            oCampos.BusCriterio = "DETALLE_INICIO_PAU";
            oCampos.BusValor = varBusqueda.Trim();
            oCampos.USUARIO_LOGIN = Usuario;

            listDetailIniPAU = oCLogica.RegDetalleResodirec(oCampos);

            switch (Usuario)
            {
                case "PNCBMCC":
                    foreach (var fila in listDetailIniPAU)
                    {
                        cDetailIniPAU.Add(new
                        {
                            COD_RESODIREC = fila.COD_RESODIREC,
                            DESC_ART = fila.DESC_ART,
                            DESC_INCISO = fila.DESC_INCISO
                        });
                    }
                    break;
                default:
                    foreach (var fila in listDetailIniPAU)
                    {
                        cDetailIniPAU.Add(new
                        {
                            COD_RESODIREC = fila.COD_RESODIREC,
                            COD_SECUENCIAL = fila.COD_SECUENCIAL,
                            COD_INCISO = fila.COD_INCISO,
                            DESC_ART = fila.DESC_ART,
                            DESC_INCISO = fila.DESC_INCISO,
                            COD_ESPECIES = fila.COD_ESPECIES,
                            DESC_ESPECIES = fila.DESC_ESPECIES,
                            VOLUMEN = fila.VOLUMEN,
                            AREA = fila.AREA,
                            NUMERO_INDIVIDUOS = fila.NUMERO_INDIVIDUOS
                        });
                    }
                    break;
            }

            return cDetailIniPAU;
        }
        public JsonResult detalleTerPAU(string usuario, string password, string varBusqueda)
        {
            autenticaUser usuarioBody = new autenticaUser();
            usuarioBody.userName = usuario;
            usuarioBody.password = password;
            List<Object> resultado = new List<object>();
            if (usuarioBody != null)
            {
                if (usuarioBody.IsValid())
                {
                    resultado = devuelveDetalleTerPAU(varBusqueda, usuario);
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
            if (resultado.Count == 0)
            { resultado.Add("No se encontraron resultados para la búsqueda"); }
            return Json(resultado);
        }
        private List<Object> devuelveDetalleTerPAU(String varBusqueda, String Usuario)
        {
            List<Object> cDetailTerPAU = new List<Object>();
            List<CEntidad> listDetailTerPAU = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            oCampos.BusCriterio = "DETALLE_TERMINO_PAU";
            oCampos.BusValor = varBusqueda.Trim();
            oCampos.USUARIO_LOGIN = Usuario;

            listDetailTerPAU = oCLogica.RegDetalleResodirec(oCampos);
            switch (Usuario)
            {
                case "PNCBMCC":
                    foreach (var fila in listDetailTerPAU)
                    {
                        cDetailTerPAU.Add(new
                        {
                            COD_RESODIREC = fila.COD_RESODIREC,
                            DESC_ART = fila.DESC_ART,
                            DESC_INCISO = fila.DESC_INCISO
                        });
                    }
                    break;
                default:
                    foreach (var fila in listDetailTerPAU)
                    {
                        cDetailTerPAU.Add(new
                        {
                            COD_RESODIREC = fila.COD_RESODIREC,
                            COD_SECUENCIAL = fila.COD_SECUENCIAL,
                            COD_INCISO = fila.COD_INCISO,
                            DESC_ART = fila.DESC_ART,
                            DESC_INCISO = fila.DESC_INCISO,
                            COD_ESPECIES = fila.COD_ESPECIES,
                            DESC_ESPECIES = fila.DESC_ESPECIES,
                            VOLUMEN = fila.VOLUMEN,
                            AREA = fila.AREA,
                            NUMERO_INDIVIDUOS = fila.NUMERO_INDIVIDUOS
                        });
                    }
                    break;
            }

            return cDetailTerPAU;
        }
        public JsonResult detalleSupervision(string usuario, string password, string varBusqueda)
        {
            autenticaUser usuarioBody = new autenticaUser();
            usuarioBody.userName = usuario;
            usuarioBody.password = password;
            List<Object> resultado = new List<object>();
            if (usuarioBody != null)
            {
                if (usuarioBody.IsValid())
                {
                    resultado = devuelveDetalleSupervision(varBusqueda, usuario);
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
            if (resultado.Count == 0)
            { resultado.Add("No se encontraron resultados para la búsqueda"); }
            return Json(resultado);
        }
        private List<Object> devuelveDetalleSupervision(String varBusqueda, String Usuario)
        {
            List<Object> cDetailSupervision = new List<Object>();
            List<CEntidad> listDetailSupervision = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            oCampos.BusCriterio = "DETALLE_CAMPO";
            oCampos.BusValor = varBusqueda.Trim();
            oCampos.USUARIO_LOGIN = Usuario;

            listDetailSupervision = oCLogica.RegDetalleSupervision(oCampos);
            switch (Usuario)
            {
                case "PNCBMCC":
                    foreach (var fila in listDetailSupervision)
                    {
                        cDetailSupervision.Add(new
                        {
                            COD_ESPECIES_CAMPO = fila.COD_ESPECIES_CAMPO,
                            DESC_ESPECIES_CAMPO = fila.DESC_ESPECIES,
                            ZONA_UTM_CAMPO = fila.ZONA_UTM_CAMPO,
                            COORDENADA_ESTE_CAMPO = fila.COORDENADA_ESTE_CAMPO,
                            COORDENADA_NORTE_CAMPO = fila.COORDENADA_NORTE_CAMPO,
                            COD_EESTADO_CAMPO = fila.COD_EESTADO_CAMPO,
                            DESC_EESTADO_CAMPO = fila.DESC_EESTADO_CAMPO,
                            COD_ECONDICION_CAMPO = fila.COD_ECONDICION_CAMPO,
                            DESC_ECONDICION_CAMPO = fila.DESC_ECONDICION_CAMPO
                        });
                    }
                    break;
                default:
                    foreach (var fila in listDetailSupervision)
                    {
                        cDetailSupervision.Add(new
                        {
                            COD_THABILITANTE = fila.COD_THABILITANTE,
                            NUM_POA = fila.NUM_POA,
                            POA = fila.POA,
                            COD_ESPECIES = fila.COD_ESPECIES_CAMPO,
                            DESC_ESPECIES = fila.DESC_ESPECIES,
                            COD_SECUENCIAL = fila.COD_SECUENCIAL,
                            BLOQUE = fila.BLOQUE,
                            FAJA = fila.FAJA,
                            CODIGO = fila.CODIGO,
                            DAP = fila.DAP,
                            AC = fila.AC,
                            COD_ECONDICION = fila.COD_ECONDICION,
                            DESC_ECONDICION = fila.DESC_ECONDICION,
                            DESC_EESTADO = fila.DESC_EESTADO,
                            ZONA_UTM = fila.ZONA_UTM,
                            COORDENADA_ESTE = fila.COORDENADA_ESTE,
                            COORDENADA_NORTE = fila.COORDENADA_NORTE,
                            COD_ESPECIES_CAMPO = fila.COD_ESPECIES_CAMPO,
                            DESC_ESPECIES_CAMPO = fila.DESC_ESPECIES,
                            BLOQUE_CAMPO = fila.BLOQUE_CAMPO,
                            FAJA_CAMPO = fila.FAJA_CAMPO,
                            CODIGO_CAMPO = fila.CODIGO_CAMPO,
                            DAP_CAMPO = fila.DAP_CAMPO,
                            DAP_CAMPO1 = fila.DAP_CAMPO1,
                            DAP_CAMPO2 = fila.DAP_CAMPO2,
                            AC_CAMPO = fila.AC_CAMPO,
                            ZONA_UTM_CAMPO = fila.ZONA_UTM_CAMPO,
                            COORDENADA_ESTE_CAMPO = fila.COORDENADA_ESTE_CAMPO,
                            COORDENADA_NORTE_CAMPO = fila.COORDENADA_NORTE_CAMPO,
                            DESC_ACATEGORIA_CITE = fila.DESC_ACATEGORIA_CITE,
                            DESC_ACATEGORIA_DS = fila.DESC_ACATEGORIA_DS,
                            BS_ALTURA_TOTAL = fila.BS_ALTURA_TOTAL,
                            BS_DIAMETRO_RAMA_1 = fila.BS_DIAMETRO_RAMA_1,
                            BS_DIAMETRO_RAMA_2 = fila.BS_DIAMETRO_RAMA_2,
                            BS_DIAMETRO_RAMA_3 = fila.BS_DIAMETRO_RAMA_3,
                            BS_DIAMETRO_RAMA_4 = fila.BS_DIAMETRO_RAMA_4,
                            BS_DIAMETRO_RAMA_5 = fila.BS_DIAMETRO_RAMA_5,
                            BS_DIAMETRO_RAMA_6 = fila.BS_DIAMETRO_RAMA_6,
                            BS_DIAMETRO_RAMA_7 = fila.BS_DIAMETRO_RAMA_7,
                            BS_LONGITUD_RAMA_1 = fila.BS_LONGITUD_RAMA_1,
                            BS_LONGITUD_RAMA_2 = fila.BS_LONGITUD_RAMA_2,
                            BS_LONGITUD_RAMA_3 = fila.BS_LONGITUD_RAMA_3,
                            BS_LONGITUD_RAMA_4 = fila.BS_LONGITUD_RAMA_4,
                            BS_LONGITUD_RAMA_5 = fila.BS_LONGITUD_RAMA_5,
                            BS_LONGITUD_RAMA_6 = fila.BS_LONGITUD_RAMA_6,
                            BS_LONGITUD_RAMA_7 = fila.BS_LONGITUD_RAMA_7,
                            COD_EESTADO_CAMPO = fila.COD_EESTADO_CAMPO,
                            DESC_EESTADO_CAMPO = fila.DESC_EESTADO_CAMPO,
                            COD_ECONDICION_CAMPO = fila.COD_ECONDICION_CAMPO,
                            DESC_ECONDICION_CAMPO = fila.DESC_ECONDICION_CAMPO
                        });
                    }
                    break;
            }

            return cDetailSupervision;
        }
        public JsonResult Resultados(string usuario, string password, string varBusqueda)
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
            if (resultado.Count == 0)
            { resultado.Add("No se encontraron resultados para la búsqueda"); }
            return Json(resultado);
        }
        private List<Object> devuelveSupervisiones(String varBusqueda, String Usuario)
        {

            List<Object> cSupervisiones = new List<Object>();
            List<CEntidad> listSupervisiones = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            oCampos.BusCriterio = "SUPERVISIONES_v2";
            oCampos.BusValor = varBusqueda.Trim();
            oCampos.USUARIO_LOGIN = Usuario;
            //listSupervisionesregAccionReporteGTF("SEARCH", "CRITERIO=" + BusCriterio.Trim() + ";SEARCH_STRING=" + txtManBuscar.Text.Trim());
            listSupervisiones = oCLogica.RegMostrarSupervisiones(oCampos);
            switch (Usuario)
            {
                case "PNCBMCC":
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

                            NUM_RESOLUCION_INI_1 = fila.NUM_RESOLUCION_INI_1,
                            FECHA_EMISION_INI_1 = fila.FECHA_EMISION_INI_1,
                            MED_CAU_INI_1 = fila.MED_CAU_INI_1,
                            INFRACCIONES_INI_1 = fila.INFRACCIONES_INI_1,
                            NUM_RESOLUCION_AMP = fila.NUM_RESOLUCION_AMP,
                            FECHA_EMISION_AMP = fila.FECHA_EMISION_AMP,
                            INFRACCIONES_AMP = fila.INFRACCIONES_AMP,
                            NUM_RESOLUCION_TER_1 = fila.NUM_RESOLUCION_TER_1,
                            FECHA_EMISION_TER_1 = fila.FECHA_EMISION_TER_1,
                            DETER_TER_1 = fila.DETER_TER_1,
                            MONTO_MULTA_TER_1 = fila.MONTO_MULTA_TER_1,
                            AMONESTACION_TER_1 = fila.AMONESTACION_TER_1,
                            CADUCIDAD_TER_1 = fila.CADUCIDAD_TER_1,
                            MED_PRECAU_TER_1 = fila.MED_PRECAU_TER_1,
                            MED_CORREC_TER_1 = fila.MED_CORREC_TER_1,
                            INFRACCIONES_TER_1 = fila.INFRACCIONES_TER_1,
                            NUM_RESOLUCION_TFFS_1 = fila.NUM_RESOLUCION_TFFS_1,
                            FECHA_EMISION_TFFS_1 = fila.FECHA_EMISION_TFFS_1,
                            RECURSO_TFFS_1 = fila.RECURSO_TFFS_1,
                            DETERMINA_TFFS_1 = fila.DETERMINA_TFFS_1,
                            MOTIVO_TFFS_1 = fila.MOTIVO_TFFS_1,

                            NUM_RESOLUCION_TER_2 = fila.NUM_RESOLUCION_TER_2,
                            FECHA_EMISION_TER_2 = fila.FECHA_EMISION_TER_2,
                            DETER_TER_2 = fila.DETER_TER_2,
                            MONTO_MULTA_TER_2 = fila.MONTO_MULTA_TER_2,
                            AMONESTACION_TER_2 = fila.AMONESTACION_TER_2,
                            CADUCIDAD_TER_2 = fila.CADUCIDAD_TER_2,
                            MED_PRECAU_TER_2 = fila.MED_PRECAU_TER_2,
                            MED_CORREC_TER_2 = fila.MED_CORREC_TER_2,
                            INFRACCIONES_TER_2 = fila.INFRACCIONES_TER_2,

                            NUM_RESOLUCION_TFFS_2 = fila.NUM_RESOLUCION_TFFS_2,
                            FECHA_EMISION_TFFS_2 = fila.FECHA_EMISION_TFFS_2,
                            RECURSO_TFFS_2 = fila.RECURSO_TFFS_2,
                            DETERMINA_TFFS_2 = fila.DETERMINA_TFFS_2,
                            MOTIVO_TFFS_2 = fila.MOTIVO_TFFS_2,

                            ESTADO_PAU = fila.ESTADO_PAU,
                            FECHA_ACTUALIZACION = fila.FECHA_ACTUALIZACION,
                        });
                    }
                    break;
                default:
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

                            NUM_RESOLUCION_INI_1 = fila.NUM_RESOLUCION_INI_1,
                            FECHA_EMISION_INI_1 = fila.FECHA_EMISION_INI_1,
                            MED_CAU_INI_1 = fila.MED_CAU_INI_1,
                            INFRACCIONES_INI_1 = fila.INFRACCIONES_INI_1,
                            NUM_RESOLUCION_AMP = fila.NUM_RESOLUCION_AMP,
                            FECHA_EMISION_AMP = fila.FECHA_EMISION_AMP,
                            INFRACCIONES_AMP = fila.INFRACCIONES_AMP,
                            NUM_RESOLUCION_VAIMP = fila.NUM_RESOLUCION_VAIMP,
                            FECHA_EMISION_VAIMP = fila.FECHA_EMISION_VAIMP,
                            INFRACCIONES_VAIMP = fila.INFRACCIONES_VAIMP,
                            NUM_RESOLUCION_TER_1 = fila.NUM_RESOLUCION_TER_1,
                            FECHA_EMISION_TER_1 = fila.FECHA_EMISION_TER_1,
                            DETER_TER_1 = fila.DETER_TER_1,
                            MONTO_MULTA_TER_1 = fila.MONTO_MULTA_TER_1,
                            AMONESTACION_TER_1 = fila.AMONESTACION_TER_1,
                            CADUCIDAD_TER_1 = fila.CADUCIDAD_TER_1,
                            MED_PRECAU_TER_1 = fila.MED_PRECAU_TER_1,
                            MED_CORREC_TER_1 = fila.MED_CORREC_TER_1,
                            INFRACCIONES_TER_1 = fila.INFRACCIONES_TER_1,
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
                            NUM_RESOLUCION_TFFS_1 = fila.NUM_RESOLUCION_TFFS_1,
                            FECHA_EMISION_TFFS_1 = fila.FECHA_EMISION_TFFS_1,
                            RECURSO_TFFS_1 = fila.RECURSO_TFFS_1,
                            DETERMINA_TFFS_1 = fila.DETERMINA_TFFS_1,
                            MOTIVO_TFFS_1 = fila.MOTIVO_TFFS_1,

                            NUM_RESOLUCION_INI_2 = fila.NUM_RESOLUCION_INI_2,
                            FECHA_EMISION_INI_2 = fila.FECHA_EMISION_INI_2,
                            MED_CAU_INI_2 = fila.MED_CAU_INI_2,
                            INFRACCIONES_INI_2 = fila.INFRACCIONES_INI_2,

                            NUM_RESOLUCION_TER_2 = fila.NUM_RESOLUCION_TER_2,
                            FECHA_EMISION_TER_2 = fila.FECHA_EMISION_TER_2,
                            DETER_TER_2 = fila.DETER_TER_2,
                            MONTO_MULTA_TER_2 = fila.MONTO_MULTA_TER_2,
                            AMONESTACION_TER_2 = fila.AMONESTACION_TER_2,
                            CADUCIDAD_TER_2 = fila.CADUCIDAD_TER_2,
                            MED_PRECAU_TER_2 = fila.MED_PRECAU_TER_2,
                            MED_CORREC_TER_2 = fila.MED_CORREC_TER_2,
                            INFRACCIONES_TER_2 = fila.INFRACCIONES_TER_2,

                            NUM_RESOLUCION_TFFS_2 = fila.NUM_RESOLUCION_TFFS_2,
                            FECHA_EMISION_TFFS_2 = fila.FECHA_EMISION_TFFS_2,
                            RECURSO_TFFS_2 = fila.RECURSO_TFFS_2,
                            DETERMINA_TFFS_2 = fila.DETERMINA_TFFS_2,
                            MOTIVO_TFFS_2 = fila.MOTIVO_TFFS_2,

                            ESTADO_PAU = fila.ESTADO_PAU,
                            FECHA_ACTUALIZACION = fila.FECHA_ACTUALIZACION,
                        });
                    }
                    break;
            }

            return cSupervisiones;
        }
    }
}