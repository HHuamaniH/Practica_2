using CapaEntidad.DOC;
using CapaEntidad.Documento;
using CapaEntidad.ViewModel.Documento;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Documento
{
   public class Dat_Itenerario
    {
        private DBOracle dBOracle = new DBOracle();
        public List<VM_Itenerario_List> GetAll(string criterio,string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<VM_Itenerario_List> result = new List<VM_Itenerario_List>();
            VM_Itenerario_List vm;
            rowCount = 0;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_ITENERARIO_LISTAR_PAGING", criterio,valorBusqueda, currentPage, pageSize, sort))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_Itenerario_List();
                                    vm.COD_BITACORA= dr["COD_BITACORA"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.OD = dr["OD"].ToString();
                                    vm.SUPERVISOR = dr["SUPERVISOR"].ToString();
                                    vm.CARTA_NOTIFICACION = dr["CARTA_NOTIFICACION"].ToString();
                                    vm.SUPERVISADO = dr["SUPERVISADO"].ToString();
                                    vm.TIPO_INFORME = dr["TIPO_INFORME"].ToString();
                                    vm.FECHA = Convert.ToDateTime(dr["FECHA_CREACION"]);
                                    result.Add(vm);
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
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_Itenerario_List> Reporte(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<VM_Itenerario_List> result = new List<VM_Itenerario_List>();
            VM_Itenerario_List vm;
            rowCount = 0;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_ITENERARIO_LISTAR_PAGING", criterio, valorBusqueda, currentPage, pageSize, sort))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_Itenerario_List();
                                    vm.COD_BITACORA = dr["COD_BITACORA"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.OD = dr["OD"].ToString();
                                    vm.SUPERVISOR = dr["SUPERVISOR"].ToString();
                                    vm.CARTA_NOTIFICACION = dr["CARTA_NOTIFICACION"].ToString();
                                    vm.SUPERVISADO = dr["SUPERVISADO"].ToString();
                                    vm.TIPO_INFORME = dr["TIPO_INFORME"].ToString();
                                    vm.FECHA = Convert.ToDateTime(dr["FECHA"]);
                                    vm.ANIO_REGISTRO = Convert.ToInt32(dr["ANIO_REGISTRO"]);
                                    vm.MES_REGISTRO = dr["MES_REGISTRO"].ToString();
                                    vm.USUARIO = dr["USUARIO"].ToString();
                                    vm.FECHA_HORA_SALIDA = dr["FECHA_HORA_SALIDA"]== DBNull.Value ? (DateTime?)null:Convert.ToDateTime(dr["FECHA_HORA_SALIDA"]);
                                    vm.FECHA_RECEPCION_CHEQUE = dr["FECHA_RECEPCION_CHEQUE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECEPCION_CHEQUE"]);
                                    vm.FECHA_COBRO_CHEQUE = dr["FECHA_COBRO_CHEQUE"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_COBRO_CHEQUE"]);
                                    result.Add(vm);
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
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RegistrarCartaNotificacionBitacora(Ent_BITACORA_SUPER ent)
        {
            string rutaBase = System.AppDomain.CurrentDomain.BaseDirectory;
            OracleTransaction tr = null;
            Ent_BITACORA_SUPER entActa = null;
            Ent_BITACORA_SUPER oCamposDet = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    if (ent != null)
                    {
                        ent.FECHA_INICIO_SUPERVISION = (ent.FECHA_INICIO_SUPERVISION == null || ent.FECHA_INICIO_SUPERVISION.ToString()=="") ? (DateTime?)null : Convert.ToDateTime(ent.FECHA_INICIO_SUPERVISION);
                        ent.FECHA_FIN_SUPERVISION = (ent.FECHA_FIN_SUPERVISION == null || ent.FECHA_FIN_SUPERVISION.ToString() == "") ? (DateTime?)null : Convert.ToDateTime(ent.FECHA_FIN_SUPERVISION);

                        object[] param = { ent.COD_BITACORA,ent.COD_CNOTIFICACION,ent.COD_UCUENTA,ent.COD_THABILITANTE,
                        ent.COD_SECUENCIAL,ent.SUPERVISADO,ent.COD_ITIPO,ent.OBSERVACIONES,ent.ALERTA_ILEGAL,ent.DES_ALERTA_ILEGAL,
                        ent.OTROS_HECHO,ent.COD_REQUE,ent.ACTA_ARCHIVO,ent.ACTA_ARCHIVO_TEXT,ent.NOTIFICAR_ARCHIVO,ent.ARCHIVOS_NTF,
                        ent.VOLUMEN_INJUSTIFICADO, ent.FECHA_INICIO_SUPERVISION,ent.FECHA_FIN_SUPERVISION,ent.RegEstado};

                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_DET_CARTAS_Grabar", param);

                        if (ent.ListEliTABLA != null)
                        {
                            foreach (var loDatos in ent.ListEliTABLA)
                            {
                                if(loDatos.EliTABLA== "BITACORA_SUPERVISIONES_DET_ACTA")
                                {
                                    oCamposDet = new Ent_BITACORA_SUPER();
                                    oCamposDet.COD_BITACORA = ent.COD_BITACORA;
                                    oCamposDet.EliTABLA = loDatos.EliTABLA;
                                    oCamposDet.COD_CNOTIFICACION = ent.COD_CNOTIFICACION;
                                    oCamposDet.COD_THABILITANTE = ent.COD_THABILITANTE;
                                    oCamposDet.COD_SECUENCIAL = ent.COD_SECUENCIAL;
                                    oCamposDet.COD_SECUENCIAL_ACTA = loDatos.COD_SECUENCIAL_ACTA;
                                    oCamposDet.COD_INFOGEO = loDatos.COD_INFOGEO;
                                    oCamposDet.NUM_POA = loDatos.NUM_POA;
                                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
                                    string nombreArchivo = ent.COD_BITACORA + loDatos.COD_SECUENCIAL_ACTA.ToString() + "." + loDatos.EXTENSION_ARCH;
                                    if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo)))
                                    {    //moviendo archivos a la carpeta historial
                                        System.IO.File.Copy(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo), System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Historico/" + nombreArchivo));
                                       
                                        //eliminando 
                                        System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
                                    }
                                }
                                else if (loDatos.EliTABLA == "BITACORA_SUPERVISIONES_DET_INFOGEO")
                                {
                                    oCamposDet = new Ent_BITACORA_SUPER();
                                    oCamposDet.COD_BITACORA = ent.COD_BITACORA;
                                    oCamposDet.EliTABLA = loDatos.EliTABLA;
                                    oCamposDet.COD_SUPERVISOR = loDatos.COD_SUPERVISOR;
                                    oCamposDet.COD_CNOTIFICACION = ent.COD_CNOTIFICACION;
                                    oCamposDet.COD_THABILITANTE = ent.COD_THABILITANTE;
                                    oCamposDet.COD_SECUENCIAL = ent.COD_SECUENCIAL;
                                    oCamposDet.COD_INFOGEO = loDatos.COD_INFOGEO;
                                    oCamposDet.NUM_POA = loDatos.NUM_POA;
                                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
                                }
                                else if (loDatos.EliTABLA == "BITACORA_SUPERVISIONES_DET_ENCRYP")
                                {
                                    oCamposDet = new Ent_BITACORA_SUPER();
                                    oCamposDet.COD_BITACORA = ent.COD_BITACORA;
                                    oCamposDet.EliTABLA = loDatos.EliTABLA;
                                    oCamposDet.COD_SUPERVISOR = loDatos.COD_SUPERVISOR;
                                    oCamposDet.COD_CNOTIFICACION = ent.COD_CNOTIFICACION;
                                    oCamposDet.COD_THABILITANTE = ent.COD_THABILITANTE;
                                    oCamposDet.COD_SECUENCIAL = ent.COD_SECUENCIAL;
                                    oCamposDet.COD_SECUENCIAL_ENCRYP = loDatos.COD_SECUENCIAL_ENCRYP;
                                    oCamposDet.COD_INFOGEO = loDatos.COD_INFOGEO;
                                    oCamposDet.NUM_POA = loDatos.NUM_POA;
                                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
                                    if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Encriptado/Desencriptado/" + loDatos.NOMBRE_ARCH + ".csv")))
                                    {   
                                        //eliminando 
                                        System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Encriptado/Desencriptado/" + loDatos.NOMBRE_ARCH + ".csv"));
                                    }
                                    if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Encriptado/" + loDatos.COD_BITACORA + "-" + loDatos.NOMBRE_ARCH + "." + loDatos.EXTENSION_ARCH)))
                                    {
                                        //eliminando 
                                        System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Encriptado/" + loDatos.COD_BITACORA + "-" + loDatos.NOMBRE_ARCH + "." + loDatos.EXTENSION_ARCH));
                                    }
                                }

                            }
                        }

                        if (ent.ListDetActa != null)
                        {
                            string nombreArchivo = "";
                            foreach (var item in ent.ListDetActa)
                            {//NOM_ARCH_TEMP
                                entActa = new Ent_BITACORA_SUPER();
                                entActa.COD_BITACORA = ent.COD_BITACORA;
                                entActa.COD_THABILITANTE = ent.COD_THABILITANTE;
                                entActa.COD_SECUENCIAL = ent.COD_SECUENCIAL;
                                entActa.COD_SECUENCIAL_ACTA = item.COD_SECUENCIAL_ACTA;
                                entActa.NOMBRE_ARCH = item.NOMBRE_ARCH;
                                entActa.EXTENSION_ARCH = item.EXTENSION_ARCH;
                                entActa.COD_UCUENTA = ent.COD_UCUENTA;
                                entActa.RegEstado = 1;
                                entActa.OUTPUTPARAMDET01 = "";
                                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISIONES_DET_ACTA_GrabarV3", entActa))
                                {
                                    cmd.ExecuteNonQuery();
                                    entActa.COD_SECUENCIAL_ACTA = Convert.ToInt32(cmd.Parameters["OUTPUTPARAMDET01"].Value);
                                }
                                nombreArchivo = ent.COD_BITACORA + entActa.COD_SECUENCIAL_ACTA.ToString() + "." + entActa.EXTENSION_ARCH;
                                if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + item.NOM_ARCH_TEMP)))
                                {   //Grabando archivos
                                    System.IO.File.Copy(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + item.NOM_ARCH_TEMP), System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
                                    // lstPath.Add(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
                                    //eliminando temporal
                                    System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + item.NOM_ARCH_TEMP));

                                }
                            }
                        }
                        if (ent.ListEncryp != null)
                        {
                            string nombreArchivo = "";
                            foreach (var item in ent.ListEncryp)
                            {
                                entActa = new Ent_BITACORA_SUPER();
                                entActa.COD_BITACORA = ent.COD_BITACORA;
                                entActa.COD_THABILITANTE = ent.COD_THABILITANTE;
                                entActa.COD_SECUENCIAL = ent.COD_SECUENCIAL;
                                //entActa.COD_SECUENCIAL_ENCRYP = item.COD_SECUENCIAL_ENCRYP;
                                entActa.NOMBRE_ARCH = item.NOMBRE_ARCH;
                                entActa.EXTENSION_ARCH = item.EXTENSION_ARCH;
                                entActa.COD_UCUENTA = ent.COD_UCUENTA;
                                entActa.RegEstado = 1;
                                
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SP_BITACORA_SUPERVISIONES_DET_ARCH_CSVENCRYP", entActa);
                                nombreArchivo = ent.COD_BITACORA + "-" + entActa.NOMBRE_ARCH + "." + entActa.EXTENSION_ARCH;
                                if (System.IO.File.Exists(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + item.NOM_ARCH_TEMP)))
                                {   //Grabando archivos
                                    System.IO.File.Copy(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + item.NOM_ARCH_TEMP), System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Encriptado/" + nombreArchivo));
                                    // lstPath.Add(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/" + nombreArchivo));
                                    //eliminando temporal
                                    System.IO.File.Delete(System.IO.Path.Combine(rutaBase, "Archivos/Modulo/Supervision/Itinerario/Temp/" + item.NOM_ARCH_TEMP));

                                }
                            }
                        }
                        if (ent.ListInfoGeo != null)
                        {
                            foreach(var item in ent.ListInfoGeo)
                            {
                                entActa = new Ent_BITACORA_SUPER();
                                entActa.COD_BITACORA = ent.COD_BITACORA;
                                entActa.COD_THABILITANTE = ent.COD_THABILITANTE;
                                entActa.COD_SECUENCIAL = ent.COD_SECUENCIAL;
                                entActa.COD_INFOGEO = 0;
                                entActa.NOMBRE_ARCH = item.NOMBRE_ARCH;
                                entActa.EXTENSION_ARCH = item.EXTENSION_ARCH;
                                entActa.RUTA_ARCH = item.RUTA_ARCH;
                                entActa.COD_UCUENTA = ent.COD_UCUENTA;
                                entActa.RegEstado = 1;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISIONES_DET_INFOGEO_Grabar", entActa);
                            }
                        }

                    }

                    tr.Commit();
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
            return true;
        }
        public bool EliminarBitacoraDetalle(Ent_BITACORA_SUPER entidad)
        {
            Ent_BITACORA_SUPER oCamposDet;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                try
                {
                    oCamposDet = new Ent_BITACORA_SUPER();
                    oCamposDet.COD_BITACORA = entidad.COD_BITACORA;
                    oCamposDet.EliTABLA = entidad.EliTABLA;
                    oCamposDet.COD_SUPERVISOR = entidad.COD_SUPERVISOR;
                    oCamposDet.COD_CNOTIFICACION = entidad.COD_CNOTIFICACION;
                    oCamposDet.COD_THABILITANTE = entidad.COD_THABILITANTE;
                    oCamposDet.COD_SECUENCIAL = entidad.COD_SECUENCIAL;
                    oCamposDet.COD_INFOGEO = entidad.COD_INFOGEO;
                    oCamposDet.NUM_POA = entidad.NUM_POA;
                    oCamposDet.COD_ESPECIES = entidad.COD_ESPECIES;
                    dBOracle.ManExecute(cn,null, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }

            }
            return true;
        }
        public string Guardar(Ent_Itenerario entidad)
        {
            //string id = "";
            String OUTPUTPARAM01 = "";
            Ent_BITACORA_SUPER oCamposDet;
            Ent_BITACORA_SUPER oCamposCorreo;
            OracleTransaction tr = null;

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_Grabar", entidad))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = Convert.ToString(cmd.Parameters["OUTPUTPARAM01"].Value);
                        if (OUTPUTPARAM01 == "99")
                        {
                            tr.Rollback();
                            tr = null;
                            throw new Exception("Ud. no tiene permiso para realizar esta acción");
                        }
                        if (entidad.RegEstado == 1) entidad.COD_BITACORA = OUTPUTPARAM01;
                    }
                    if (entidad.ListEliTABLA != null)
                    {
                        foreach (var loDatos in entidad.ListEliTABLA)
                        {
                            if (loDatos.EliTABLA == "BITACORA_SUPERVISIONES_PROF")
                            {
                                oCamposDet = new Ent_BITACORA_SUPER();
                                oCamposDet.COD_BITACORA = entidad.COD_BITACORA;
                                oCamposDet.EliTABLA = loDatos.EliTABLA;
                                oCamposDet.COD_SUPERVISOR = loDatos.COD_SUPERVISOR;
                                oCamposDet.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                                oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                                oCamposDet.COD_INFOGEO = loDatos.COD_INFOGEO;
                                oCamposDet.NUM_POA = loDatos.NUM_POA;
                                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_EliminarDetalle", oCamposDet);
                            }
                        }
                    }
                        //Grabando Detalle Supervisores
                    if (entidad.ListInformeDetSupervisor != null)
                    {
                        foreach (var loDatos in entidad.ListInformeDetSupervisor)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {                             
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISIONES_DET_SUPERVISOR_Grabar", entidad.COD_BITACORA,
                                  entidad.COD_UCUENTA,loDatos.COD_PERSONA, loDatos.RegEstado);
                            }
                        }
                    }

                    //Enviar aviso por correo electrónico del registro/modificación del itinerario
                    oCamposCorreo = new Ent_BITACORA_SUPER();
                    oCamposCorreo.COD_BITACORA = entidad.COD_BITACORA;
                    oCamposCorreo.COD_UCUENTA = entidad.COD_UCUENTA;
                    oCamposCorreo.COD_OD = entidad.COD_OD;
                    oCamposCorreo.RegEstado = entidad.RegEstado;
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_Correo", oCamposCorreo))
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
                    return entidad.COD_BITACORA;
                    //return OUTPUTPARAM01;
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
        }
        public List<Ent_BITACORA_SUPER> GetAllCartaNotificacion(string BusFormulario,string BusCriterio,string BusValor,string BusCriterio1="")
        {
            List<Ent_BITACORA_SUPER> lsCEntidad = new List<Ent_BITACORA_SUPER>();
            Ent_BITACORA_SUPER oCampos;           
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    object[] param = { BusFormulario, BusCriterio, BusValor ,1,20};
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", param))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new Ent_BITACORA_SUPER();
                                    oCampos.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
                                    oCampos.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.TITULAR = dr["TITULAR"].ToString();
                                    oCampos.POA = dr["POA"].ToString();
                                    lsCEntidad.Add(oCampos);
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
        public List<Ent_BITACORA_SUPER> GetAllItenerarioSupervision(string COD_BITACORA)
        {
            List<Ent_BITACORA_SUPER> ListBitacoras = new List<Ent_BITACORA_SUPER>();
            Ent_BITACORA_SUPER ocampoEnt;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_ITENERARIO_SUPERVISIONES_GET_ALL", COD_BITACORA))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new Ent_BITACORA_SUPER();
                                    ocampoEnt.COD_BITACORA = dr["COD_BITACORA"].ToString();
                                    ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    ocampoEnt.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    ocampoEnt.TITULAR = dr["TITULAR"].ToString();
                                    ocampoEnt.POA = dr["POA"].ToString();
                                    ocampoEnt.POAS = dr["POAS"].ToString();
                                    ocampoEnt.MODALIDAD = dr["MODALIDAD"].ToString();                                   
                                    ocampoEnt.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
                                    ocampoEnt.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
                                    ocampoEnt.SUPERVISADO_TEXT = dr["SUPERVISADO_TEXT"].ToString();
                                    ocampoEnt.COD_ITIPO = dr["COD_ITIPO"].ToString();
                                    ocampoEnt.TIPO_INFORME = dr["TIPO_INFORME"].ToString();
                                    ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    ocampoEnt.OBSERVACIONES = dr["OBSERVACIONES"].ToString();
                                    ocampoEnt.COD_REQUE = Int32.Parse(dr["COD_REQUE"].ToString());
                                    ocampoEnt.ALERTA_ILEGAL_TEXT = dr["ALERTA_ILEGAL_TEXT"].ToString();
                                    ocampoEnt.DES_ALERTA_ILEGAL = dr["DES_ALERTA_ILEGAL"].ToString();
                                    ocampoEnt.ACTA_ARCHIVO = dr["ACTA_ARCHIVO"].ToString();
                                    ocampoEnt.ACTA_ARCHIVO_TEXT = dr["ACTA_ARCHIVO_TEXT"].ToString();
                                    ocampoEnt.OTROS_HECHO = dr["OTROS_HECHO"].ToString();
                                    ocampoEnt.ARCHIVOS = dr["ARCHIVOS"].ToString();
                                    ocampoEnt.FECHA_INICIO_SUPERVISION = dr["FECHA_INICIO_SUPERVISION"].ToString();
                                    ocampoEnt.FECHA_FIN_SUPERVISION = dr["FECHA_FIN_SUPERVISION"].ToString();
                                    ocampoEnt.ARCHIVOS_NTF = "";
                                    ocampoEnt.VOLUMEN_INJUSTIFICADO = Convert.ToDecimal(dr["VOLUMEN_INJUSTIFICADO"].ToString());
                                    //string[] olarch = ocampoEnt.ARCHIVOS.Split('|');
                                    //ocampoEnt.ARCHIVOS = "";
                                    //foreach (var item in olarch)
                                    //{
                                    //    ocampoEnt.ARCHIVOS += ocampoEnt.ARCHIVOS == "" ? item : "\n" + item;
                                    //}

                                    ocampoEnt.RegEstado = 0;
                                    ListBitacoras.Add(ocampoEnt);
                                }
                            }
                        }
                    }
                }
                return ListBitacoras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Ent_BITACORA_SUPER GetAllItenerarioSupervisionGetById(string COD_BITACORA,string COD_CNOTIFICACION,string COD_THABILITANTE,int COD_SECUENCIAL)
        {
            Ent_BITACORA_SUPER detActa = new Ent_BITACORA_SUPER();
            Ent_BITACORA_SUPER ocampoEnt=new Ent_BITACORA_SUPER();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_ITENERARIO_SUPERVISIONES_GET_ID", COD_BITACORA, COD_CNOTIFICACION, COD_THABILITANTE, COD_SECUENCIAL))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                dr.Read();
                                ocampoEnt = new Ent_BITACORA_SUPER();
                                ocampoEnt.COD_BITACORA = dr["COD_BITACORA"].ToString();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                ocampoEnt.TITULAR = dr["TITULAR"].ToString();
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.POAS = dr["POAS"].ToString();
                                ocampoEnt.MODALIDAD = dr["MODALIDAD"].ToString();
                                ocampoEnt.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
                                ocampoEnt.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
                                ocampoEnt.SUPERVISADO_TEXT = dr["SUPERVISADO_TEXT"].ToString();
                                ocampoEnt.COD_ITIPO = dr["COD_ITIPO"].ToString();
                                ocampoEnt.TIPO_INFORME = dr["TIPO_INFORME"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.OBSERVACIONES = dr["OBSERVACIONES"].ToString();
                                ocampoEnt.COD_REQUE = Int32.Parse(dr["COD_REQUE"].ToString());
                                ocampoEnt.ALERTA_ILEGAL_TEXT = dr["ALERTA_ILEGAL_TEXT"].ToString();
                                ocampoEnt.DES_ALERTA_ILEGAL = dr["DES_ALERTA_ILEGAL"].ToString();
                                ocampoEnt.ACTA_ARCHIVO = dr["ACTA_ARCHIVO"].ToString();
                                ocampoEnt.ACTA_ARCHIVO_TEXT = dr["ACTA_ARCHIVO_TEXT"].ToString();
                                ocampoEnt.OTROS_HECHO = dr["OTROS_HECHO"].ToString();
                                ocampoEnt.ARCHIVOS = dr["ARCHIVOS"].ToString();
                                ocampoEnt.FECHA_INICIO_SUPERVISION = dr["FECHA_INICIO_SUPERVISION"].ToString();
                                ocampoEnt.FECHA_FIN_SUPERVISION = dr["FECHA_FIN_SUPERVISION"].ToString();
                                ocampoEnt.ARCHIVOS_NTF = "";
                                ocampoEnt.VOLUMEN_INJUSTIFICADO = Convert.ToDecimal(dr["VOLUMEN_INJUSTIFICADO"].ToString());
                                //string[] olarch = ocampoEnt.ARCHIVOS.Split('|');
                                //ocampoEnt.ARCHIVOS = "";
                                //foreach (var item in olarch)
                                //{
                                //    ocampoEnt.ARCHIVOS += ocampoEnt.ARCHIVOS == "" ? item : "\n" + item;
                                //}

                                ocampoEnt.RegEstado = 0;
                                ocampoEnt.ListDetActa = new List<Ent_BITACORA_SUPER>();
                                ocampoEnt.ListInfoGeo = new List<Ent_BITACORA_SUPER>();
                                ocampoEnt.ListEncryp = new List<Ent_BITACORA_SUPER>();
                                // ListBitacoras.Add(ocampoEnt);
                                // multiples archivos de actas
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        detActa = new Ent_BITACORA_SUPER();
                                        detActa.COD_BITACORA = dr["COD_BITACORA"].ToString();
                                        detActa.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                        detActa.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                        detActa.COD_SECUENCIAL_ACTA = Int32.Parse(dr["COD_SECUENCIAL_ACTA"].ToString());
                                        detActa.NOMBRE_ARCH = dr["NOMBRE_ARCH"].ToString();
                                        detActa.EXTENSION_ARCH = dr["EXTENSION_ARCH"].ToString();
                                        //detActa.NOM_ARCH_TEMP = dr["COD_BITACORA"].ToString() + dr["COD_SECUENCIAL_ACTA"].ToString() + "." + dr["EXTENSION_ARCH"].ToString(); 
                                        // dr["COD_SEG_MUESTRA"].ToString() + "_" + dr["COD_SECUENCIAL"].ToString() + "_" + dr["COD_SECUENCIAL_ARCHIVO"].ToString() + "." + dr["EXTENSION_ARCH"].ToString();
                                        detActa.NOMBRE_ARCH_ANTIGUO = dr["NOMBRE_ARCH_ANTIGUO"].ToString();
                                        detActa.RegEstado = 0;
                                        ocampoEnt.ListDetActa.Add(detActa);

                                    }
                                }

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        detActa = new Ent_BITACORA_SUPER();
                                        detActa.COD_BITACORA = dr["COD_BITACORA"].ToString();
                                        detActa.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                        detActa.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                        detActa.COD_SECUENCIAL_ENCRYP = Int32.Parse(dr["COD_SECUENCIAL_ENCRYP"].ToString());
                                        detActa.NOMBRE_ARCH = dr["NOMBRE_ARCH"].ToString();
                                        detActa.EXTENSION_ARCH = dr["EXTENSION_ARCH"].ToString();
                                        //detActa.NOM_ARCH_TEMP = dr["COD_BITACORA"].ToString() + dr["COD_SECUENCIAL_ACTA"].ToString() + "." + dr["EXTENSION_ARCH"].ToString();
                                        // dr["COD_SEG_MUESTRA"].ToString() + "_" + dr["COD_SECUENCIAL"].ToString() + "_" + dr["COD_SECUENCIAL_ARCHIVO"].ToString() + "." + dr["EXTENSION_ARCH"].ToString();
                                        //detActa.NOMBRE_ARCH_ANTIGUO = dr["NOMBRE_ARCH_ANTIGUO"].ToString();
                                        detActa.RegEstado = 0;
                                        ocampoEnt.ListEncryp.Add(detActa);

                                    }
                                }

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        detActa = new Ent_BITACORA_SUPER();
                                        detActa.COD_BITACORA = dr["COD_BITACORA"].ToString();
                                        detActa.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                        detActa.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                        detActa.COD_INFOGEO = Int32.Parse(dr["COD_INFOGEO"].ToString());
                                        detActa.NOMBRE_ARCH = dr["NOMBRE_ARCH"].ToString();
                                        detActa.EXTENSION_ARCH = dr["EXTENSION_ARCH"].ToString();
                                        detActa.RUTA_ARCH = dr["RUTA_ARCH"].ToString();
                                        detActa.RegEstado = 0;
                                        ocampoEnt.ListInfoGeo.Add(detActa);
                                    }
                                }
                            }
                        }
                    }
                }
                return ocampoEnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_Itenerario GetById(string COD_BITACORA)
        {
            VM_Itenerario vm = new VM_Itenerario();
            vm.tbSupervisor = new List<Ent_GENEPERSONA>();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_BITACORA_SUPERVISION_MOSTRAR_ITEM_ID", COD_BITACORA))
                    {
                        if (dr != null)
                        {
                            Ent_GENEPERSONA ocampoEntPersona;
                            if (dr.HasRows)
                            {
                                dr.Read();
                                vm.id = dr["COD_BITACORA"].ToString();
                                vm.odId = dr["COD_OD"].ToString();
                                vm.fechaSalida = dr["FECHA_HORA_SALIDA"] == DBNull.Value ? null : Convert.ToDateTime(dr["FECHA_HORA_SALIDA"]).ToShortDateString();
                                vm.fechaRecepcionCheque = dr["FECHA_RECEPCION_CHEQUE"] == DBNull.Value ? null : Convert.ToDateTime(dr["FECHA_RECEPCION_CHEQUE"]).ToShortDateString();
                                vm.fechaCobroCheque = dr["FECHA_COBRO_CHEQUE"] == DBNull.Value ? null : Convert.ToDateTime(dr["FECHA_COBRO_CHEQUE"]).ToShortDateString();
                                vm.fechaInicioLabores= dr["FECHA_HORA_LLEGADA"] == DBNull.Value ? null : Convert.ToDateTime(dr["FECHA_HORA_LLEGADA"]).ToShortDateString();
                                vm.fechaRetornoCampo = dr["FECHA_RETORNO_CAMPO"] == DBNull.Value ? null : Convert.ToDateTime(dr["FECHA_RETORNO_CAMPO"]).ToShortDateString();
                                vm.observacion = dr["OBSERVACIONES"] == DBNull.Value ? string.Empty : dr["OBSERVACIONES"].ToString();
                                vm.ddIncidentesId = dr["CAPACITACION_INCIDENTES"] == DBNull.Value ? "SN" : dr["CAPACITACION_INCIDENTES"].ToString();
                                vm.ddPAuxiliosId = dr["CAPACITACION_PAUXILIOS"] == DBNull.Value ? "SN" : dr["CAPACITACION_PAUXILIOS"].ToString();
                                if(vm.ddIncidentesId!="SN")
                                  vm.ddIncidentesId = vm.ddIncidentesId == "1" ? "S" : "N";
                                if(vm.ddPAuxiliosId!="SN")
                                  vm.ddPAuxiliosId = vm.ddPAuxiliosId == "1" ? "S" : "N";
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEntPersona = new Ent_GENEPERSONA();
                                    ocampoEntPersona.COD_PERSONA = dr["COD_SUPERVISOR"].ToString();
                                    ocampoEntPersona.APE_PATERNO = dr["APE_PATERNO"].ToString();
                                    ocampoEntPersona.APE_MATERNO = dr["APE_MATERNO"].ToString();
                                    ocampoEntPersona.NOMBRES = dr["NOMBRE_SUPERVISOR"].ToString();
                                    ocampoEntPersona.PERSONA = dr["NOMBRE_SUPERVISOR"].ToString();
                                    ocampoEntPersona.N_DOCUMENTO = dr["N_DOCUMENTO"] == DBNull.Value ? string.Empty : dr["N_DOCUMENTO"].ToString();
                                    ocampoEntPersona.COD_DIDENTIDAD = dr["COD_DIDENTIDAD"].ToString();
                                    ocampoEntPersona.COD_NACADEMICO = dr["COD_NACADEMICO"] == DBNull.Value ? string.Empty : dr["COD_NACADEMICO"].ToString();
                                    ocampoEntPersona.COD_DPESPECIALIDAD = dr["COD_DPESPECIALIDAD"] == DBNull.Value ? string.Empty : dr["COD_DPESPECIALIDAD"].ToString();
                                    ocampoEntPersona.COLEGIATURA_NUM = dr["COLEGIATURA_NUM"]  == DBNull.Value ? string.Empty : dr["COLEGIATURA_NUM"].ToString();
                                    ocampoEntPersona.CARGO = dr["CARGO"] == DBNull.Value ? string.Empty : dr["CARGO"].ToString();
                                    ocampoEntPersona.COD_PTIPO = "0000007";
                                    ocampoEntPersona.RegEstado = 0;
                                    vm.tbSupervisor.Add(ocampoEntPersona);
                                }
                            }
                        }
                    }
                    return vm;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
    }
}
