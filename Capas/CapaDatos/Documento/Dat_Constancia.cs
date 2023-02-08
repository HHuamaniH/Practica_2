using CapaEntidad.ViewModel.DOC;
using GeneralSQL;
using GeneralSQL.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidad = CapaEntidad.DOC.Ent_Constancia;

namespace CapaDatos.DOC
{
    public class Dat_Constancia
    {
        private DBOracle dBOracle = new DBOracle();

        public List<Dictionary<string, string>> ListarConstancia(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar_Paging", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Dictionary<string, string> sFila;
                            string sColumn = "";
                            while (dr.Read())
                            {
                                sFila = new Dictionary<string, string>();
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    sColumn = dr.GetName(i);
                                    sFila.Add(sColumn, dr[sColumn].ToString());
                                }
                                lstResult.Add(sFila);
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene una constancia por su identificado NV_CONSTANCIA
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="identificador"></param>
        /// <returns></returns>
        public VM_CONSTANCIA ObtenerPorIdentificador(OracleConnection cn, string identificador)
        {
            VM_CONSTANCIA constancia = null;
            try
            {
                object[] param = { identificador };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_CONSTANCIA_OBTENER_POR_CODIGO", param))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            constancia = new VM_CONSTANCIA();
                            constancia.NV_CONSTANCIA = dr["NV_CONSTANCIA"].ToString();
                            constancia.COD_INFORME = dr["COD_INFORME"].ToString();                            
                            constancia.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                            constancia.COD_TITULAR = dr["COD_TITULAR"].ToString();
                            constancia.NUMERO = dr["NUMERO"].ToString();
                            constancia.NUMERO_INFORME = dr["NUMERO_INFORME"].ToString();
                            constancia.NUMERO_TH = dr["NUMERO_TH"].ToString();
                            constancia.APELLIDOS_NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                            constancia.FECHA_SUPERVISION_INICIO = Convert.ToDateTime(dr["FECHA_SUPERVISION_INICIO"]);
                            constancia.FECHA_SUPERVISION_FIN= Convert.ToDateTime(dr["FECHA_SUPERVISION_FIN"]);                           
                            constancia.FECHA_INFORME = dr["FECHA_INFORME"].ToString().Trim() == "" ? null : (DateTime?)Convert.ToDateTime((dr["FECHA_INFORME"]));
                            constancia.TIPO_PLAN = dr["TIPO_PLAN"].ToString();
                            constancia.NUM_POA = dr["NUM_POA"].ToString();
                            constancia.PARCELA = dr["PARCELA"].ToString();
                            constancia.FECHA_EMISION= dr["FECHA_EMISION"].ToString().Trim() == "" ? null : (DateTime?)Convert.ToDateTime(dr["FECHA_EMISION"]);
                            constancia.COD_UCUENTA_GENERA = dr["COD_UCUENTA_GENERA"].ToString();
                            constancia.COD_UCUENTA_EMITE = dr["COD_UCUENTA_EMITE"].ToString();
                            constancia.ESTADO_DOCUMENTO = dr["ESTADO_DOCUMENTO"].ToString();
                            constancia.FE_CREACION= Convert.ToDateTime(dr["FE_CREACION"]);
                            constancia.FE_MODIFICAR= dr["FE_MODIFICAR"].ToString().Trim()=="" ? null : (DateTime?)Convert.ToDateTime(dr["FE_MODIFICAR"]);
                            constancia.NU_ESTADO = Convert.ToInt32(dr["NU_ESTADO"]);
                            constancia.TRAMITE_ID = Convert.ToInt32(dr["TRAMITE_ID"]);
                            constancia.ARCHIVO = dr["ARCHIVO"].ToString();
                            constancia.ARCHIVO_TEMP = dr["ARCHIVO_TEMP"].ToString();
                        }
                    }
                }

                return constancia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ActualizarDatosIntegración(string identificador,string numero,
                          DateTime fechaEmision,string codUsuario,string estadoDocumento,DateTime fechaModificar,int tramiteId,string archivo)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                try
                {
                    object[] param = { identificador, numero, fechaEmision,codUsuario, estadoDocumento,
                                        fechaModificar,tramiteId ,archivo};
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_CONSTANCIA_ACTUALIZAR_SITD", param);
                    success = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return success;
        }
        public bool ActualizarArchivoConstancia(string identificador,string archivo)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                try
                {
                    object[] param = { identificador ,archivo};
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_ACTUALIZAR_ARCHIVO_CONSTANCIA", param);
                    success = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return success;
        }
        public bool ActualizarEstado(string identificador,  string estadoDocumento, DateTime fechaModificar,string usuarioModificacion)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                try
                {
                    object[] param = { identificador, estadoDocumento,fechaModificar, usuarioModificacion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_CONSTANCIA_ACTUALIZAR_ESTADO", param);
                    success = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return success;
        }
        #region "SQL SERVER"
        public int TramiteGuardar(VM_CONSTANCIA_TRAMITE tramite)
        {

            SQL oGDataSQL = new SQL();
            SqlTransaction tr = null;
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_SIGO_FIS_SALIDA_TRA_M_TRAMITE_GRABAR";
                        cmd.Parameters.AddWithValue("@pIcCodTipoDoc", tramite.codTipoDoc);
                        cmd.Parameters.AddWithValue("@pIiCodOficina", tramite.codOficina);
                        cmd.Parameters.AddWithValue("@pTcAsunto", tramite.asunto);
                        cmd.Parameters.AddWithValue("@pVcObservaciones", tramite.observacion);
                        cmd.Parameters.AddWithValue("@pCnNumFolio", tramite.numFolio);
                        cmd.Parameters.AddWithValue("@pIiCodTrabajadorLogin", tramite.trabajadorLoginId);
                        cmd.Parameters.AddWithValue("@pDFechaOperacion", tramite.fechaEmision);                        
                        //cmd.Parameters.AddWithValue("@i_iCodRemitente", tramite.remitenteId);
                        //cmd.Parameters.AddWithValue("@i_cNomRemite", tramite.persona);
                        cmd.Parameters.AddWithValue("@i_cDireccion", tramite.direccion);
                        cmd.Parameters.AddWithValue("@i_cDepartamento", tramite.departamento);
                        cmd.Parameters.AddWithValue("@i_cProvincia", tramite.provincia);
                        cmd.Parameters.AddWithValue("@i_cDistrito", tramite.distrito);
                        cmd.Parameters.Add("@pIiCodTramite",SqlDbType.Int).Direction= ParameterDirection.Output;

                        cmd.Transaction = tr;
                        cmd.ExecuteNonQuery();
                        tramite.tramiteId = Convert.ToInt32(cmd.Parameters["@pIiCodTramite"].Value);

                    }
                    tr.Commit();
                    cn.Close();
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
            return tramite.tramiteId;

        }
        public int TramiteGuardarConstancia(VM_CONSTANCIA_TRAMITE tramite)
        {

            SQL oGDataSQL = new SQL();
            SqlTransaction tr = null;
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_SIGO_FIS_SALIDA_TRA_M_TRAMITE_GRABAR_CONSTANCIA";
                        cmd.Parameters.AddWithValue("@pIcCodTipoDoc", tramite.codTipoDoc);
                        cmd.Parameters.AddWithValue("@pIiCodOficina", tramite.codOficina);
                        cmd.Parameters.AddWithValue("@pTcAsunto", tramite.asunto);
                        cmd.Parameters.AddWithValue("@pVcObservaciones", tramite.observacion);
                        cmd.Parameters.AddWithValue("@pCnNumFolio", tramite.numFolio);
                        cmd.Parameters.AddWithValue("@pIiCodTrabajadorLogin", tramite.trabajadorLoginId);
                        cmd.Parameters.AddWithValue("@pDFechaOperacion", tramite.fechaEmision);
                        cmd.Parameters.AddWithValue("@pcCodificacion", tramite.codificacionINF);
                        //cmd.Parameters.AddWithValue("@i_iCodRemitente", tramite.remitenteId);
                        //cmd.Parameters.AddWithValue("@i_cNomRemite", tramite.persona);
                        cmd.Parameters.AddWithValue("@i_cDireccion", tramite.direccion);
                        cmd.Parameters.AddWithValue("@i_cDepartamento", tramite.departamento);
                        cmd.Parameters.AddWithValue("@i_cProvincia", tramite.provincia);
                        cmd.Parameters.AddWithValue("@i_cDistrito", tramite.distrito);
                        cmd.Parameters.Add("@pIiCodTramite", SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd.Transaction = tr;
                        cmd.ExecuteNonQuery();
                        tramite.tramiteId = Convert.ToInt32(cmd.Parameters["@pIiCodTramite"].Value);

                    }
                    tr.Commit();
                    cn.Close();
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
            return tramite.tramiteId;

        }
        public bool TramiteDigitalGuardar(int tramiteId,string nombreOriginal,string nombreNuevo,DateTime fechaOperacion)
        {
            bool success = false;
            SQL oGDataSQL = new SQL();
            SqlTransaction tr = null;
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_SIGO_FIS_SALIDA_TRA_M_TRAMITE_DIGITALES_GRABAR";
                        cmd.Parameters.AddWithValue("@iCodTramite", tramiteId);
                        cmd.Parameters.AddWithValue("@cNombreOriginal", nombreOriginal);
                        cmd.Parameters.AddWithValue("@cNombreNuevo", nombreNuevo);
                        cmd.Parameters.AddWithValue("@fechaOperacion", fechaOperacion);                       
                        cmd.Transaction = tr;
                        cmd.ExecuteNonQuery();    
                    }
                    tr.Commit();
                    success = true;
                    cn.Close();                   
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
            return success;

        }
        public VM_CONSTANCIA_TRAMITE TramiteObtenerById(int tramiteId)
        {
            VM_CONSTANCIA_TRAMITE vm = null;
            SQL oGDataSQL = new SQL();

            object[] param = { tramiteId };
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                cn.Open();
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "USP_SIGO_FIS_SALIDA_TRA_M_TRAMITE_GETBYID", param))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            vm = new VM_CONSTANCIA_TRAMITE();
                            vm.tramiteId = Convert.ToInt32(dr["iCodTramite"]);
                            vm.codificacion = dr["cCodificacion"].ToString();
                            vm.password = dr["cPassword"].ToString();
                            vm.fechaEmision = Convert.ToDateTime(dr["fFecDocumento"]);                         
                            vm.descripcionTipoDoc = dr["cDescTipoDoc"].ToString();                           
                            vm.asunto = dr["cAsunto"] == null ? string.Empty : dr["cAsunto"].ToString().Trim();
                            vm.observacion = dr["cObservaciones"] == null ? string.Empty : dr["cObservaciones"].ToString().Trim();
                                                  
                        }
                    }
                }
            }
            return vm;
        }
        /// <summary>       
        /// </summary>
        /// <param name="tipoPersona">N=Natural, J=Juridica  (COD_TPERSONA)</param>
        /// <param name="tipoDocumento">0000001=DOC.NACIONAL DE IDENTIDAD(COD_DIDENTIDAD),0000002=PASAPORTE,0000006=REG.ÚNICO DE CONTRIBUYENTES(*)</param>
        /// <param name="nroDocumento"></param>
        /// <param name="remitenteId"></param>
        /// <param name="datosRemitente"></param>
        public VM_CONSTANCIA_REMITENTE RemitenteObtenerByNroDocumento(string tipoPersona,string tipoDocumento,string nroDocumento)
        {
            VM_CONSTANCIA_REMITENTE vm = null;
             SQL oGDataSQL = new SQL();

            object[] param = { tipoPersona, tipoDocumento , nroDocumento };
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                cn.Open();
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "USP_SIGO_FIS_TRA_M_REMITENTE_BYNRODOCUMENTO", param))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            vm = new VM_CONSTANCIA_REMITENTE();
                            vm.remitenteId = Convert.ToInt32(dr["iCodRemitente"]);
                            vm.persona = dr["cNombre"].ToString();
                            vm.nroDocumento = dr["nNumDocumento"].ToString();                         
                            vm.direccion = dr["cDireccion"].ToString();
                            vm.codDepartamento = dr["cDepartamento"].ToString();
                            vm.codProvincia = dr["cProvincia"].ToString();
                            vm.codDistrito = dr["cDistrito"].ToString();
                        }
                    }
                }
            }
            return vm;
        }
        public VM_CONSTANCIA_REMITENTE RemitenteObtenerById(int remitenteId)
        {
            VM_CONSTANCIA_REMITENTE vm = null;
            SQL oGDataSQL = new SQL();

            object[] param = { remitenteId };
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                cn.Open();
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "USP_SIGO_FIS_TRA_M_REMITENTE_BYID", param))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            vm = new VM_CONSTANCIA_REMITENTE();
                            vm.remitenteId = Convert.ToInt32(dr["iCodRemitente"]);
                            vm.persona = dr["cNombre"].ToString();
                            vm.nroDocumento = dr["nNumDocumento"].ToString();
                            vm.direccion = dr["cDireccion"].ToString();
                            vm.codDepartamento = dr["cDepartamento"].ToString();
                            vm.codProvincia = dr["cProvincia"].ToString();
                            vm.codDistrito = dr["cDistrito"].ToString();
                        }
                    }
                }
            }
            return vm;
        }
        public int RemitenteCrear(VM_CONSTANCIA_REMITENTE remitente)
        {
            SQL oGDataSQL = new SQL();
            SqlTransaction tr = null;
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_SIGO_FIS_TRA_M_REMITENTE_CREAR";
                        cmd.Parameters.AddWithValue("@pCTipoPersona", remitente.tipoPersona);
                        cmd.Parameters.AddWithValue("@pCNombre", remitente.persona);
                        cmd.Parameters.AddWithValue("@pCNumDocumento", remitente.nroDocumento);
                        cmd.Parameters.AddWithValue("@pCDireccion", remitente.direccion);
                        cmd.Parameters.AddWithValue("@pCEmail", remitente.email);
                        cmd.Parameters.AddWithValue("@pCNTelefono", remitente.telefono);
                        cmd.Parameters.AddWithValue("@pCDepartamento", remitente.codDepartamento);
                        cmd.Parameters.AddWithValue("@pCProvincia", remitente.codProvincia);
                        cmd.Parameters.AddWithValue("@pCDistrito", remitente.codDistrito);
                        cmd.Parameters.AddWithValue("@pICFlag", remitente.cFlag);
                        cmd.Parameters.AddWithValue("pVTipoDocumento", remitente.tipoDocumento);
                        cmd.Parameters.AddWithValue("@pIiCodRemitente", remitente.remitenteId);
                        cmd.Parameters["@pIiCodRemitente"].Direction = ParameterDirection.Output;
                        cmd.Transaction = tr;
                        cmd.ExecuteNonQuery();
                        remitente.remitenteId = Convert.ToInt32(cmd.Parameters["@pIiCodRemitente"].Value);

                    }
                    tr.Commit();
                    cn.Close();
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
            return remitente.remitenteId;
        }
        public void ObtenerJefeByOficina(int oficinaId,out int trabajadorId,out string nroDocumento,
                                         out string nombres,out string apellidos,out string oficina)
        {
          
            SQL oGDataSQL = new SQL();
            trabajadorId = 0;
            nroDocumento = string.Empty;
            nombres = string.Empty;
            apellidos = string.Empty;
            oficina = string.Empty;

            object[] param = { "JEFE_X_OFICINA", oficinaId.ToString() };
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                cn.Open();
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "USP_SIGO_SUPERVISION_GENERAL_LISTAR", param))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oficina = dr["cNomOficina"].ToString();
                            oficina = oficina?.Trim();                            
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                dr.Read();
                                trabajadorId = Convert.ToInt32(dr["iCodTrabajador"]);
                                nroDocumento = dr["cNumDocIdentidad"].ToString();
                                nroDocumento = nroDocumento?.Trim();
                                nombres = dr["cNombresTrabajador"].ToString();
                                nombres = nombres?.Trim();
                                apellidos = dr["cApellidosTrabajador"].ToString();
                                apellidos = apellidos?.Trim();
                            }
                            
                        }
                    }
                }
            }            
        }
        #endregion

    }
}
