using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidad = CapaEntidad.DOC.Ent_ALERTA;

namespace CapaDatos.DOC
{
    public class Dat_ALERTA
    {
        private DBOracle oGDataORACLE = new DBOracle();

        public List<CEntidad> AlertaListaItems(OracleConnection cn, string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<CEntidad> oCampos = new List<CEntidad>();
            rowCount = 0;
            try
            {
                using (OracleDataReader dr = oGDataORACLE.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPALERTA_OSINFOR_LISTAR", criterio, valorBusqueda, currentPage, pageSize, sort))
                {
                    if (dr != null)
                    {


                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var oCamposDet = new CEntidad();
                                oCamposDet.FECHA = dr.GetValueString("FECHA");
                                oCamposDet.COD_BITACORA = dr.GetValueString("COD_BITACORA");
                                oCamposDet.OD = dr.GetValueString("OD");
                                oCamposDet.SUPERVISOR = dr.GetValueString("SUPERVISOR");
                                oCamposDet.CARTA_NOTIFICACION = dr.GetValueString("CARTA_NOTIFICACION");
                                oCamposDet.NUM_THABILITANTE = dr.GetValueString("NUM_THABILITANTE");
                                oCamposDet.SUPERVISADO = dr.GetValueString("SUPERVISADO");
                                oCamposDet.TIPO_INFORME = dr.GetValueString("TIPO_INFORME");
                                oCamposDet.COD_THABILITANTE = dr.GetValueString("COD_THABILITANTE");
                                oCamposDet.COD_SECUENCIAL = dr.GetValueInt32("COD_SECUENCIAL");
                                oCamposDet.ENVIAR_ALERTA_TEXT = dr.GetValueString("ENVIAR_ALERTA_TEXT");
                                oCamposDet.FECHA_SALIDA = dr.GetValueString("FECHA_SALIDA");
                                oCamposDet.FECHA_LLEGADA = dr.GetValueString("FECHA_LLEGADA");
                                if (criterio == "REGISTROS_USUARIO")
                                {
                                    oCamposDet.USUARIO = dr["USUARIO"].ToString();
                                }

                                oCampos.Add(oCamposDet);
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                }
                            }
                        }
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad EditItemsAlerta(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad ocampoEnt;
            CEntidad lsCEntidad = new CEntidad();

            try
            {
                using (OracleDataReader dr = oGDataORACLE.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_MensajeAlerta", oCEntidad))
                {
                    if (dr != null)
                    {
                        //lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListVertices = new List<CEntidad>();
                        lsCEntidad.ListBitacoras = new List<CEntidad>();
                        lsCEntidad.ListBEXT = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.NUM_THABILITANTE = dr.GetValueString("NUM_THABILITANTE");
                            lsCEntidad.TITULAR = dr.GetValueString("TITULAR");
                            lsCEntidad.NUM_CNOTIFICACION = dr.GetValueString("NUM_CNOTIFICACION");
                            lsCEntidad.SUPERVISOR = dr.GetValueString("SUPERVISOR");
                            lsCEntidad.UBICACION = dr.GetValueString("UBICACION");
                            lsCEntidad.MODALIDAD = dr.GetValueString("MODALIDAD");
                            lsCEntidad.POA = dr.GetValueString("POA");
                            lsCEntidad.FECHA_SALIDA = dr.GetValueString("FECHA_SALIDA");
                            lsCEntidad.FECHA_LLEGADA = dr.GetValueString("FECHA_LLEGADA");
                            lsCEntidad.DESTINO_ENVIO_TEXT = dr.GetValueString("DESTINO_ENVIO_TEXT");
                            lsCEntidad.ARCHIVO_OFICIO = dr.GetValueString("ARCHIVO_OFICIO");
                            lsCEntidad.ARCHIVO_OFICIO_TEXT = dr.GetValueString("ARCHIVO_OFICIO_TEXT");
                            lsCEntidad.COD_CNOTIFICACION = dr.GetValueString("COD_CNOTIFICACION");
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.VERTICE = dr.GetValueString("VERTICE");
                                ocampoEnt.ZONA = dr.GetValueString("ZONA");
                                ocampoEnt.COORDENADA_ESTE = dr.GetValueInt32("COORDENADA_ESTE");
                                ocampoEnt.COORDENADA_NORTE = dr.GetValueInt32("COORDENADA_NORTE");
                                ocampoEnt.OBSERVACIONES = dr.GetValueString("OBSERVACIONES");

                                lsCEntidad.ListVertices.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.ACTA_ARCHIVO = dr.GetValueString("ACTA_ARCHIVO");
                            lsCEntidad.ACTA_ARCHIVO_TEXT = dr.GetValueString("ACTA_ARCHIVO_TEXT");
                            lsCEntidad.ENVIAR_ALERTA = dr.GetValueBoolean("ENVIAR_ALERTA");
                            //CODIGO DE SUPUESTO
                            lsCEntidad.COD_SUPUESTO = dr.GetValueInt32("CODIGO_SUPUESTO");
                            lsCEntidad.SUPUESTO = dr.GetValueString("SUPUESTO_DETALLE");

                            lsCEntidad.FECHA_ENVIO_ALERTA = dr.GetValueString("FECHA_ENVIO_ALERTA");
                            lsCEntidad.ASUNTO_ENVIO_ALERTA = dr.GetValueString("ASUNTO_ENVIO_ALERTA");
                            lsCEntidad.DESTINO_ENVIO_ALERTA = dr.GetValueString("DESTINO_ENVIO_ALERTA");
                            lsCEntidad.CONCOPIA_ENVIO_ALERTA = dr.GetValueString("CONCOPIA_ENVIO_ALERTA");
                            lsCEntidad.MENSAJE_ENVIO_ALERTA = dr.GetValueString("MENSAJE_ENVIO_ALERTA");
                            lsCEntidad.FECHA_ENVIO_ALERTA = dr.GetValueString("FECHA_ENVIO_ALERTA");
                            lsCEntidad.USUARIO_ENVIA = dr.GetValueString("USUARIO_ENVIA");
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {//para mostrar archivos de actas
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_BITACORA = dr.GetValueString("COD_BITACORA");
                                ocampoEnt.COD_THABILITANTE = dr.GetValueString("COD_THABILITANTE");
                                ocampoEnt.COD_SECUENCIAL = dr.GetValueInt32("COD_SECUENCIAL");
                                ocampoEnt.COD_SECUENCIAL_ACTA = dr.GetValueInt32("COD_SECUENCIAL_ACTA");
                                ocampoEnt.NOMBRE_ARCH = dr.GetValueString("NOMBRE_ARCH");
                                ocampoEnt.EXTENSION_ARCH = dr.GetValueString("EXTENSION_ARCH");
                                ocampoEnt.NOMBRE_ARCH_ANTIGUO = dr.GetValueString("NOMBRE_ARCH_ANTIGUO");
                                ocampoEnt.COD_GUID = Guid.NewGuid().ToString();
                                ocampoEnt.RegEstado = 0;

                                lsCEntidad.ListBitacoras.Add(ocampoEnt);
                            }
                        }
                        //AGREGANDO ESPECIES DEL BALANCE A LA BITACORA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_THABILITANTE = dr.GetValueString("COD_THABILITANTE");
                                ocampoEnt.NUM_POA = dr.GetValueInt32("NUM_POA");
                                ocampoEnt.COD_SECUENCIAL = dr.GetValueInt32("COD_SECUENCIAL");
                                ocampoEnt.COD_ESPECIES = dr.GetValueString("COD_ESPECIES");
                                ocampoEnt.ESPECIES = dr.GetValueString("ESPECIE");
                                ocampoEnt.FECHA_BALANCE = dr.GetValueString("FECHA_EMISION_BX");
                                ocampoEnt.TOTAL_ARBOLES = dr.GetValueInt32("TOTAL_ARBOLES");
                                ocampoEnt.VOLUMEN_AUTORIZADO = Decimal.Parse(dr.GetValueString("VOLUMEN_AUTORIZADO"));
                                ocampoEnt.VOLUMEN_MOVILIZADO = Decimal.Parse(dr.GetValueString("VOLUMEN_MOVILIZADO"));
                                ocampoEnt.SALDO = Decimal.Parse(dr.GetValueString("SALDO"));
                                ocampoEnt.NOMBRE_POA = dr.GetValueString("NUM_POA_DETALLE");
                                ocampoEnt.COD_BITACORA = dr.GetValueString("COD_BITACORA");
                                ocampoEnt.COD_CNOTIFICACION = dr.GetValueString("COD_CNOTIFICACION");
                                ocampoEnt.RegEstado = 0;

                                lsCEntidad.ListBEXT.Add(ocampoEnt);
                            }
                        }


                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CEntidad SeguimientoItemsAlerta(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad ocampoEnt;
            CEntidad lsCEntidad = new CEntidad();

            try
            {
                using (OracleDataReader dr = oGDataORACLE.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spALE_Seguimiento_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListDocRecibido = new List<CEntidad>();
                        lsCEntidad.ListRptaEnlace = new List<CEntidad>();
                        //lsCEntidad.ListBitacoras = new List<CEntidad>();
                        //lsCEntidad.ListBEXT = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.NUM_THABILITANTE = dr.GetValueString("NUM_THABILITANTE");
                            lsCEntidad.TITULAR = dr.GetValueString("TITULAR");
                            lsCEntidad.NUM_CNOTIFICACION = dr.GetValueString("NUM_CNOTIFICACION");
                            lsCEntidad.SUPERVISOR = dr.GetValueString("SUPERVISOR");
                            lsCEntidad.UBICACION = dr.GetValueString("UBICACION");
                            lsCEntidad.MODALIDAD = dr.GetValueString("MODALIDAD");
                            lsCEntidad.POA = dr.GetValueString("POA");
                            lsCEntidad.FECHA_SALIDA = dr.GetValueString("FECHA_SALIDA");
                            lsCEntidad.FECHA_LLEGADA = dr.GetValueString("FECHA_LLEGADA");
                            lsCEntidad.DESTINO_ENVIO_TEXT = dr.GetValueString("DESTINO_ENVIO_TEXT");
                            lsCEntidad.ARCHIVO_OFICIO = dr.GetValueString("ARCHIVO_OFICIO");
                            lsCEntidad.ARCHIVO_OFICIO_TEXT = dr.GetValueString("ARCHIVO_OFICIO_TEXT");
                            lsCEntidad.COD_CNOTIFICACION = dr.GetValueString("COD_CNOTIFICACION");
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_DOCRECIBIDO = dr.GetValueInt32("COD_DOCRECIBIDO");
                                ocampoEnt.EXPEDIENTE = dr.GetValueString("EXPEDIENTE");
                                ocampoEnt.FECHA_EXPEDIENTE = Convert.ToDateTime(dr["FECHA_EXPEDIENTE"]).ToShortDateString();
                                ocampoEnt.DOCUMENTO = dr.GetValueString("DOCUMENTO");
                                ocampoEnt.OFICINA = dr.GetValueString("OFICINA");
                                ocampoEnt.OBSERVACIONES = dr.GetValueString("OBSERVACION");

                                lsCEntidad.ListDocRecibido.Add(ocampoEnt);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_RPTAENLACE = dr.GetValueInt32("COD_RPTAENLACE");
                                ocampoEnt.DOCUMENTO = dr.GetValueString("DOCUMENTO");
                                ocampoEnt.FECHA_RESPUESTA = Convert.ToDateTime(dr["FECHA_RESPUESTA"]).ToShortDateString();
                                ocampoEnt.PROCEDIMIENTO = dr.GetValueString("PROCEDIMIENTO");                                
                                ocampoEnt.RECOMENDACION = dr.GetValueString("RECOMENDACION");

                                lsCEntidad.ListRptaEnlace.Add(ocampoEnt);
                            }
                        }

                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public String RegGrabarSeguimiento(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";

            try
            {
                tr = cn.BeginTransaction();

                if (oCEntidad.ListDocRecibido != null)
                {
                    foreach (var loDatos in oCEntidad.ListDocRecibido)
                    {
                        loDatos.COD_BITACORA = oCEntidad.COD_BITACORA;
                        loDatos.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        loDatos.COD_SECUENCIAL = oCEntidad.COD_SECUENCIAL;
                        loDatos.FECHA_EXPEDIENTE = (loDatos.FECHA_EXPEDIENTE == null || loDatos.FECHA_EXPEDIENTE.ToString() == "") ? (DateTime?)null : Convert.ToDateTime(loDatos.FECHA_EXPEDIENTE);
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        loDatos.RegEstado = oCEntidad.RegEstado;
                        loDatos.OUTPUTPARAM01 = "";

                        using (OracleCommand cmd = oGDataORACLE.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spALE_ALERDETDOCRECIBIDO_Registrar", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;


                        }
                    }

                }
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }


        public String RegGrabarRptaEnlace(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";

            try
            {
                tr = cn.BeginTransaction();

                if (oCEntidad.ListRptaEnlace != null)
                {
                    foreach (var loDatos in oCEntidad.ListRptaEnlace)
                    {                        
                        loDatos.FECHA_EXPEDIENTE = (loDatos.FECHA_EXPEDIENTE == null || loDatos.FECHA_EXPEDIENTE.ToString() == "") ? (DateTime?)null : Convert.ToDateTime(loDatos.FECHA_EXPEDIENTE);
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        loDatos.RegEstado = oCEntidad.RegEstado;
                        loDatos.OUTPUTPARAM01 = "";

                        using (OracleCommand cmd = oGDataORACLE.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spALE_ALERDETRPTAENLACE_Registrar", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;


                        }
                    }

                }
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }


        public String RegGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            CEntidad oCamposCorreo;
            //temporal de path de archivos. si sucede un error eliminamos
            List<string> lstPath = new List<string>();
            //almacenar archivos path de rchivos eliminados de bd
            List<string> lstPathEliTabla = new List<string>();
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = oGDataORACLE.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_BITACORA = OUTPUTPARAM01;
                }
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    string rutaBase = System.AppDomain.CurrentDomain.BaseDirectory;
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        if ((loDatos.EliTABLA != "BITACORA_SUPERVISIONES_DET_INFOGEO" && loDatos.EliTABLA != "BITACORA_SUPERVISIONES_DET_ACTA")
                            || (loDatos.EliTABLA == "BITACORA_SUPERVISIONES_DET_INFOGEO" && loDatos.RegEstado == 0) || (loDatos.EliTABLA == "BITACORA_BALANCE" && loDatos.RegEstado == 0))
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
                            oCamposDet.EliTABLA = loDatos.EliTABLA;
                            oCamposDet.COD_SUPERVISOR = loDatos.COD_SUPERVISOR;
                            oCamposDet.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                            oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_INFOGEO = loDatos.COD_INFOGEO;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oGDataORACLE.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
                        }
                        //eliminando archivos acta
                        if (loDatos.EliTABLA == "BITACORA_SUPERVISIONES_DET_ACTA" && loDatos.RegEstado == 0)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
                            oCamposDet.EliTABLA = loDatos.EliTABLA;
                            oCamposDet.COD_SUPERVISOR = null;
                            oCamposDet.COD_CNOTIFICACION = null;
                            oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_SECUENCIAL_ACTA = loDatos.COD_SECUENCIAL_ACTA;
                            // oCamposDet.COD_INFOGEO = null;
                            oGDataORACLE.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
                            string nombreArchivo = oCamposDet.COD_BITACORA + oCamposDet.COD_SECUENCIAL_ACTA.ToString() + "." + loDatos.EXTENSION_ARCH;
                            if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo)))
                            {
                                //moviendo archivos a la carpeta historial
                                System.IO.File.Copy(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo), System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Historico/" + nombreArchivo));
                                lstPathEliTabla.Add(nombreArchivo);
                                //eliminando 
                                System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
                            }
                        }
                    }
                }

                //Grabando Detalle Supervisores
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
                            oCamposDet.COD_SUPERVISOR = loDatos.COD_PERSONA;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oGDataORACLE.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISIONES_DET_SUPERVISOR_Grabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle Cartas de Notificación
                if (oCEntidad.ListBitacoras != null)
                {
                    int i = 0;
                    CEntidad oInfoGeo;
                    string rutaBase = System.AppDomain.CurrentDomain.BaseDirectory;
                    foreach (var loDatos in oCEntidad.ListBitacoras)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                            oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            if (loDatos.SUPERVISADO_TEXT == "") { oCamposDet.SUPERVISADO = null; }
                            else if (loDatos.SUPERVISADO_TEXT == "SI") { oCamposDet.SUPERVISADO = true; }
                            else if (loDatos.SUPERVISADO_TEXT == "NO") { oCamposDet.SUPERVISADO = false; }
                            if (loDatos.COD_ITIPO != "0000000") { oCamposDet.COD_ITIPO = loDatos.COD_ITIPO; }
                            oCamposDet.OBSERVACIONES = loDatos.OBSERVACIONES;
                            oCamposDet.COD_REQUE = loDatos.COD_REQUE;
                            if (loDatos.ALERTA_ILEGAL_TEXT == "") { oCamposDet.ALERTA_ILEGAL = null; }
                            else if (loDatos.ALERTA_ILEGAL_TEXT == "SI") { oCamposDet.ALERTA_ILEGAL = true; }
                            else if (loDatos.ALERTA_ILEGAL_TEXT == "NO") { oCamposDet.ALERTA_ILEGAL = false; }
                            oCamposDet.DES_ALERTA_ILEGAL = loDatos.DES_ALERTA_ILEGAL;
                            oCamposDet.VOLUMEN_INJUSTIFICADO = loDatos.VOLUMEN_INJUSTIFICADO;
                            oCamposDet.OTROS_HECHO = loDatos.OTROS_HECHO;
                            oCamposDet.ACTA_ARCHIVO = loDatos.ACTA_ARCHIVO;
                            oCamposDet.ACTA_ARCHIVO_TEXT = loDatos.ACTA_ARCHIVO_TEXT;
                            oCamposDet.NOTIFICAR_ARCHIVO = loDatos.NOTIFICAR_ARCHIVO;
                            oCamposDet.ARCHIVOS_NTF = loDatos.ARCHIVOS_NTF;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oCamposDet.FECHA_INICIO_SUPERVISION = loDatos.FECHA_INICIO_SUPERVISION;
                            oCamposDet.FECHA_FIN_SUPERVISION = loDatos.FECHA_FIN_SUPERVISION;
                            oCamposDet.OUTPUTPARAMDET01 = "";

                            using (OracleCommand cmd = oGDataORACLE.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_DET_CARTAS_Grabar", oCamposDet))
                            {
                                cmd.ExecuteNonQuery();
                                oCamposDet.COD_SECUENCIAL = Convert.ToInt32(cmd.Parameters["OUTPUTPARAMDET01"].Value);
                                loDatos.COD_SECUENCIAL = oCamposDet.COD_SECUENCIAL;
                            }

                            //Grabando información geográfica (archivos)
                            if (oCEntidad.ListBitacoras[i].ListInfoGeo != null)
                            {
                                foreach (var infogeo in oCEntidad.ListBitacoras[i].ListInfoGeo)
                                {
                                    if (infogeo.RegEstado == 1 || infogeo.RegEstado == 2)
                                    {
                                        oInfoGeo = new CEntidad();
                                        oInfoGeo.COD_BITACORA = oCEntidad.COD_BITACORA;
                                        oInfoGeo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                                        oInfoGeo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                                        oInfoGeo.COD_INFOGEO = infogeo.COD_INFOGEO;
                                        oInfoGeo.NOMBRE_ARCH = infogeo.NOMBRE_ARCH;
                                        oInfoGeo.EXTENSION_ARCH = infogeo.EXTENSION_ARCH;
                                        oInfoGeo.RUTA_ARCH = infogeo.RUTA_ARCH;
                                        oInfoGeo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                        oInfoGeo.RegEstado = infogeo.RegEstado;
                                        oGDataORACLE.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISIONES_DET_INFOGEO_Grabar", oInfoGeo);
                                    }
                                }
                            }
                            //Grabando Acta (archivos)
                            if (oCEntidad.ListBitacoras[i].ListDetActa != null)
                            {
                                string nombreArchivo = "";
                                foreach (var infogeo in oCEntidad.ListBitacoras[i].ListDetActa)
                                {
                                    if (infogeo.RegEstado == 1 || infogeo.RegEstado == 2)
                                    {
                                        oInfoGeo = new CEntidad();
                                        oInfoGeo.COD_BITACORA = oCEntidad.COD_BITACORA;
                                        oInfoGeo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                                        oInfoGeo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                                        oInfoGeo.COD_SECUENCIAL_ACTA = infogeo.COD_SECUENCIAL_ACTA;
                                        oInfoGeo.NOMBRE_ARCH = infogeo.NOMBRE_ARCH;
                                        oInfoGeo.EXTENSION_ARCH = infogeo.EXTENSION_ARCH;
                                        oInfoGeo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                        oInfoGeo.RegEstado = infogeo.RegEstado;
                                        oInfoGeo.OUTPUTPARAMDET01 = "";
                                        using (OracleCommand cmd = oGDataORACLE.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISIONES_DET_ACTA_GrabarV3", oInfoGeo))
                                        {
                                            cmd.ExecuteNonQuery();
                                            oInfoGeo.COD_SECUENCIAL_ACTA = Convert.ToInt32(cmd.Parameters["OUTPUTPARAMDET01"].Value);
                                        }
                                        nombreArchivo = oCamposDet.COD_BITACORA + oInfoGeo.COD_SECUENCIAL_ACTA.ToString() + "." + oInfoGeo.EXTENSION_ARCH;
                                        if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + infogeo.ARCHIVOS)))
                                        {
                                            //Grabando archivos
                                            System.IO.File.Copy(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + infogeo.ARCHIVOS), System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
                                            lstPath.Add(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
                                            //eliminando temporal
                                            System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + infogeo.ARCHIVOS));
                                        }
                                    }
                                }
                            }
                            //GRABANDO ESPECIES DEL BALANACE
                            if (oCEntidad.ListBitacoras[i].ListBEXT != null)
                            {
                                foreach (var balance in oCEntidad.ListBitacoras[i].ListBEXT)
                                {
                                    if (balance.RegEstado == 1 || balance.RegEstado == 2)
                                    {
                                        CEntidad ocampoEntBx = new CEntidad();
                                        ocampoEntBx.COD_BITACORA = oCEntidad.COD_BITACORA;
                                        ocampoEntBx.COD_THABILITANTE = balance.COD_THABILITANTE;
                                        ocampoEntBx.NUM_POA = balance.NUM_POA;
                                        ocampoEntBx.COD_SECUENCIAL = balance.COD_SECUENCIAL;
                                        ocampoEntBx.COD_ESPECIES = balance.COD_ESPECIES;
                                        ocampoEntBx.RegEstado = balance.RegEstado;
                                        ocampoEntBx.COD_CNOTIFICACION = oCEntidad.ListBitacoras[i].COD_CNOTIFICACION;
                                        //ocampoEntBx.OUTPUTPARAMDET01 = "";
                                        using (OracleCommand cmd = oGDataORACLE.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACIONOC.spBITACORA_BX_GRABAR", ocampoEntBx))
                                        {
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                        i++;
                    }
                }
                oCamposCorreo = new CEntidad();
                oCamposCorreo.COD_BITACORA = oCEntidad.COD_BITACORA;
                oCamposCorreo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                oCamposCorreo.COD_OD = oCEntidad.COD_OD;
                oCamposCorreo.RegEstado = oCEntidad.RegEstado;
                using (OracleCommand cmd = oGDataORACLE.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACIONOC.spBITACORA_SUPERVISION_Correo", oCamposCorreo))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                }
                ///Grabando Detalle THABILITANTE_DGENERAL_ADENDA_AREA
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                //eliminando archivos si salio mal las cosas
                if (lstPath.Count > 0)
                {
                    for (int m = 0; m < lstPath.Count; m++)
                    {
                        if (System.IO.File.Exists(lstPath[m]))
                        {
                            System.IO.File.Delete(lstPath[m]);
                        }
                    }
                }
                if (lstPathEliTabla.Count > 0)
                {
                    string rutaBase = System.AppDomain.CurrentDomain.BaseDirectory;
                    for (int i = 0; i < lstPathEliTabla.Count; i++)
                    {
                        if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Historico/" + lstPathEliTabla[i])))
                        {
                            //si hay error regresamos los archivos a su carpeta original
                            System.IO.File.Copy(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Historico/" + lstPathEliTabla[i]), System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + lstPathEliTabla[i]));
                            //eliminando 
                            System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Historico/" + lstPathEliTabla[i]));
                        }
                    }
                }

                throw ex;
            }

        }

        public List<VM_Cbo> RegMostComboOficinaDesconcentrada(String codigoCuentaU, String busFormulario)
        {
            CEntidad oCEntidad = new CEntidad();
            oCEntidad.COD_UCUENTA = codigoCuentaU;
            oCEntidad.BUSFORMULARIO = busFormulario;
            List<VM_Cbo> lstCampos = new List<VM_Cbo>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    using (OracleDataReader dr = oGDataORACLE.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var oCamposDet = new VM_Cbo();
                                    oCamposDet.Value = dr.GetValueString("CODIGO");
                                    oCamposDet.Text = dr.GetValueString("DESCRIPCION");
                                    lstCampos.Add(oCamposDet);
                                }
                            }

                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lstCampos;
        }

        public String RegGrabarBitacoraBXConfirmacion(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCamposDet;
            String OUTPUTPARAM01 = "";
            OracleTransaction tr = null;
            try
            {
                tr = cn.BeginTransaction();
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        if (loDatos.EliTABLA == "BITACORA_BALANCE" && loDatos.RegEstado == 0)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
                            oCamposDet.EliTABLA = loDatos.EliTABLA;
                            oCamposDet.COD_SUPERVISOR = loDatos.COD_SUPERVISOR;
                            oCamposDet.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                            oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_INFOGEO = loDatos.COD_INFOGEO;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oGDataORACLE.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
                            OUTPUTPARAM01 = oCEntidad.COD_BITACORA;
                        }
                    }
                }

                //GRABANDO ESPECIES DEL BALANACE
                if (oCEntidad.ListBEXT != null)
                {
                    foreach (var balance in oCEntidad.ListBEXT)
                    {
                        if (balance.RegEstado == 1 || balance.RegEstado == 2)
                        {
                            CEntidad ocampoEntBx = new CEntidad();
                            ocampoEntBx.COD_BITACORA = oCEntidad.COD_BITACORA;
                            ocampoEntBx.COD_THABILITANTE = balance.COD_THABILITANTE;
                            ocampoEntBx.NUM_POA = balance.NUM_POA;
                            ocampoEntBx.COD_SECUENCIAL = balance.COD_SECUENCIAL;
                            ocampoEntBx.COD_ESPECIES = balance.COD_ESPECIES;
                            ocampoEntBx.RegEstado = balance.RegEstado;
                            ocampoEntBx.COD_CNOTIFICACION = oCEntidad.COD_CNOTIFICACION;
                            //ocampoEntBx.OUTPUTPARAMDET01 = "";
                            using (OracleCommand cmd = oGDataORACLE.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_BX_GRABAR", ocampoEntBx))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            OUTPUTPARAM01 = oCEntidad.COD_BITACORA;
                        }
                    }
                }
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }

        public String RegEnviarAlerta(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = oGDataORACLE.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_EnviarAlerta", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                }
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }
        public List<CEntidad> RegEspecieBExt(string COD_CNOTIFICACION)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = oGDataORACLE.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spRESODIREC_BALANCE_EXTRA_ALERT", COD_CNOTIFICACION))
                    {
                        if (dr != null)
                        {
                            CEntidad ocampoEnt;
                            if (dr.HasRows)
                            {
                                int pt0 = dr.GetOrdinal("COD_THABILITANTE");
                                int pt1 = dr.GetOrdinal("NUM_POA");
                                int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                                int pt3 = dr.GetOrdinal("COD_ESPECIES");
                                int pt4 = dr.GetOrdinal("ESPECIE");
                                int pt5 = dr.GetOrdinal("FECHA_EMISION_BX");
                                int pt6 = dr.GetOrdinal("TOTAL_ARBOLES");
                                int pt7 = dr.GetOrdinal("VOLUMEN_AUTORIZADO");
                                int pt8 = dr.GetOrdinal("VOLUMEN_MOVILIZADO");
                                int pt9 = dr.GetOrdinal("SALDO");
                                int pt10 = dr.GetOrdinal("NUM_POA_DETALLE");

                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidad();

                                    ocampoEnt.COD_THABILITANTE = dr.GetString(pt0);
                                    ocampoEnt.NUM_POA = dr.GetInt32(pt1);
                                    ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt2);
                                    ocampoEnt.COD_ESPECIES = dr.GetString(pt3);
                                    ocampoEnt.ESPECIES = dr.GetString(pt4);
                                    ocampoEnt.FECHA_BALANCE = dr.GetString(pt5);
                                    ocampoEnt.TOTAL_ARBOLES = dr.GetInt32(pt6);
                                    ocampoEnt.VOLUMEN_AUTORIZADO = dr.GetDecimal(pt7);
                                    ocampoEnt.VOLUMEN_MOVILIZADO = dr.GetDecimal(pt8);
                                    ocampoEnt.SALDO = dr.GetDecimal(pt9);
                                    ocampoEnt.NOMBRE_POA = dr.GetString(pt10);
                                    ocampoEnt.RegEstado = 1;
                                    lsCEntidad.Add(ocampoEnt);
                                }
                            }
                        }
                    }
                }

                return lsCEntidad;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad GetDestinatarios_CC(OracleConnection cn, string supuesto)
        {
            CEntidad oCampos = null;
            try
            {


                using (OracleDataReader dr = oGDataORACLE.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spALERT_DestinatarioCC_Listar", supuesto))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;

                        //Destinatarios sin Copia
                        lsDetDetalle = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("CORREO");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();

                                oCamposDet.DESTINATARIO = dr.GetString(pt0);
                                oCamposDet.RegEstado = 1;
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListDestinatario = lsDetDetalle;
                        dr.NextResult();
                        //Destinatarios con Copia
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("CORREO");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();

                                oCamposDet.DESTINATARIO = dr.GetString(pt0);
                                oCamposDet.RegEstado = 1;
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListDestinatarioCC = lsDetDetalle;
                    }
                }


                return oCampos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad GetRegRespuesta(OracleConnection cn, string token)
        {
            CEntidad oCampos = null;
            try
            {


                using (OracleDataReader dr = oGDataORACLE.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spALERT_TokenLink_Validar", token))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;

                        //Destinatarios sin Copia
                        lsDetDetalle = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_BITACORA");
                            int pt1 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt3 = dr.GetOrdinal("CORREO");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();

                                oCamposDet.COD_BITACORA = dr.GetString(pt0);
                                oCamposDet.COD_THABILITANTE = dr.GetString(pt1);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt16(pt2);
                                oCamposDet.DESTINATARIO = dr.GetString(pt3);
                                oCamposDet.RegEstado = 1;
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListRptaEnlace = lsDetDetalle;
                        dr.NextResult();
                    }
                }


                return oCampos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = oGDataORACLE.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;

                        //Especies
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetValueString("CODIGO");
                                oCamposDet.DESCRIPCION = dr.GetValueString("DESCRIPCION");
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListOD = lsDetDetalle;

                        //Supervision Concepto
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetValueString("CODIGO");
                                oCamposDet.DESCRIPCION = dr.GetValueString("DESCRIPCION");
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListInformeTipo = lsDetDetalle;
                        //Departamentos
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetValueString("COD_UBIDEPARTAMENTO");
                                oCamposDet.DESCRIPCION = dr.GetValueString("DEPARTAMENTO");
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListDepartamentos = lsDetDetalle;
                        //Supuesto
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetValueString("CODIGO");
                                oCamposDet.DESCRIPCION = dr.GetValueString("DESCRIPCION");
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListSupuestos = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Dictionary<string, string>> GetAllRutaDestino(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lsCEntidad = new List<Dictionary<string, string>>();
            try
            {
                using (OracleDataReader dr = oGDataORACLE.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.USP_GETALL_RUTA_DESTINO_V3", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            string[] colums;
                            if (oCEntidad.BUSCRITERIO == "TRAMO")
                            {
                                colums = new string[] { "COD_RUTA", "COD_UBIDEPARTAMENTO", "TRAMO", "DEPARTAMENTO", "ORIGEN_DESTINO" };
                            }
                            else
                            {
                                colums = new string[] { "COD_RUTA", "COD_DESTINATARIO", "COD_DESTINATARIO_RUTA", "TRAMO", "ORIGEN_DESTINO", "DESCRIPCION", "CORREO"
                                                        ,"DEPARTAMENTO","CARGO","OFICINA"};
                            }
                            lsCEntidad = CreateList(dr, colums);
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<Dictionary<string, string>> CreateList(OracleDataReader reader, string[] campos)
        {
            var results = new List<Dictionary<string, string>>();
            var properties = typeof(Dictionary<string, string>).GetProperties();

            while (reader.Read())
            {
                var item = new Dictionary<string, string>();
                foreach (string text in campos)
                {
                    Type ss = reader[text].GetType();
                    item.Add(text, reader[text].ToString());
                }
                item.Add("RegEstado", "0");
                results.Add(item);
            }
            return results;
        }

    }
}
