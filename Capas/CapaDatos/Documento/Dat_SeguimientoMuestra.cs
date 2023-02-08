using CapaEntidad.DOC;
using CapaEntidad.Documento;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
//using SQL = GeneralSQL.Data.SQL;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
namespace CapaDatos.Documento
{
    public class Dat_SeguimientoMuestra
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        public string SaveSeguimientoCabecera(Ent_Seguimiento_Muestra ent)
        {
            String OUTPUTPARAM01 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspSeguimiento_Muestra_GrabarV3", ent))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                        if (OUTPUTPARAM01 == "99")
                        {
                            tr.Rollback();
                            tr = null;
                            throw new Exception("Ud. no tiene permiso para realizar esta acción");
                        }
                        if (OUTPUTPARAM01 == "0")
                        {
                            tr.Rollback();
                            tr = null;
                            throw new Exception("El Número de informe para este Seguimiento ya Existe");
                        }
                        else if (OUTPUTPARAM01 == "1")
                        {
                            tr.Rollback();
                            tr = null;
                            throw new Exception("El Número de informe ya Existe en Otro ");
                        }
                        else if (OUTPUTPARAM01 == "2")
                        {
                            tr.Rollback();
                            tr = null;
                            throw new Exception("No Tiene Permisos para Modificar este Seguimiento");
                        }
                        else if (OUTPUTPARAM01 == "3")
                        {
                            tr.Rollback();
                            tr = null;
                            throw new Exception("Está con Control de Calidad, no puede modificar");
                        }
                        ent.COD_SEG_MUESTRA = OUTPUTPARAM01;
                    }
                    //
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
            return OUTPUTPARAM01;
        }

        ///  @COD_SEG_MUESTRA=valor,@BusCriterio='SEGUIMIENTO_MUESTRA_LISTAR',@COD_SECUENCIAL=null 
        ///  Obtiene un listado de Muestras Dendrologicas
        public List<Dictionary<string, string>> GetListSeguimientoDetalle(Ent_Seguimiento_Muestra ent)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspSeguimiento_Muestra_GetV3", ent))
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
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///  @COD_SEG_MUESTRA=valor,@BusCriterio='SEGUIMIENTO',@COD_SECUENCIAL=null        
        public VM_SeguimientoMuestra GetSeguimientoCabecera(Ent_Seguimiento_Muestra ent)
        {
            VM_SeguimientoMuestra result = new VM_SeguimientoMuestra();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspSeguimiento_Muestra_GetV3", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {

                                    result.id = dr["COD_SEG_MUESTRA"].ToString();
                                    result.hdEstado = 0;
                                    result.ddlODRegistroId = dr["COD_OD_REGISTRO"].ToString();
                                    result.lblUsuarioRegistro = dr["USUARIO_REGISTRO"].ToString();
                                    //result.lblTituloEstado =;
                                    result.desSupervision = dr["NUMERO"].ToString();
                                    result.codSupervision = dr["COD_INFORME"].ToString();
                                    result.desTHabilitante = dr["NUM_TH"].ToString();
                                    result.codTH = dr["COD_THABILITANTE"].ToString();
                                    result.desNotificacion = dr["NUM_CNOTIF"].ToString();
                                    result.desTramEnvio = dr["cCodificacion"].ToString();
                                    result.codTramiteEnvio = dr["iCodTramite"].ToString();
                                    result.desTramRespuesta = dr["cCodificacionR"].ToString();
                                    result.codTramiteRespuesta = dr["iCodTramiteR"].ToString();
                                    result.observacion = dr["OBSERVACION"].ToString();
                                    result.pdf_id_tram_envio = dr["PDF_TRAMITE_SITD_ENVIO"].ToString();
                                    result.pdf_id_tram_respuesta = dr["PDF_TRAMITE_SITD_RESPUESTA"].ToString();
                                    //  result.obsCalidad = dr["iCodTramiteR"].ToString();
                                    //  result.obsSubsanar = dr["iCodTramiteR"].ToString();

                                    //otros datos
                                    result.cNroDocumentoE = dr["cNroDocumento"].ToString();
                                    result.fFecDocumentoE = dr["fFecDocumento"].ToString();
                                    result.cAsuntoE = dr["cAsunto"].ToString();
                                    result.cNroDocumentoR = dr["cNroDocumentoR"].ToString();
                                    result.fFecDocumentoR = dr["fFecDocumentoR"].ToString();
                                    result.cAsuntoR = dr["cAsuntoR"].ToString();
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    result.ddlItemIndicadorId = dr["COD_ESTADO_DOC"].ToString();
                                    result.lblUsuarioControl = dr["USUARIO_CONTROL"].ToString();
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
        public VM_SeguimientoMuestraDetalle GetDatosCaracteristicas(Ent_BUSQUEDA ent)
        {
            VM_SeguimientoMuestraDetalle result = new VM_SeguimientoMuestraDetalle();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {    //De la forma del fuste
                                result.cboFFuste = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboFFuste.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {  //--Del tipo de ramificación
                                result.cboTRamificacion = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboTRamificacion.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {   //Del tipo de raices
                                result.cboTRaices = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboTRaices.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {  //De la corteza externa-Color
                                result.cboCEColor = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboCEColor.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {  //De la corteza externa-De las lenticelas
                                result.cboCELenticelas = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboCELenticelas.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {  //De la corteza externa-Del ritidoma
                                result.cboCERitidoma = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboCERitidoma.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {  //Otras estructuras
                                result.cboCEOExtructura = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboCEOExtructura.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {   //De la corteza interna-Del exudado-Tipo
                                result.cboCIETipo = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboCIETipo.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {   //De la corteza interna-Del exudado-Color
                                result.cboCIEColor = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboCIEColor.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {  //De la corteza interna-Del exudado-Sabor
                                result.cboCIESabor = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboCIESabor.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {   //De la corteza interna-Del exudado-Abundancia
                                result.cboCIEAbundancia = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboCIEAbundancia.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {   //De la corteza interna-Tipo
                                result.cboCITipo = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboCITipo.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {   //De las inclusiones en el fuste-Espinas
                                result.cboIFEspinas = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboIFEspinas.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {    //De las inclusiones en el fuste- Aguijones
                                result.cboIFAguijones = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboIFAguijones.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {    //De las hojas- Por su forma
                                result.cboHojaForma = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboHojaForma.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {     //De las hojas- Tipo de borde
                                result.cboHojaBorde = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboHojaBorde.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {   //De las hojas- Disposición de la lamina
                                result.cboHojaLamina = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboHojaLamina.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            { //De las flores- color
                                result.cboFloresColor = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboFloresColor.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {  //De los frutos-tipo
                                result.cboFrutosTipo = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboFrutosTipo.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            { //De los frutos-color
                                result.cboFrutosColor = new List<VM_Cbo>();
                                while (dr.Read())
                                {
                                    result.cboFrutosColor.Add(new VM_Cbo { Value = dr["CODIGO"].ToString(), Text = dr["DESCRIPCION"].ToString() });
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
        ///  @COD_SEG_MUESTRA=valor,@BusCriterio='SEGUIMIENTO_MUESTRA',@COD_SECUENCIAL=null        
        public VM_SeguimientoMuestraDetalle GetSeguimienDetalle(Ent_Seguimiento_Muestra ent)
        {
            VM_SeguimientoMuestraDetalle result = this.GetDatosCaracteristicas(new Ent_BUSQUEDA { BusFormulario = "SEGUIMIENTO_MUESTRA" });//new VM_SeguimientoMuestraDetalle();
            result.fotos = new List<VM_ArchivoMuestra>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspSeguimiento_Muestra_GetV3", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    result.codSeguimiento = dr["COD_SEG_MUESTRA"].ToString();
                                    result.secuencial = Convert.ToInt32(dr["COD_SECUENCIAL"].ToString());
                                    result.estado = 0;
                                    result.codMuestra = dr["COD_MUESTRA"].ToString();
                                    result.Z_UTMId = dr["ZONAUTM"].ToString();
                                    result.C_ESTE = dr["COORDENADA_ESTE"].ToString();
                                    result.C_NORTE = dr["COORDENADA_NORTE"].ToString();
                                    result.SECTOR = dr["SECTOR"].ToString();
                                    result.fColeccion = dr["FECHA_COLECCION"].ToString();
                                    result.obs = dr["OBSERVACION"].ToString();
                                    result.poa = dr["DESPOA"].ToString();
                                    result.idPoa = dr["NUM_POA"].ToString().Trim() == "" ? (int?)null : Convert.ToInt32(dr["NUM_POA"].ToString());

                                    result.codEspecie = dr["COD_ESPECIES"].ToString();
                                    result.especie = dr["ESPECIE"].ToString();
                                    result.cboFFusteId = dr["C_FFuste"].ToString();
                                    result.cboTRamificacionId = dr["C_TRAMIFICACION"].ToString();
                                    result.cboTRaicesId = dr["C_TRAICES"].ToString();
                                    result.cboCEColorId = dr["C_CECOLOR"].ToString();
                                    result.cboCELenticelasId = dr["C_CELENTICELAS"].ToString();
                                    result.cboCERitidomaId = dr["C_CERITIDOMA"].ToString();
                                    result.cboCEOExtructuraId = dr["C_CEOTRAS_ESTRUCTURAS"].ToString();
                                    result.cortezaiColor = dr["C_CICOLOR"].ToString();
                                    result.cortezaiOlor = dr["C_CIOLOR"].ToString();
                                    result.cboCIETipoId = dr["C_CI_EXU_TIPO"].ToString();
                                    result.cboCIEColorId = dr["C_CI_EXU_COLOR"].ToString();
                                    result.cortezaiExuOlor = dr["C_CI_EXU_OLOR"].ToString();
                                    result.cboCIESaborId = dr["C_CI_EXU_SABOR"].ToString();
                                    result.cboCIEAbundanciaId = dr["C_CI_EXU_ABUNDANCIA"].ToString();
                                    result.otrasCaracteristica = dr["C_CI_EXU_OTRA_CARACT"].ToString();
                                    result.cboCITipoId = dr["C_CI_TIPO"].ToString();
                                    result.cboIFEspinasId = dr["C_IFUSTE_ESPINAS"].ToString();
                                    result.cboIFAguijonesId = dr["C_IFUSTE_AGUIJONES"].ToString();
                                    result.otrasEstructuras = dr["C_IFUSTE_OTRAS_ESTRUCTURAS"].ToString();
                                    result.habitoArbol = dr["C_HABITO_ARBOL"].ToString();
                                    result.chkHSimple = Convert.ToBoolean(dr["C_HOJA_SIMPLE"]);
                                    result.chkHCompuesta = Convert.ToBoolean(dr["C_HOJA_COMPUESTA"]);
                                    result.cboHojaFormaId = dr["C_HOJA_FORMA"].ToString();
                                    result.cboHojaBordeId = dr["C_HOJA_BORDE"].ToString();
                                    result.cboHojaLaminaId = dr["C_HOJA_DISPOSICION"].ToString();
                                    result.cboFloresColorId = dr["C_FLORES_COLOR"].ToString();
                                    result.floresTamaño = dr["C_FLORES_TAMAÑO"].ToString();
                                    result.chkFSimple = Convert.ToBoolean(dr["C_FLORES_SIMPLE"]);
                                    result.chkFInflorescencia = Convert.ToBoolean(dr["C_FLORES_INFLORESCENCIA"]);
                                    result.floresOtrasCaract = dr["C_FLORES_OTRA_CARACT"].ToString();
                                    result.cboFrutosTipoId = dr["C_FRUTOS_TIPO"].ToString();
                                    result.cboFrutosColorId = dr["C_FRUTOS_COLOR"].ToString();
                                    result.frutosTamanio = dr["C_FRUTOS_TAMANIO"].ToString();
                                    result.frutosOtrasCaract = dr["C_FRUTOS_OTRA_CARACT"].ToString();
                                    //especies censo
                                    result.especieCensoDes = dr["especieCensoDes"].ToString();
                                    result.estadoEspecieCenso = dr["estadoEspecieCenso"].ToString();
                                    result.condicionEspecieCenso = dr["condicionEspecieCenso"].ToString();
                                    result.esMaderable = Convert.ToInt32(dr["esMaderable"]);
                                    result.codSecuencialCenso = Convert.ToInt32(dr["COD_SECUENCIAL_CENSO"]);
                                    result.ddlCensoId = dr["COD_CENSO"].ToString();
                                    //datos supervisor y colector
                                    result.colectorId = dr["COD_COLECTOR"].ToString();
                                    result.colectorDes = dr["COLECTOR"].ToString();
                                    result.supervisorId = dr["COD_SUPERVISOR"].ToString();
                                    result.supervisoDes = dr["SUPERVISOR"].ToString();

                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_ArchivoMuestra fotos;
                                while (dr.Read())
                                {
                                    fotos = new VM_ArchivoMuestra();
                                    fotos.secuencial = Convert.ToInt32(dr["COD_SECUENCIAL_ARCHIVO"].ToString());
                                    fotos.archivo = dr["NOMBRE_ARCH"].ToString();
                                    fotos.ext = dr["EXTENSION_ARCH"].ToString();
                                    fotos.generado = dr["COD_SEG_MUESTRA"].ToString() + "_" + dr["COD_SECUENCIAL"].ToString() + "_" + dr["COD_SECUENCIAL_ARCHIVO"].ToString() + "." + dr["EXTENSION_ARCH"].ToString();
                                    result.fotos.Add(fotos);
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
        public bool DeleteSeguimientoMuestra(List<Ent_Seguimiento_Muestra_Detalle> lstEnt)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Eliminando
                    foreach (var ent in lstEnt)
                    {
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspSeguimiento_Muestra_Detalle_GrabarV3", ent))
                        {
                            cmd.ExecuteNonQuery();
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
        public bool SaveSeguimientoMuestra(Ent_Seguimiento_Muestra_Detalle ent)
        {
            int OUTPUTPARAMDET01;
            string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            List<string> lstPath = new List<string>();
            List<string> lstPathEli = new List<string>();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspSeguimiento_Muestra_Detalle_GrabarV3", ent))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAMDET01 = Convert.ToInt32(cmd.Parameters["OUTPUTPARAMDET01"].Value);
                    }
                    //eliminando archivos
                    if (ent.fotosEli != null)
                    {
                        string nombreArchEli = "";
                        foreach (var item in ent.fotosEli)
                        {
                            item.fname = null;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspSeguimiento_Muestra_Detalle_FotoV3", item);
                            nombreArchEli = item.COD_SEG_MUESTRA + "_" + item.COD_SECUENCIAL + "_" + item.COD_SECUENCIAL_ARCHIVO.ToString() + "." + item.EXTENSION_ARCH;
                            if (System.IO.File.Exists(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/" + nombreArchEli)))
                            {    //moviendo archivos a la carpeta historial
                                System.IO.File.Copy(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/" + nombreArchEli), System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/Historico/" + nombreArchEli));
                                lstPathEli.Add(nombreArchEli);
                                //eliminando 
                                System.IO.File.Delete(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/" + nombreArchEli));
                            }
                        }
                    }
                    //registrando las fotos
                    if (ent.fotos != null)
                    {
                        int codSecuencialPadre = OUTPUTPARAMDET01;
                        string nombreArchTemporal = "";
                        string nombreArchivo = "";
                        foreach (var item in ent.fotos)
                        {
                            item.COD_SECUENCIAL = codSecuencialPadre;
                            nombreArchTemporal = item.fname;
                            item.fname = null;
                            using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspSeguimiento_Muestra_Detalle_FotoV3", item))
                            {
                                cmd.ExecuteNonQuery();
                                item.COD_SECUENCIAL_ARCHIVO = Convert.ToInt32(cmd.Parameters["OUTPUTPARAMDET01"].Value);
                            }
                            nombreArchivo = item.COD_SEG_MUESTRA + "_" + item.COD_SECUENCIAL.ToString() + "_" + item.COD_SECUENCIAL_ARCHIVO.ToString() + "." + item.EXTENSION_ARCH;
                            if (System.IO.File.Exists(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/Temp/" + nombreArchTemporal)))
                            {   //Grabando archivos
                                System.IO.File.Copy(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/Temp/" + nombreArchTemporal), System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/" + nombreArchivo));
                                lstPath.Add(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/" + nombreArchivo));
                                //eliminando temporal
                                System.IO.File.Delete(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/Temp/" + nombreArchTemporal));
                            }
                        }
                    }
                    //
                    tr.Commit();

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
                    if (lstPathEli.Count > 0)
                    {
                        for (int i = 0; i < lstPathEli.Count; i++)
                        {
                            if (System.IO.File.Exists(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/Historico/" + lstPathEli[i])))
                            {    //si hay error regresamos los archivos a su carpeta original
                                System.IO.File.Copy(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/Historico/" + lstPathEli[i]), System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/" + lstPathEli[i]));
                                //eliminando 
                                System.IO.File.Delete(System.IO.Path.Combine(baseDirectory, "Archivos/Modulo/Supervision/MuestraDendrologica/Historico/" + lstPathEli[i]));
                            }
                        }
                    }
                    throw ex;
                }
            }
            return true;
        }

        public List<VM_SeguimientoMuestra> reporteDendrenales(OracleConnection cn)
        {
            List<VM_SeguimientoMuestra> vM_REPORTE_DENDRENALES = new List<VM_SeguimientoMuestra>();
            try
            {
                OracleTransaction tr = null;
                tr = cn.BeginTransaction();
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.SP_LISTAR_SOBRE_INFORME_DENDROLOGICA", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    string id = dBOracle.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_SEG_MUESTRA"))).Trim();
                                    var detalle = new VM_SeguimientoMuestraDetalle();
                                    detalle.codSeguimiento = id;
                                    detalle.codMuestra = dBOracle.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_MUESTRA")));
                                    detalle.fColeccion = dBOracle.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("FECHA_COLECCION")));
                                    detalle.Z_UTMId = dBOracle.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("ZONAUTM")));
                                    detalle.C_ESTE = dr["COORDENADA_ESTE"].ToString();
                                    detalle.C_NORTE = dr["COORDENADA_NORTE"].ToString();
                                    detalle.codCenso = dr["CODIGO_CENSO"].ToString();
                                    detalle.poa = dr["DESPOA"].ToString();
                                    detalle.descripcion = dr["DESCRIPCION"].ToString();

                                    detalle.estadoEspecieCenso = dr["estadoEspecieCenso"].ToString();
                                    detalle.condicionEspecieCenso = dr["CONDICION"].ToString();
                                    detalle.colectorDes = dr["COLECTOR"].ToString();
                                    detalle.supervisoDes = dr["SUPERVISORDETALLE"].ToString();
                                    detalle.cboFFusteId = dr["FUSTE"].ToString();
                                    detalle.cboTRamificacionId = dr["RAMI"].ToString();
                                    detalle.cboTRaicesId = dr["RAICE"].ToString();
                                    detalle.cboCEColorId = dr["COLOR"].ToString();
                                    detalle.cboCELenticelasId = dr["LENTI"].ToString();
                                    detalle.cboCERitidomaId = dr["RITI"].ToString();
                                    detalle.cboCEOExtructuraId = dr["OTROEST"].ToString();
                                    detalle.cortezaiColor = dr["C_CICOLOR"].ToString();
                                    detalle.cortezaiOlor = dr["C_CIOLOR"].ToString();
                                    detalle.cboCIETipoId = dr["TIPO"].ToString();
                                    detalle.cboCIEColorId = dr["COLOREX"].ToString();
                                    detalle.cortezaiExuOlor = dr["C_CI_EXU_OLOR"].ToString();
                                    detalle.cboCIESaborId = dr["SABOR"].ToString();
                                    detalle.cboCIEAbundanciaId = dr["ABUN"].ToString();
                                    detalle.otrasCaracteristica = dr["C_CI_EXU_OTRA_CARACT"].ToString();
                                    detalle.cboCITipoId = dr["TIPCI"].ToString();
                                    detalle.cboIFEspinasId = dr["ESPINAS"].ToString();
                                    detalle.cboIFAguijonesId = dr["AGUIJONES"].ToString();
                                    detalle.otrasEstructuras = dr["C_IFUSTE_OTRAS_ESTRUCTURAS"].ToString();
                                    detalle.habitoArbol = dr["C_HABITO_ARBOL"].ToString();
                                    detalle.chkHSimple = Convert.ToBoolean(dr["C_HOJA_SIMPLE"]);
                                    detalle.chkHCompuesta = Convert.ToBoolean(dr["C_HOJA_COMPUESTA"]);
                                    detalle.cboHojaFormaId = dr["HOJAFORMA"].ToString();
                                    detalle.cboHojaBordeId = dr["HOJABORDE"].ToString();
                                    detalle.cboHojaLaminaId = dr["HOJASLAMINA"].ToString();
                                    detalle.cboFloresColorId = dr["COLORFLORES"].ToString();
                                    detalle.floresTamaño = dr["C_FLORES_TAMAÑO"].ToString();
                                    detalle.chkFSimple = Convert.ToBoolean(dr["C_FLORES_SIMPLE"]);
                                    detalle.chkFInflorescencia = Convert.ToBoolean(dr["C_FLORES_INFLORESCENCIA"]);
                                    detalle.floresOtrasCaract = dr["C_FLORES_OTRA_CARACT"].ToString();
                                    detalle.cboFrutosTipoId = dr["FRUTOTIPO"].ToString();
                                    detalle.cboFrutosColorId = dr["FRUTOCOLOR"].ToString();
                                    detalle.frutosTamanio = dr["C_FRUTOS_TAMANIO"].ToString();
                                    detalle.frutosOtrasCaract = dr["C_FRUTOS_OTRA_CARACT"].ToString();
                                    detalle.codEspecie = dr["ESPECIE_RESP"].ToString();
                                    detalle.especieCensoDes = dr["ESPECIE_CEN"].ToString();
                                    detalle.estado = Convert.ToInt32(dr["ESTADO"]);
                                    
                                    var item = vM_REPORTE_DENDRENALES.Find(info => info.id.Trim() == id);
                                    if (item == null)
                                    {
                                        vM_REPORTE_DENDRENALES.Add(new VM_SeguimientoMuestra
                                        {
                                            anio = Convert.ToInt32(dr["ANIO_REGISTRO"]),
                                            fecha = dr["FECHA_REGISTRO"].ToString(),
                                            id = id,
                                            codTramiteEnvio = dr["COD_TRAMITE_ENVIO"].ToString(),
                                            desTramEnvio = dr["cCodificacionEnvio"].ToString(),
                                            codTramiteRespuesta = dr["COD_TRAMITE_RESPUESTA"].ToString(),
                                            desTramRespuesta = dr["cCodificacionRpta"].ToString(),
                                            desSupervision = dr["NUMERO"].ToString(),
                                            desNotificacion = dr["NUM_CNOTIF"].ToString(),
                                            modalidad = dr["MOD_T"].ToString(),
                                            desTHabilitante = dr["NUM_TH"].ToString(),
                                            titular = dr["TITULAR"].ToString(),
                                            supervisor = dr["SUPERVISOR"].ToString(),
                                            poa = dr["POA"].ToString(),
                                            ddlODRegistroId = dr["OD_DESCRIPCION"].ToString(),
                                            detalle = new List<VM_SeguimientoMuestraDetalle> { detalle }
                                        });

                                    }
                                    else
                                    {
                                        item.detalle.Add(detalle);
                                    }
                                }
                            }
                        }
                    }
                }
                tr.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
            return vM_REPORTE_DENDRENALES;
        }
    }
}






