using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_BITACORA_SUPER;
using CEntPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_BITACORA_SUPER
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();

        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //
                        //Especies
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
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
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
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
                                oCamposDet.CODIGO = dr["COD_UBIDEPARTAMENTO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DEPARTAMENTO"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListDepartamentos = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<CEntidad> RegMostrarLista(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos;
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
        //                        oCampos.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
        //                        oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
        //                        oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                        oCampos.TITULAR = dr["TITULAR"].ToString();
        //                        oCampos.POA = dr["POA"].ToString();
        //                        lsCEntidad.Add(oCampos);
        //                    }
        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    CEntidad oCamposDet;
        //    CEntidad oCamposCorreo;
        //    //temporal de path de archivos. si sucede un error eliminamos
        //    List<string> lstPath = new List<string>();
        //    //almacenar archivos path de rchivos eliminados de bd
        //    List<string> lstPathEliTabla = new List<string>();
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spBITACORA_SUPERVISION_Grabar", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //        }
        //        //Reemplazando El Nuevo Codigo Creado
        //        if (oCEntidad.RegEstado == 1) //Nuevo
        //        {
        //            oCEntidad.COD_BITACORA = OUTPUTPARAM01;
        //        }


        //        //
        //        //Eliminando Detalle
        //        if (oCEntidad.ListEliTABLA != null)
        //        {
        //            string rutaBase = System.AppDomain.CurrentDomain.BaseDirectory;


        //            //try
        //            //{
        //            //    File.Delete(Path.Combine(rutaBase, "Archivos/Archivo_Capacitacion/" + nombreArchivo));
        //            //}
        //            //catch (Exception) { }                   
        //            foreach (var loDatos in oCEntidad.ListEliTABLA)
        //            {
        //                if ((loDatos.EliTABLA != "BITACORA_SUPERVISIONES_DET_INFOGEO" && loDatos.EliTABLA != "BITACORA_SUPERVISIONES_DET_ACTA")
        //                    || (loDatos.EliTABLA == "BITACORA_SUPERVISIONES_DET_INFOGEO" && loDatos.RegEstado == 0) || (loDatos.EliTABLA == "BITACORA_BALANCE" && loDatos.RegEstado == 0))
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
        //                    oCamposDet.EliTABLA = loDatos.EliTABLA;
        //                    oCamposDet.COD_SUPERVISOR = loDatos.COD_SUPERVISOR;
        //                    oCamposDet.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_INFOGEO = loDatos.COD_INFOGEO;
        //                    oCamposDet.NUM_POA = loDatos.NUM_POA;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
        //                }
        //                //eliminando archivos acta
        //                if (loDatos.EliTABLA == "BITACORA_SUPERVISIONES_DET_ACTA" && loDatos.RegEstado == 0)
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
        //                    oCamposDet.EliTABLA = loDatos.EliTABLA;
        //                    oCamposDet.COD_SUPERVISOR = null;
        //                    oCamposDet.COD_CNOTIFICACION = null;
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_SECUENCIAL_ACTA = loDatos.COD_SECUENCIAL_ACTA;
        //                    // oCamposDet.COD_INFOGEO = null;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
        //                    string nombreArchivo = oCamposDet.COD_BITACORA + oCamposDet.COD_SECUENCIAL_ACTA.ToString() + "." + loDatos.EXTENSION_ARCH;
        //                    if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo)))
        //                    {    //moviendo archivos a la carpeta historial
        //                        System.IO.File.Copy(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo), System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Historico/" + nombreArchivo));
        //                        lstPathEliTabla.Add(nombreArchivo);
        //                        //eliminando 
        //                        System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
        //                    }
        //                }
        //            }
        //        }
        //        //
        //        //Grabando Detalle Supervisores
        //        if (oCEntidad.ListInformeDetSupervisor != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
        //                    oCamposDet.COD_SUPERVISOR = loDatos.COD_PERSONA;
        //                    oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spBITACORA_SUPERVISIONES_DET_SUPERVISOR_Grabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //Grabando Detalle Cartas de Notificación
        //        if (oCEntidad.ListBitacoras != null)
        //        {
        //            int i = 0;
        //            CEntidad oInfoGeo;
        //            string rutaBase = System.AppDomain.CurrentDomain.BaseDirectory;
        //            foreach (var loDatos in oCEntidad.ListBitacoras)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
        //                    oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
        //                    oCamposDet.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    if (loDatos.SUPERVISADO_TEXT == "") { oCamposDet.SUPERVISADO = null; }
        //                    else if (loDatos.SUPERVISADO_TEXT == "SI") { oCamposDet.SUPERVISADO = true; }
        //                    else if (loDatos.SUPERVISADO_TEXT == "NO") { oCamposDet.SUPERVISADO = false; }
        //                    if (loDatos.COD_ITIPO != "0000000") { oCamposDet.COD_ITIPO = loDatos.COD_ITIPO; }
        //                    oCamposDet.OBSERVACIONES = loDatos.OBSERVACIONES;
        //                    oCamposDet.COD_REQUE = loDatos.COD_REQUE;
        //                    if (loDatos.ALERTA_ILEGAL_TEXT == "") { oCamposDet.ALERTA_ILEGAL = null; }
        //                    else if (loDatos.ALERTA_ILEGAL_TEXT == "SI") { oCamposDet.ALERTA_ILEGAL = true; }
        //                    else if (loDatos.ALERTA_ILEGAL_TEXT == "NO") { oCamposDet.ALERTA_ILEGAL = false; }
        //                    oCamposDet.DES_ALERTA_ILEGAL = loDatos.DES_ALERTA_ILEGAL;
        //                    oCamposDet.VOLUMEN_INJUSTIFICADO = loDatos.VOLUMEN_INJUSTIFICADO;
        //                    oCamposDet.OTROS_HECHO = loDatos.OTROS_HECHO;
        //                    oCamposDet.ACTA_ARCHIVO = loDatos.ACTA_ARCHIVO;
        //                    oCamposDet.ACTA_ARCHIVO_TEXT = loDatos.ACTA_ARCHIVO_TEXT;
        //                    oCamposDet.NOTIFICAR_ARCHIVO = loDatos.NOTIFICAR_ARCHIVO;
        //                    oCamposDet.ARCHIVOS_NTF = loDatos.ARCHIVOS_NTF;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oCamposDet.FECHA_INICIO_SUPERVISION = loDatos.FECHA_INICIO_SUPERVISION;
        //                    oCamposDet.FECHA_FIN_SUPERVISION = loDatos.FECHA_FIN_SUPERVISION;
        //                    oCamposDet.OUTPUTPARAMDET01 = "";

        //                    using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spBITACORA_SUPERVISION_DET_CARTAS_Grabar", oCamposDet))
        //                    {
        //                        cmd.ExecuteNonQuery();
        //                        oCamposDet.COD_SECUENCIAL = Convert.ToInt32(cmd.Parameters["@OUTPUTPARAMDET01"].Value);
        //                        loDatos.COD_SECUENCIAL = oCamposDet.COD_SECUENCIAL;
        //                    }

        //                    //Grabando información geográfica (archivos)
        //                    if (oCEntidad.ListBitacoras[i].ListInfoGeo != null)
        //                    {
        //                        foreach (var infogeo in oCEntidad.ListBitacoras[i].ListInfoGeo)
        //                        {
        //                            if (infogeo.RegEstado == 1 || infogeo.RegEstado == 2)
        //                            {
        //                                oInfoGeo = new CEntidad();
        //                                oInfoGeo.COD_BITACORA = oCEntidad.COD_BITACORA;
        //                                oInfoGeo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                                oInfoGeo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                                oInfoGeo.COD_INFOGEO = infogeo.COD_INFOGEO;
        //                                oInfoGeo.NOMBRE_ARCH = infogeo.NOMBRE_ARCH;
        //                                oInfoGeo.EXTENSION_ARCH = infogeo.EXTENSION_ARCH;
        //                                oInfoGeo.RUTA_ARCH = infogeo.RUTA_ARCH;
        //                                oInfoGeo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
        //                                oInfoGeo.RegEstado = infogeo.RegEstado;

        //                                oGDataSQL.ManExecute(cn, tr, "DOC.spBITACORA_SUPERVISIONES_DET_INFOGEO_Grabar", oInfoGeo);
        //                            }
        //                        }
        //                    }
        //                    //Grabando Acta (archivos)                            
        //                    if (oCEntidad.ListBitacoras[i].ListDetActa != null)
        //                    {
        //                        string nombreArchivo = "";
        //                        foreach (var infogeo in oCEntidad.ListBitacoras[i].ListDetActa)
        //                        {
        //                            if (infogeo.RegEstado == 1 || infogeo.RegEstado == 2)
        //                            {
        //                                oInfoGeo = new CEntidad();
        //                                oInfoGeo.COD_BITACORA = oCEntidad.COD_BITACORA;
        //                                oInfoGeo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                                oInfoGeo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                                oInfoGeo.COD_SECUENCIAL_ACTA = infogeo.COD_SECUENCIAL_ACTA;
        //                                oInfoGeo.NOMBRE_ARCH = infogeo.NOMBRE_ARCH;
        //                                oInfoGeo.EXTENSION_ARCH = infogeo.EXTENSION_ARCH;
        //                                oInfoGeo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
        //                                oInfoGeo.RegEstado = infogeo.RegEstado;
        //                                oInfoGeo.OUTPUTPARAMDET01 = "";
        //                                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spBITACORA_SUPERVISIONES_DET_ACTA_GrabarV3", oInfoGeo))
        //                                {
        //                                    cmd.ExecuteNonQuery();
        //                                    oInfoGeo.COD_SECUENCIAL_ACTA = Convert.ToInt32(cmd.Parameters["@OUTPUTPARAMDET01"].Value);
        //                                }
        //                                nombreArchivo = oCamposDet.COD_BITACORA + oInfoGeo.COD_SECUENCIAL_ACTA.ToString() + "." + oInfoGeo.EXTENSION_ARCH;
        //                                if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + infogeo.ARCHIVOS)))
        //                                {   //Grabando archivos
        //                                    System.IO.File.Copy(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + infogeo.ARCHIVOS), System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
        //                                    lstPath.Add(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
        //                                    //eliminando temporal
        //                                    System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + infogeo.ARCHIVOS));

        //                                }

        //                            }
        //                        }
        //                    }
        //                    /**
        //                     * GRABANDO ESPECIES DEL BALANACE
        //                     */
        //                    if (oCEntidad.ListBitacoras[i].ListBEXT != null)
        //                    {
        //                        foreach (var balance in oCEntidad.ListBitacoras[i].ListBEXT)
        //                        {
        //                            if (balance.RegEstado == 1 || balance.RegEstado == 2)
        //                            {
        //                                CEntidad ocampoEntBx = new CEntidad();
        //                                ocampoEntBx.COD_BITACORA = oCEntidad.COD_BITACORA;
        //                                ocampoEntBx.COD_THABILITANTE = balance.COD_THABILITANTE;
        //                                ocampoEntBx.NUM_POA = balance.NUM_POA;
        //                                ocampoEntBx.COD_SECUENCIAL = balance.COD_SECUENCIAL;
        //                                ocampoEntBx.COD_ESPECIES = balance.COD_ESPECIES;
        //                                ocampoEntBx.RegEstado = balance.RegEstado;
        //                                ocampoEntBx.COD_CNOTIFICACION = oCEntidad.ListBitacoras[i].COD_CNOTIFICACION;
        //                                //ocampoEntBx.OUTPUTPARAMDET01 = "";
        //                                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spBITACORA_BX_GRABAR", ocampoEntBx))
        //                                {
        //                                    cmd.ExecuteNonQuery();
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //                i++;
        //            }
        //        }
        //        oCamposCorreo = new CEntidad();
        //        oCamposCorreo.COD_BITACORA = oCEntidad.COD_BITACORA;
        //        oCamposCorreo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
        //        oCamposCorreo.COD_OD = oCEntidad.COD_OD;
        //        oCamposCorreo.RegEstado = oCEntidad.RegEstado;
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spBITACORA_SUPERVISION_Correo", oCamposCorreo))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //        }


        //        ///<summary>
        //        ///Grabando Detalle THABILITANTE_DGENERAL_ADENDA_AREA
        //        ///</summary>

        //        //
        //        tr.Commit();
        //        return OUTPUTPARAM01;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        //eliminando archivos si salio mal las cosas
        //        if (lstPath.Count > 0)
        //        {
        //            for (int m = 0; m < lstPath.Count; m++)
        //            {
        //                if (System.IO.File.Exists(lstPath[m]))
        //                {
        //                    System.IO.File.Delete(lstPath[m]);
        //                }
        //            }
        //        }
        //        if (lstPathEliTabla.Count > 0)
        //        {
        //            string rutaBase = System.AppDomain.CurrentDomain.BaseDirectory;
        //            for (int i = 0; i < lstPathEliTabla.Count; i++)
        //            {
        //                if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Historico/" + lstPathEliTabla[i])))
        //                {    //si hay error regresamos los archivos a su carpeta original
        //                    System.IO.File.Copy(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Historico/" + lstPathEliTabla[i]), System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + lstPathEliTabla[i]));
        //                    //eliminando 
        //                    System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Historico/" + lstPathEliTabla[i]));
        //                }
        //            }
        //        }

        //        throw ex;
        //    }
        //}

        //public CEntidad RegMostrarBitacora(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad lsCEntidad = new CEntidad();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spBITACORA_SUPERVISION_MostItems", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
        //                lsCEntidad.ListBitacoras = new List<CEntidad>();
        //                lsCEntidad.ListEliTABLA = new List<CEntidad>();
        //                //CEntPresupSuper ocampodet;
        //                CEntidad ocampoEnt;
        //                CEntPersona ocampoEntPersona;

        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    lsCEntidad.FECHA_SALIDA = dr["FECHA_SALIDA"].ToString();
        //                    lsCEntidad.FECHA_RECEPCION_CHEQUE = dr["FECHA_RECEPCION_CHEQUE"].ToString();
        //                    lsCEntidad.FECHA_COBRO_CHEQUE = dr["FECHA_COBRO_CHEQUE"].ToString();
        //                    lsCEntidad.FECHA_LLEGADA = dr["FECHA_LLEGADA"].ToString();
        //                    lsCEntidad.COD_OD = dr["COD_OD"].ToString();
        //                    lsCEntidad.OBSERVACIONES = dr["OBSERVACIONES"].ToString();
        //                    lsCEntidad.FECHA_RETORNO_CAMPO = dr["FECHA_RETORNO_CAMPO"].ToString();

        //                    var oCapAux = dr["CAPACITACION_PAUXILIOS"];
        //                    if (!DBNull.Value.Equals(oCapAux))
        //                        lsCEntidad.CAPACITACION_PAUXILIOS = Convert.ToBoolean(oCapAux);
        //                    var oCapInc = dr["CAPACITACION_INCIDENTES"];
        //                    if (!DBNull.Value.Equals(oCapInc))
        //                        lsCEntidad.CAPACITACION_INCIDENTES = Convert.ToBoolean(oCapInc);
        //                }
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEntPersona = new CEntPersona();
        //                        ocampoEntPersona.COD_PERSONA = dr["COD_SUPERVISOR"].ToString();
        //                        ocampoEntPersona.APE_PATERNO = dr["APE_PATERNO"].ToString();
        //                        ocampoEntPersona.APE_MATERNO = dr["APE_MATERNO"].ToString();
        //                        ocampoEntPersona.NOMBRES = dr["NOMBRES"].ToString();
        //                        ocampoEntPersona.PERSONA = dr["NOMBRE_SUPERVISOR"].ToString();
        //                        ocampoEntPersona.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
        //                        ocampoEntPersona.COD_DIDENTIDAD = dr["COD_DIDENTIDAD"].ToString();
        //                        ocampoEntPersona.COD_NACADEMICO = dr["COD_NACADEMICO"].ToString();
        //                        ocampoEntPersona.COD_DPESPECIALIDAD = dr["COD_DPESPECIALIDAD"].ToString();
        //                        ocampoEntPersona.COLEGIATURA_NUM = dr["COLEGIATURA_NUM"].ToString();
        //                        ocampoEntPersona.CARGO = dr["CARGO"].ToString();
        //                        ocampoEntPersona.COD_PTIPO = "0000007";
        //                        ocampoEntPersona.RegEstado = 0;
        //                        lsCEntidad.ListInformeDetSupervisor.Add(ocampoEntPersona);
        //                    }
        //                }

        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidad();
        //                        ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        ocampoEnt.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                        ocampoEnt.TITULAR = dr["TITULAR"].ToString();
        //                        ocampoEnt.POA = dr["POA"].ToString();
        //                        ocampoEnt.POAS = dr["POAS"].ToString();
        //                        ocampoEnt.MODALIDAD = dr["MODALIDAD"].ToString();
        //                        ocampoEnt.COD_BITACORA = dr["COD_BITACORA"].ToString();
        //                        ocampoEnt.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
        //                        ocampoEnt.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
        //                        ocampoEnt.SUPERVISADO_TEXT = dr["SUPERVISADO_TEXT"].ToString();
        //                        ocampoEnt.COD_ITIPO = dr["COD_ITIPO"].ToString();
        //                        ocampoEnt.TIPO_INFORME = dr["TIPO_INFORME"].ToString();
        //                        ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        ocampoEnt.OBSERVACIONES = dr["OBSERVACIONES"].ToString();
        //                        ocampoEnt.COD_REQUE = Int32.Parse(dr["COD_REQUE"].ToString());
        //                        ocampoEnt.ALERTA_ILEGAL_TEXT = dr["ALERTA_ILEGAL_TEXT"].ToString();
        //                        ocampoEnt.DES_ALERTA_ILEGAL = dr["DES_ALERTA_ILEGAL"].ToString();
        //                        ocampoEnt.ACTA_ARCHIVO = dr["ACTA_ARCHIVO"].ToString();
        //                        ocampoEnt.ACTA_ARCHIVO_TEXT = dr["ACTA_ARCHIVO_TEXT"].ToString();
        //                        ocampoEnt.OTROS_HECHO = dr["OTROS_HECHO"].ToString();
        //                        ocampoEnt.ARCHIVOS = dr["ARCHIVOS"].ToString();
        //                        ocampoEnt.FECHA_INICIO_SUPERVISION = dr["FECHA_INICIO_SUPERVISION"].ToString();
        //                        ocampoEnt.FECHA_FIN_SUPERVISION = dr["FECHA_FIN_SUPERVISION"].ToString();
        //                        ocampoEnt.ARCHIVOS_NTF = "";
        //                        ocampoEnt.VOLUMEN_INJUSTIFICADO = Convert.ToDecimal(dr["VOLUMEN_INJUSTIFICADO"].ToString());
        //                        string[] olarch = ocampoEnt.ARCHIVOS.Split('|');
        //                        ocampoEnt.ARCHIVOS = "";
        //                        foreach (var item in olarch)
        //                        {
        //                            ocampoEnt.ARCHIVOS += ocampoEnt.ARCHIVOS == "" ? item : "\n" + item;
        //                        }

        //                        ocampoEnt.RegEstado = 0;

        //                        //Cargar la información geográfica (archivos)
        //                        ocampoEnt.ListInfoGeo = new List<CEntidad>();
        //                        //Cargar  (archivos) Acta
        //                        ocampoEnt.ListDetActa = new List<CEntidad>();
        //                        ocampoEnt.ListBEXT = new List<CEntidad>();
        //                        lsCEntidad.ListBitacoras.Add(ocampoEnt);
        //                    }
        //                }
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidad();
        //                        ocampoEnt.COD_BITACORA = dr["COD_BITACORA"].ToString();
        //                        ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        ocampoEnt.COD_INFOGEO = Int32.Parse(dr["COD_INFOGEO"].ToString());
        //                        ocampoEnt.NOMBRE_ARCH = dr["NOMBRE_ARCH"].ToString();
        //                        ocampoEnt.EXTENSION_ARCH = dr["EXTENSION_ARCH"].ToString();
        //                        ocampoEnt.RUTA_ARCH = dr["RUTA_ARCH"].ToString();
        //                        ocampoEnt.RegEstado = 0;

        //                        for (int i = 0; i < lsCEntidad.ListBitacoras.Count; i++)
        //                        {
        //                            if (lsCEntidad.ListBitacoras[i].COD_THABILITANTE == ocampoEnt.COD_THABILITANTE
        //                                && lsCEntidad.ListBitacoras[i].COD_SECUENCIAL == ocampoEnt.COD_SECUENCIAL)
        //                            {
        //                                lsCEntidad.ListBitacoras[i].ListInfoGeo.Add(ocampoEnt);
        //                            }
        //                        }
        //                    }
        //                }
        //                //Codigo agregado para multiples archivos de actas
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidad();
        //                        ocampoEnt.COD_BITACORA = dr["COD_BITACORA"].ToString();
        //                        ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        ocampoEnt.COD_SECUENCIAL_ACTA = Int32.Parse(dr["COD_SECUENCIAL_ACTA"].ToString());
        //                        ocampoEnt.NOMBRE_ARCH = dr["NOMBRE_ARCH"].ToString();
        //                        ocampoEnt.EXTENSION_ARCH = dr["EXTENSION_ARCH"].ToString();
        //                        ocampoEnt.NOMBRE_ARCH_ANTIGUO = dr["NOMBRE_ARCH_ANTIGUO"].ToString();
        //                        ocampoEnt.RegEstado = 0;

        //                        for (int i = 0; i < lsCEntidad.ListBitacoras.Count; i++)
        //                        {
        //                            if (oCEntidad.COD_BITACORA == ocampoEnt.COD_BITACORA
        //                                && lsCEntidad.ListBitacoras[i].COD_THABILITANTE == ocampoEnt.COD_THABILITANTE
        //                                && lsCEntidad.ListBitacoras[i].COD_SECUENCIAL == ocampoEnt.COD_SECUENCIAL)
        //                            {
        //                                lsCEntidad.ListBitacoras[i].ListDetActa.Add(ocampoEnt);
        //                            }
        //                        }
        //                    }
        //                }
        //                //AGREGANDO ESPECIES DEL BALANCE A LA BITACORA
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidad();
        //                        ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
        //                        ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
        //                        ocampoEnt.ESPECIES = dr["ESPECIE"].ToString();
        //                        ocampoEnt.FECHA_BALANCE = dr["FECHA_EMISION_BX"].ToString();
        //                        ocampoEnt.TOTAL_ARBOLES = Int32.Parse(dr["TOTAL_ARBOLES"].ToString());
        //                        ocampoEnt.VOLUMEN_AUTORIZADO = Decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
        //                        ocampoEnt.VOLUMEN_MOVILIZADO = Decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
        //                        ocampoEnt.SALDO = Decimal.Parse(dr["SALDO"].ToString());
        //                        ocampoEnt.NOMBRE_POA = dr["NUM_POA_DETALLE"].ToString();
        //                        ocampoEnt.COD_BITACORA = dr["COD_BITACORA"].ToString();
        //                        ocampoEnt.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
        //                        ocampoEnt.RegEstado = 0;
        //                        for (int i = 0; i < lsCEntidad.ListBitacoras.Count; i++)
        //                        {
        //                            if (oCEntidad.COD_BITACORA == ocampoEnt.COD_BITACORA
        //                                && lsCEntidad.ListBitacoras[i].COD_THABILITANTE == ocampoEnt.COD_THABILITANTE
        //                                && lsCEntidad.ListBitacoras[i].COD_CNOTIFICACION == ocampoEnt.COD_CNOTIFICACION)
        //                            {
        //                                lsCEntidad.ListBitacoras[i].ListBEXT.Add(ocampoEnt);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public CEntidad RegMostrarAlerta(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad ocampoEnt;
        //    CEntidad lsCEntidad = new CEntidad();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spBITACORA_SUPERVISION_MensajeAlerta", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
        //                lsCEntidad.ListVertices = new List<CEntidad>();
        //                lsCEntidad.ListBitacoras = new List<CEntidad>();
        //                lsCEntidad.ListBEXT = new List<CEntidad>();
        //                //CEntPresupSuper ocampodet;     
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    lsCEntidad.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                    lsCEntidad.TITULAR = dr["TITULAR"].ToString();
        //                    lsCEntidad.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
        //                    lsCEntidad.SUPERVISOR = dr["SUPERVISOR"].ToString();
        //                    lsCEntidad.UBICACION = dr["UBICACION"].ToString();
        //                    lsCEntidad.MODALIDAD = dr["MODALIDAD"].ToString();
        //                    lsCEntidad.POA = dr["POA"].ToString();
        //                    lsCEntidad.FECHA_SALIDA = dr["FECHA_SALIDA"].ToString();
        //                    lsCEntidad.FECHA_LLEGADA = dr["FECHA_LLEGADA"].ToString();
        //                    lsCEntidad.DESTINO_ENVIO_TEXT = dr["DESTINO_ENVIO_TEXT"].ToString();
        //                    lsCEntidad.ARCHIVO_OFICIO = dr["ARCHIVO_OFICIO"].ToString();
        //                    lsCEntidad.ARCHIVO_OFICIO_TEXT = dr["ARCHIVO_OFICIO_TEXT"].ToString();
        //                    lsCEntidad.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();

        //                }
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidad();
        //                        ocampoEnt.VERTICE = dr["VERTICE"].ToString();
        //                        ocampoEnt.ZONA = dr["ZONA"].ToString();
        //                        ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
        //                        ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
        //                        ocampoEnt.OBSERVACIONES = dr["OBSERVACIONES"].ToString();

        //                        lsCEntidad.ListVertices.Add(ocampoEnt);
        //                    }
        //                }
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    lsCEntidad.ACTA_ARCHIVO = dr["ACTA_ARCHIVO"].ToString();
        //                    lsCEntidad.ACTA_ARCHIVO_TEXT = dr["ACTA_ARCHIVO_TEXT"].ToString();
        //                    lsCEntidad.ENVIAR_ALERTA = Boolean.Parse(dr["ENVIAR_ALERTA"].ToString());
        //                    lsCEntidad.FECHA_ENVIO_ALERTA = dr["FECHA_ENVIO_ALERTA"].ToString();
        //                    lsCEntidad.ASUNTO_ENVIO_ALERTA = dr["ASUNTO_ENVIO_ALERTA"].ToString();
        //                    lsCEntidad.DESTINO_ENVIO_ALERTA = dr["DESTINO_ENVIO_ALERTA"].ToString();
        //                    lsCEntidad.CONCOPIA_ENVIO_ALERTA = dr["CONCOPIA_ENVIO_ALERTA"].ToString();
        //                    lsCEntidad.MENSAJE_ENVIO_ALERTA = dr["MENSAJE_ENVIO_ALERTA"].ToString();
        //                    lsCEntidad.FECHA_ENVIO_ALERTA = dr["FECHA_ENVIO_ALERTA"].ToString();
        //                    lsCEntidad.USUARIO_ENVIA = dr["USUARIO_ENVIA"].ToString();

        //                }
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {//para mostrar archivos de actas
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidad();
        //                        ocampoEnt.COD_BITACORA = dr["COD_BITACORA"].ToString();
        //                        ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        ocampoEnt.COD_SECUENCIAL_ACTA = Int32.Parse(dr["COD_SECUENCIAL_ACTA"].ToString());
        //                        ocampoEnt.NOMBRE_ARCH = dr["NOMBRE_ARCH"].ToString();
        //                        ocampoEnt.EXTENSION_ARCH = dr["EXTENSION_ARCH"].ToString();
        //                        ocampoEnt.NOMBRE_ARCH_ANTIGUO = dr["NOMBRE_ARCH_ANTIGUO"].ToString();
        //                        ocampoEnt.RegEstado = 0;
        //                        lsCEntidad.ListBitacoras.Add(ocampoEnt);
        //                    }
        //                }
        //                //AGREGANDO ESPECIES DEL BALANCE A LA BITACORA
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidad();
        //                        ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
        //                        ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
        //                        ocampoEnt.ESPECIES = dr["ESPECIE"].ToString();
        //                        ocampoEnt.FECHA_BALANCE = dr["FECHA_EMISION_BX"].ToString();
        //                        ocampoEnt.TOTAL_ARBOLES = Int32.Parse(dr["TOTAL_ARBOLES"].ToString());
        //                        ocampoEnt.VOLUMEN_AUTORIZADO = Decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
        //                        ocampoEnt.VOLUMEN_MOVILIZADO = Decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
        //                        ocampoEnt.SALDO = Decimal.Parse(dr["SALDO"].ToString());
        //                        ocampoEnt.NOMBRE_POA = dr["NUM_POA_DETALLE"].ToString();
        //                        ocampoEnt.COD_BITACORA = dr["COD_BITACORA"].ToString();
        //                        ocampoEnt.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
        //                        ocampoEnt.RegEstado = 0;
        //                        lsCEntidad.ListBEXT.Add(ocampoEnt);

        //                    }
        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public String RegEnviarAlerta(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spBITACORA_SUPERVISION_EnviarAlerta", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //        }
        //        //
        //        tr.Commit();
        //        return OUTPUTPARAM01;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// metodo para obtener las especies del balance de extracion de POA
        /// 16/05/2019
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> RegEspecieBExt(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_BALANCE_EXTRA_ALERT", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad ocampoEnt;
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int pt1 = dr.GetOrdinal("NUM_POA");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt4 = dr.GetOrdinal("ESPECIE");
        //                    int pt5 = dr.GetOrdinal("FECHA_EMISION_BX");
        //                    int pt6 = dr.GetOrdinal("TOTAL_ARBOLES");
        //                    int pt7 = dr.GetOrdinal("VOLUMEN_AUTORIZADO");
        //                    int pt8 = dr.GetOrdinal("VOLUMEN_MOVILIZADO");
        //                    int pt9 = dr.GetOrdinal("SALDO");
        //                    int pt10 = dr.GetOrdinal("NUM_POA_DETALLE");

        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidad();

        //                        ocampoEnt.COD_THABILITANTE = dr.GetString(pt0);
        //                        ocampoEnt.NUM_POA = dr.GetInt32(pt1);
        //                        ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        ocampoEnt.COD_ESPECIES = dr.GetString(pt3);
        //                        ocampoEnt.ESPECIES = dr.GetString(pt4);
        //                        ocampoEnt.FECHA_BALANCE = dr.GetString(pt5);
        //                        ocampoEnt.TOTAL_ARBOLES = dr.GetInt32(pt6);
        //                        ocampoEnt.VOLUMEN_AUTORIZADO = dr.GetDecimal(pt7);
        //                        ocampoEnt.VOLUMEN_MOVILIZADO = dr.GetDecimal(pt8);
        //                        ocampoEnt.SALDO = dr.GetDecimal(pt9);
        //                        ocampoEnt.NOMBRE_POA = dr.GetString(pt10);
        //                        ocampoEnt.RegEstado = 1;
        //                        lsCEntidad.Add(ocampoEnt);
        //                    }
        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #region "Sigo-V3"
        public virtual List<Dictionary<string, string>> CreateList(SqlDataReader reader, string[] campos)
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
        //public List<Dictionary<string, string>> GetAllRutaDestino(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<Dictionary<string, string>> lsCEntidad = new List<Dictionary<string, string>>();
        //    //string tbAdd = "";
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.USP_GETALL_RUTA_DESTINO_V3", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    string[] colums;
        //                    if (oCEntidad.BusCriterio == "TRAMO")
        //                    {
        //                        colums = new string[] { "COD_RUTA", "COD_UBIDEPARTAMENTO", "TRAMO", "DEPARTAMENTO", "ORIGEN_DESTINO" };
        //                        //CreateList(dr, colums);
        //                    }
        //                    else
        //                    {
        //                        colums = new string[] { "COD_RUTA", "COD_DESTINATARIO", "COD_DESTINATARIO_RUTA", "TRAMO", "ORIGEN_DESTINO", "DESCRIPCION", "CORREO"
        //                                                ,"DEPARTAMENTO","CARGO","OFICINA"};
        //                        //while (dr.Read())
        //                        //{                                  

        //                        //    tbAdd += "<table  class='Grilla'  style='width:100%;border-collapse:collapse;' id='tbTramoSelecionado'>";
        //                        //    tbAdd += "<thead>";
        //                        //    tbAdd += "<tr>";
        //                        //    tbAdd += "<th>N°</th>";
        //                        //    tbAdd += "<th>Departamento</th>";
        //                        //    tbAdd += "<th>Tramo</th>";
        //                        //    tbAdd += "<th>Origen-Destino</th>";
        //                        //    tbAdd += "<th>Descripcion</th>";
        //                        //    tbAdd += "<th>Correo</th>";
        //                        //    tbAdd += "</tr>";
        //                        //    tbAdd += "</thead>";
        //                        //    tbAdd += "<tbody>";
        //                        //    while (dr.Read())
        //                        //    {
        //                        //        tbAdd += "<tr>";
        //                        //        tbAdd += "<td></td>";
        //                        //        tbAdd+="<td>"+ dr["DEPARTAMENTO"].ToString()+"</td>";
        //                        //        tbAdd += "<td>" + dr["TRAMO"].ToString() + "</td>";
        //                        //        tbAdd += "<td>" + dr["ORIGEN_DESTINO"].ToString() + "</td>";
        //                        //        tbAdd += "<td>" + dr["DESCRIPCION"].ToString() + "</td>";
        //                        //        tbAdd += "<td>" + dr["CORREO"].ToString() + "</td>";                                        
        //                        //        tbAdd += "</tr>";
        //                        //    }
        //                        //    tbAdd += "<tbody>";
        //                        //    tbAdd += "</table>";
        //                        //}
        //                        //var item = new Dictionary<string, string>();
        //                        //item.Add("tbText", tbAdd);
        //                        //lsCEntidad.Add(item);
        //                    }
        //                    lsCEntidad = CreateList(dr, colums);

        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion
        //public String RegGrabarBitacoraBXConfirmacion(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCamposDet;
        //    String OUTPUTPARAM01 = "";
        //    SqlTransaction tr = null;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        if (oCEntidad.ListEliTABLA != null)
        //        {

        //            foreach (var loDatos in oCEntidad.ListEliTABLA)
        //            {
        //                if (loDatos.EliTABLA == "BITACORA_BALANCE" && loDatos.RegEstado == 0)
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_BITACORA = oCEntidad.COD_BITACORA;
        //                    oCamposDet.EliTABLA = loDatos.EliTABLA;
        //                    oCamposDet.COD_SUPERVISOR = loDatos.COD_SUPERVISOR;
        //                    oCamposDet.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_INFOGEO = loDatos.COD_INFOGEO;
        //                    oCamposDet.NUM_POA = loDatos.NUM_POA;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
        //                    OUTPUTPARAM01 = oCEntidad.COD_BITACORA;
        //                }

        //            }
        //        }
        //        /**
        //         * GRABANDO ESPECIES DEL BALANACE
        //         */
        //        if (oCEntidad.ListBEXT != null)
        //        {
        //            foreach (var balance in oCEntidad.ListBEXT)
        //            {
        //                if (balance.RegEstado == 1 || balance.RegEstado == 2)
        //                {
        //                    CEntidad ocampoEntBx = new CEntidad();
        //                    ocampoEntBx.COD_BITACORA = oCEntidad.COD_BITACORA;
        //                    ocampoEntBx.COD_THABILITANTE = balance.COD_THABILITANTE;
        //                    ocampoEntBx.NUM_POA = balance.NUM_POA;
        //                    ocampoEntBx.COD_SECUENCIAL = balance.COD_SECUENCIAL;
        //                    ocampoEntBx.COD_ESPECIES = balance.COD_ESPECIES;
        //                    ocampoEntBx.RegEstado = balance.RegEstado;
        //                    ocampoEntBx.COD_CNOTIFICACION = oCEntidad.COD_CNOTIFICACION;
        //                    //ocampoEntBx.OUTPUTPARAMDET01 = "";
        //                    using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spBITACORA_BX_GRABAR", ocampoEntBx))
        //                    {
        //                        cmd.ExecuteNonQuery();
        //                    }
        //                    OUTPUTPARAM01 = oCEntidad.COD_BITACORA;
        //                }
        //            }
        //        }

        //        tr.Commit();
        //        return OUTPUTPARAM01;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}
    }
}
