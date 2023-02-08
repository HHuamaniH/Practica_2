using GeneralSQL;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_GUIA_TRANSPORTE;
using CEntidadView = CapaEntidad.DOC.Ent_PreVisualizar;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_GuiaTransporte
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        //lista para el thabilitante
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarTHLista(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        oCamposDet.TITULO = dr["NUMERO"].ToString();
        //                        oCamposDet.COD_TITULAR = dr["COD_TITULAR"].ToString();
        //                        oCamposDet.APELLIDOS_NOMBRES_TH = dr["APELLIDOS_NOMBRES"].ToString();
        //                        oCamposDet.DNI_TH = dr["DOCUMENTO"].ToString();
        //                        oCamposDet.RUC_TH = dr["RUC"].ToString();
        //                        oCamposDet.DIRECCION_TH = dr["DIRECCION"].ToString();
        //                        oCamposDet.TELEFONO = dr["NUMEROTELEFONICO"].ToString();
        //                        oCamposDet.COD_UBIGEO = dr["COD_UBIGEO"].ToString();
        //                        oCamposDet.UBIGEO_NAME = dr["UBIGEONAME"].ToString();
        //                        oCamposDet.COD_PERSONARLEGAL = dr["COD_RLEGAL"].ToString();
        //                        oCamposDet.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
        //                        lsCEntidad.Add(oCamposDet);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostCombo(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = null;
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Combo_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos = new CEntidad();
        //                List<CEntidad> lsDetDetalle;
        //                CEntidad oCamposDet;
        //                //Documento Identidad
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr["CODIGO"].ToString();
        //                        oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListMComboDIdentidad = lsDetDetalle;
        //                //Supervision Motivo
        //                dr.NextResult();
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr["CODIGO"].ToString();
        //                        oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListEspecies = lsDetDetalle;
        //                //Persona Especialidad
        //                dr.NextResult();
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr["CODIGO"].ToString();
        //                        oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListUnidadMedida = lsDetDetalle;
        //            }
        //        }
        //        return oCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public CEntidad RegMostComboProducto(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", oCEntidad))
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
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspecies = lsDetDetalle;
                        //Unidad de Medida
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
                        oCampos.ListUnidadMedida = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //grabar items
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    CEntidad oCamposDet;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spRGUIA_TRANSPORTEGrabar", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "100")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
        //            }
        //            else if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //            if (OUTPUTPARAM01 == "0")
        //            {
        //                if (oCEntidad.RegEstado == 99)
        //                {
        //                    tr.Rollback();
        //                    tr = null;
        //                    return OUTPUTPARAM01;
        //                }
        //                else
        //                {
        //                    tr.Rollback();
        //                    tr = null;
        //                    throw new Exception("El Nombre de la Guía  ya Existe");
        //                }
        //            }
        //            else if (OUTPUTPARAM01 == "3")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Este Control de Calidad no puede modificarse");
        //            }
        //            else if (OUTPUTPARAM01 == "2")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("No Tiene Permisos para Modificar este Registro");
        //            }
        //            else if (OUTPUTPARAM01 == "1")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Nombre de la Guía ya Existe");
        //            }
        //        }
        //        //Reemplazando El Nuevo Codigo Creado
        //        if (oCEntidad.RegEstado == 1) //Nuevo
        //        {
        //            oCEntidad.COD_GUIA_TRANS = OUTPUTPARAM01;
        //        }

        //        if (oCEntidad.listProducto != null)
        //        {
        //            foreach (var loDatos in oCEntidad.listProducto)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2 || loDatos.RegEstado == 99) //Nuevo o Modificado o excel
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_GUIA_TRANS = OUTPUTPARAM01;
        //                    oCamposDet.CODIGO_PRODUCTO = loDatos.CODIGO_PRODUCTO;
        //                    oCamposDet.NUMERO_PRODUCTO = loDatos.NUMERO_PRODUCTO;
        //                    oCamposDet.NOMBRE_PRODUCTO = loDatos.NOMBRE_PRODUCTO;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.DESCRIPCION_PRODUCTO = loDatos.DESCRIPCION_PRODUCTO;
        //                    oCamposDet.CANTIDAD_PRODUCTO = loDatos.CANTIDAD_PRODUCTO;
        //                    oCamposDet.UNIDAD_MEDIDA_PROD = loDatos.UNIDAD_MEDIDA_PROD;
        //                    oCamposDet.TOTAL_PRODUCTO = loDatos.TOTAL_PRODUCTO;
        //                    oCamposDet.OBSERVACIONES_PROD_DETALLE = loDatos.OBSERVACIONES_PROD_DETALLE;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spRGUIA_TRANSPORTE_PRODUCTOS_Grabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //Eliminando Productos
        //        if (oCEntidad.listProductoEli != null)
        //        {
        //            foreach (var loDatos in oCEntidad.listProductoEli)
        //            {
        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_GUIA_TRANS = oCEntidad.COD_GUIA_TRANS;
        //                oCamposDet.CODIGO_PRODUCTO = loDatos.CODIGO_PRODUCTO;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spRGuiaTransEliminarProducto", oCamposDet);
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

        //grabar items
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabarv3(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRGUIA_TRANSPORTEGrabarv3", oCEntidad))
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
                        if (oCEntidad.RegEstado == 99)
                        {
                            tr.Rollback();
                            tr = null;
                            return OUTPUTPARAM01;
                        }
                        else
                        {
                            tr.Rollback();
                            tr = null;
                            throw new Exception("El Nombre de la Guía  ya Existe");
                        }
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Este Control de Calidad no puede modificarse");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Registro");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Nombre de la Guía ya Existe");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_GUIA_TRANS = OUTPUTPARAM01;
                }

                if (oCEntidad.listProducto != null)
                {
                    foreach (var loDatos in oCEntidad.listProducto)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2 || loDatos.RegEstado == 99) //Nuevo o Modificado o excel
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_GUIA_TRANS = OUTPUTPARAM01;
                            oCamposDet.CODIGO_PRODUCTO = loDatos.CODIGO_PRODUCTO;
                            oCamposDet.NUMERO_PRODUCTO = loDatos.NUMERO_PRODUCTO;
                            oCamposDet.TIPO_PRODUCTO = loDatos.TIPO_PRODUCTO;
                            oCamposDet.NOMBRE_PRODUCTO = loDatos.NOMBRE_PRODUCTO;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.DESCRIPCION_PRODUCTO = loDatos.DESCRIPCION_PRODUCTO;
                            oCamposDet.CANTIDAD_PRODUCTO = loDatos.CANTIDAD_PRODUCTO;
                            oCamposDet.UNIDAD_MEDIDA_PROD = loDatos.UNIDAD_MEDIDA_PROD;
                            oCamposDet.TOTAL_PRODUCTO = loDatos.TOTAL_PRODUCTO;
                            oCamposDet.OBSERVACIONES_PROD_DETALLE = loDatos.OBSERVACIONES_PROD_DETALLE;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRGUIA_TRANSPORTE_PRODUCTOS_Grabar", oCamposDet);
                        }
                    }
                }
                //Eliminando Productos
                if (oCEntidad.listProductoEli != null)
                {
                    foreach (var loDatos in oCEntidad.listProductoEli)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_GUIA_TRANS = oCEntidad.COD_GUIA_TRANS;
                        oCamposDet.CODIGO_PRODUCTO = loDatos.CODIGO_PRODUCTO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRAcion.spRGuiaTransEliminarProducto", oCamposDet);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaItems(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRGuia_Transporte_MostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.listProducto = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_GUIA_TRANS = dr.GetString(dr.GetOrdinal("COD_GUIA_TRANSPORTE"));
                            oCampos.NUMERO_GUIA_TRANS = dr.GetString(dr.GetOrdinal("NUMERO_GUIA"));
                            oCampos.NOMBRE_GUIA_TRANS = dr.GetString(dr.GetOrdinal("NOMBRE_GUIA"));
                            oCampos.SEDE = dr.GetString(dr.GetOrdinal("SEDE_GUIA"));
                            oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                            oCampos.TITULO = dr.GetString(dr.GetOrdinal("NUMERO_THABILITANTE"));
                            oCampos.UBIGEO_TH = dr.GetString(dr.GetOrdinal("COD_UBIGEOTH"));
                            oCampos.UBIGEO_NAMETH = dr.GetString(dr.GetOrdinal("NOMBRE_UBIGEOTH"));
                            oCampos.FECHA_EXPEDICION = dr.GetString(dr.GetOrdinal("FECHA_EXPEDICION"));
                            oCampos.FECHA_VENCIMIENTO = dr.GetString(dr.GetOrdinal("FECHA_VENCIMIENTO"));
                            oCampos.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                            oCampos.COD_TITULAR = dr.GetString(dr.GetOrdinal("COD_TITULAR"));
                            oCampos.APELLIDOS_NOMBRES_TH = dr.GetString(dr.GetOrdinal("TITULAR"));
                            oCampos.DNI_TH = dr.GetString(dr.GetOrdinal("DNI_TH"));
                            oCampos.RUC_TH = dr.GetString(dr.GetOrdinal("RUC_TH"));
                            oCampos.DIRECCION_TH = dr.GetString(dr.GetOrdinal("DIRECCION_TH"));
                            oCampos.COD_PERSONAPRO = dr.GetString(dr.GetOrdinal("COD_PROPIETARIO"));
                            oCampos.APELLIDOS_NOMBRES_PRO = dr.GetString(dr.GetOrdinal("PROPIETARIO"));
                            oCampos.DNI_PRO = dr.GetString(dr.GetOrdinal("DNI_PROP"));
                            oCampos.RUC_PRO = dr.GetString(dr.GetOrdinal("RUC_PROP"));
                            oCampos.DIRECCION_PRO = dr.GetString(dr.GetOrdinal("DIRECCION_PROP"));
                            oCampos.COD_PERSONADEST = dr.GetString(dr.GetOrdinal("COD_DESTINATARIO"));
                            oCampos.APELLIDOS_NOMBRES_DES = dr.GetString(dr.GetOrdinal("DESTINATARIO"));
                            oCampos.DNI_DES = dr.GetString(dr.GetOrdinal("DNI_DEST"));
                            oCampos.RUC_DES = dr.GetString(dr.GetOrdinal("RUC_DEST"));
                            oCampos.DIRECCION_DES = dr.GetString(dr.GetOrdinal("DIRECCION_DEST"));
                            oCampos.UBIGEO_DES = dr.GetString(dr.GetOrdinal("UBIGEO_DEST"));

                            oCampos.UBIGEO_NAMEDEST = dr.GetString(dr.GetOrdinal("UBIGEO_NAME_DEST"));
                            oCampos.PROD_NATURAL = dr.GetString(dr.GetOrdinal("RECIBO_PRODNATURAL"));
                            oCampos.CANON_REFOREST = dr.GetString(dr.GetOrdinal("RECIBO_CANON"));
                            oCampos.MONTONATURAL = dr.GetDecimal(dr.GetOrdinal("MONTO_PROD"));
                            oCampos.MONTOCANON = dr.GetDecimal(dr.GetOrdinal("MONTO_CANON"));
                            oCampos.TIP_TRANS = dr.GetString(dr.GetOrdinal("TIPO_TRANS"));
                            oCampos.PLACA_VEHICULO_TRANS = dr.GetString(dr.GetOrdinal("PLACA_VEHICULO"));
                            oCampos.COD_PERSONACOND = dr.GetString(dr.GetOrdinal("COD_PERSONACONDUCTOR"));
                            oCampos.APELLIDOS_NOMBRES_COND = dr.GetString(dr.GetOrdinal("CONDUCTOR"));
                            oCampos.NUM_LICENCIA = dr.GetString(dr.GetOrdinal("LICENCIA"));
                            oCampos.OBSERVACIONES_PROD = dr.GetString(dr.GetOrdinal("OBSERVACIONES_PROD"));
                            oCampos.PESO_CARGA = dr.GetDecimal(dr.GetOrdinal("PESO_CARGA"));
                            oCampos.OBSERVACIONES_GUIA = dr.GetString(dr.GetOrdinal("OBSERVACIONES_GUIA"));
                            oCampos.COD_PERSONADESP = dr.GetString(dr.GetOrdinal("COD_PERSONADESPACHA"));
                            oCampos.APELLIDOS_NOMBRES_DESPACHADOR = dr.GetString(dr.GetOrdinal("DESPACHADOR"));
                            oCampos.COD_PERSONAAUT = dr.GetString(dr.GetOrdinal("COD_PERSONAAUTORIZA"));
                            oCampos.APELLIDOS_NOMBRES_AUTORIZA = dr.GetString(dr.GetOrdinal("AUTORIZANTE"));
                            oCampos.COD_ZATRA = dr.GetString(dr.GetOrdinal("COD_ZAFRA"));
                            oCampos.PLAN_AMAZONAS = dr.GetBoolean(dr.GetOrdinal("PLAN_AMAZONAS"));
                            oCampos.ANIO_PLAN_AMAZONAS = dr.GetString(dr.GetOrdinal("ANIO_PLAN_AMAZONAS"));

                            oCampos.ORIGEN_CONC = dr.GetBoolean(dr.GetOrdinal("ORIGEN_CONC"));
                            oCampos.ORIGEN_PERM = dr.GetBoolean(dr.GetOrdinal("ORIGEN_PERM"));
                            oCampos.ORIGEN_AUT = dr.GetBoolean(dr.GetOrdinal("ORIGEN_AUT"));
                            oCampos.ORIGEN_BL = dr.GetBoolean(dr.GetOrdinal("ORIGEN_BL"));
                            oCampos.ORIGEN_DESBLOQUE = dr.GetBoolean(dr.GetOrdinal("ORIGEN_DESBLOQUE"));
                            oCampos.ORIGEN_CAMBUSO = dr.GetBoolean(dr.GetOrdinal("ORIGEN_CAMBUSO"));
                            oCampos.ORIGEN_PLANTACION = dr.GetBoolean(dr.GetOrdinal("ORIGEN_PLANTACION"));
                            oCampos.ORIGEN_PMC = dr.GetBoolean(dr.GetOrdinal("ORIGEN_PMC"));
                            oCampos.ORIGEN_OTROS = dr.GetBoolean(dr.GetOrdinal("ORIGEN_OTROS"));
                            oCampos.DET_ORIGEN_OTROS = dr.GetString(dr.GetOrdinal("DET_ORIGEN_OTROS"));
                            oCampos.COD_PERSONARLEGAL = dr.GetString(dr.GetOrdinal("COD_PERSONARLEGAL"));
                            oCampos.REPRESENTANTE_LEGAL = dr.GetString(dr.GetOrdinal("REPRESENTANTE_LEGAL"));
                            oCampos.NUM_ARESOLUCION = dr.GetString(dr.GetOrdinal("NUM_ARESOLUCION"));
                            oCampos.PLAN_MANEJO_TIPO = dr.GetString(dr.GetOrdinal("PLAN_MANEJO_TIPO"));
                            oCampos.TIPO_COMPROBANTE = dr.GetString(dr.GetOrdinal("TIPO_COMPROBANTE"));
                            oCampos.NUM_COMPROBANTE = dr.GetString(dr.GetOrdinal("NUM_COMPROBANTE"));

                            oCampos.GTF_ARCHIVO = dr.GetString(dr.GetOrdinal("GTF_ARCHIVO"));
                            oCampos.GTF_ARCHIVO_TEXT = dr.GetString(dr.GetOrdinal("GTF_ARCHIVO_TEXT"));

                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));

                        }
                        else
                        {
                            oCampos.COD_ESTADO_DOC = "";
                            oCampos.OBSERVACIONES_CONTROL = "";
                            oCampos.OBSERV_SUBSANAR = false;
                        }
                        //CAPACITACION_DETALLE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO_PRODUCTO = dr["COD_PRODUCTO"].ToString();
                                oCamposDet.NUMERO_PRODUCTO = dr["NUMERO_PRODUCTO"].ToString();
                                oCamposDet.NOMBRE_PRODUCTO = dr["NOMBRE_COMERCIAL"].ToString();
                                oCamposDet.TIPO_PRODUCTO = dr["TIPO_PRODUCTO"].ToString();
                                oCamposDet.DESCRIPCION_PRODUCTO = dr["DESCRIPCION"].ToString();
                                oCamposDet.CANTIDAD_PRODUCTO = Decimal.Parse(dr["CANTIDAD"].ToString());
                                oCamposDet.UNIDAD_MEDIDA_PROD = dr["UNIDAD_MEDIDA"].ToString();
                                oCamposDet.TOTAL_PRODUCTO = Decimal.Parse(dr["TOTAL"].ToString());
                                oCamposDet.OBSERVACIONES_PROD_DETALLE = dr["OBSERVACIONES"].ToString();
                                oCamposDet.COD_ESPECIES = dr["COD_ESPECIE"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCampos.listProducto.Add(oCamposDet);
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
        //para traer las inexistencias
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadView> RegBuscarInexistencias(OracleConnection cn, CEntidadView oCEntidad)
        {
            List<CEntidadView> lsCEntidad = new List<CEntidadView>();
            try
            {
                using (OracleDataReader dr =dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRGuiaTransporte_PreVisualizar01", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidadView oCamposDet;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadView();
                                oCamposDet.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                oCamposDet.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                oCamposDet.MUESTRA = Int32.Parse(dr["SUPERVISADOS"].ToString());
                                oCamposDet.INEX = Int32.Parse(dr["INEXISTENTES"].ToString());
                                lsCEntidad.Add(oCamposDet);

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

        //list Preview
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadView> RegMostrarTHPreViewLista(SqlConnection cn, CEntidadView oCEntidad)
        //{
        //    List<CEntidadView> lsCEntidad = new List<CEntidadView>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRGuiaTransporte_PreVisualizar01", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadView oCampos;
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidadView();
        //                        oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
        //                        oCampos.TITULAR = dr["TITULAR"].ToString();
        //                        oCampos.PERMISO_AUTORIZACION = dr["PERMISO_AUTORIZACION"].ToString();
        //                        oCampos.REGION = dr["REGION"].ToString() + " - " + dr["PROVINCIA"].ToString() + " - " + dr["DISTRITO"].ToString();
        //                        oCampos.DEPARTAMENTO = dr["REGION"].ToString();
        //                        oCampos.PROVINCIA = dr["PROVINCIA"].ToString();
        //                        oCampos.DISTRITO = dr["DISTRITO"].ToString();
        //                        oCampos.SECTOR = dr["SECTOR"].ToString();
        //                        oCampos.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
        //                        oCampos.POA = dr["POA"].ToString();
        //                        oCampos.ZAFRA = dr["ZAFRA_PCA"].ToString();
        //                        oCampos.ARESOLUCION_NUM = dr["ARESOLUCION_NUM"].ToString();
        //                        oCampos.REFORMULA_NUM = dr["REFORMULA_NUM"].ToString(); ;
        //                        oCampos.INICIO_VIGENCIA = dr["INICIO_VIGENCIA"].ToString();
        //                        oCampos.BEXTRACCION_FEMISION = dr["BEXTRACCION_FEMISION"].ToString();
        //                        oCampos.COD_INFORME = dr["COD_INF"].ToString();
        //                        oCampos.INF_NUMERO = dr["INF_NUMERO"].ToString();
        //                        oCampos.ANIO_SUPER = dr["ANIO_SUPER"].ToString();
        //                        oCampos.FECHA_INI = dr["FECHA_INI"].ToString();
        //                        oCampos.FECHA_TERMINO = dr["FECHA_TERMINO"].ToString();
        //                        oCampos.INF_LEGAL = dr["ILEGAL"].ToString();
        //                        oCampos.DETER_INF_LEGAL = dr["DETER_ILEGAL"].ToString();
        //                        oCampos.MOTIVO_ARCHIVO = dr["MOTIVO_ARCHIVO"].ToString();

        //                        oCampos.DOC_SIADO_ARESOL = dr["DOC_SIADO_ARESOL"].ToString();
        //                        oCampos.DOC_SIADO_REFOR = dr["DOC_SIADO_REFOR"].ToString();
        //                        oCampos.DOC_SIADO_INFORME = dr["DOC_SIADO_INFORME"].ToString();
        //                        oCampos.DOC_SIADO_ILEGAL = dr["DOC_SIADO_ILEGAL"].ToString();
        //                        //14/11/2019 carr adicion de tipo informe
        //                        oCampos.TIPO_DOCUMENTO = dr["TIPO_INFORME"].ToString();
        //                        oCampos.FECHA_INFORME = dr["FECHA_INFORME"].ToString();


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

        public List<CEntidadView> RegMostrarTHPOA(OracleConnection cn, CEntidadView oCEntidad)
        {
            List<CEntidadView> lsCEntidad = new List<CEntidadView>();
            try
            {
                using (OracleDataReader dr =dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRGuiaTransporte_PreVisualizar01", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidadView oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidadView();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                oCampos.COD_RDINICIO = dr["COD_RDINICIO"].ToString();
                                oCampos.RD_INICIO_PAU = dr["RD_INI"].ToString();
                                oCampos.MEDIDAS_CAUTELARES =Convert.ToBoolean(dr["MED_CAU"]);
                                oCampos.RD_INICIO_INF_FALSA = Convert.ToBoolean(dr["INF_FALSA"]);
                                oCampos.COD_RDTERMINO = dr["COD_RDTERMINO"].ToString();
                                oCampos.RD_TERMINO_PAU = dr["RD_TER"].ToString();
                                oCampos.PAU_FIN_TIPO = dr["PAU_FIN_TIPO"].ToString();
                                oCampos.CADUCIDAD = Convert.ToBoolean(dr["CADUCIDAD"]);
                                oCampos.INFRACCIONES = dr["INFRACCIONES"].ToString();
                                oCampos.RD_RECONSIDERACION = dr["RD_RECONS"].ToString();
                                oCampos.DETER_RECONSIDERACION = dr["DETER_REC"].ToString();

                                oCampos.LEV_CADUC_RD_REC = Convert.ToBoolean(dr["LEV_CADUC_RD_REC"]);

                                oCampos.RES_TFFS = dr["RES_TFFS"].ToString();
                                oCampos.NOM_RECAPE_TFFS = dr["NOM_RECAPE_TFFS"].ToString();
                                oCampos.NOM_TIPDET_TFFS = dr["NOM_TIPDET_TFFS"].ToString();
                                oCampos.NOM_MOTDET_TFFS = dr["NOM_MOTDET_TFFS"].ToString();
                                oCampos.PROVEIDO = dr["PROVEIDO"].ToString();
                                oCampos.APELA = dr["APELA"].ToString();

                                oCampos.DOC_SIADO_INI = dr["DOC_SIADO_INI"].ToString();
                                oCampos.DOC_SIADO_TER = dr["DOC_SIADO_TER"].ToString();
                                oCampos.DOC_SIADO_REC = dr["DOC_SIADO_REC"].ToString();

                                // RD ADECUACION Y MULTA CARR 
                                oCampos.RD_ADECUACION = dr["NUMERO_RDADECUACION"].ToString();
                                oCampos.FECHA_ADECUACION = dr["FECHA_RDADECUA"].ToString();
                                oCampos.TIPO_ADECUACION = dr["TIPO_RDADECUACION"].ToString();
                                oCampos.MULTA_PAU = Decimal.Parse(dr["MONTO"].ToString());

                                lsCEntidad.Add(oCampos);
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

        //notificaciones
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadView> RegMostrarNotificaciones(OracleConnection cn, CEntidadView oCEntidad)
        {
            List<CEntidadView> lsCEntidad = new List<CEntidadView>();
            try
            {
                using (OracleDataReader dr =dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRGuiaTransporte_PreVisualizar01", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidadView oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidadView();
                                oCampos.NUMERO_NOTIFICACION = dr["NUMERO_NOTIFICACION"].ToString();
                                oCampos.FECHA_NOTIFICACION = dr["FECHA_NOTIFICACION"].ToString();
                                oCampos.TIPO_NOTIFICACION = dr["TIPO_NOTIFICACION"].ToString();
                                lsCEntidad.Add(oCampos);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidadView RegMostrarRDInicioLiterales(SqlConnection cn, CEntidadView oCEntidad)
        //{
        //    CEntidadView oCampos = new CEntidadView();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRGuiaTransporteLiteralesRDInicio", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                //CEntidadView oCampos;
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("CODIGO");
        //                    int pt1 = dr.GetOrdinal("COD_RESODIREC_INI_PAU");
        //                    int pt2 = dr.GetOrdinal("363e)");
        //                    int pt3 = dr.GetOrdinal("363f)");
        //                    int pt4 = dr.GetOrdinal("363g)");
        //                    int pt5 = dr.GetOrdinal("363i)");
        //                    int pt6 = dr.GetOrdinal("363k)");
        //                    int pt7 = dr.GetOrdinal("363l)");
        //                    int pt8 = dr.GetOrdinal("363m)");
        //                    int pt9 = dr.GetOrdinal("363n)");
        //                    int pt10 = dr.GetOrdinal("363w)");
        //                    int pt11 = dr.GetOrdinal("364f)");
        //                    int pt12 = dr.GetOrdinal("364h)");
        //                    int pt13 = dr.GetOrdinal("364l)");
        //                    int pt14 = dr.GetOrdinal("364q)");
        //                    int pt15 = dr.GetOrdinal("364s)");
        //                    int pt16 = dr.GetOrdinal("364t)");

        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidadView();
        //                        oCampos.COD_RESODIREC = dr.GetString(pt0);
        //                        oCampos.COD_RDINICIO = dr.GetString(pt1);
        //                        oCampos.sanciones = dr.GetString(pt2) + " " + dr.GetString(pt3) + " " + dr.GetString(pt4) + " " + dr.GetString(pt5) + " " + dr.GetString(pt6) + " " + dr.GetString(pt7) + " " + dr.GetString(pt8) + " " + dr.GetString(pt9) + " " + dr.GetString(pt10) + " " + dr.GetString(pt11) + " " + dr.GetString(pt12) + " " + dr.GetString(pt13) + " " + dr.GetString(pt14) + " " + dr.GetString(pt15) + " " + dr.GetString(pt16);
        //                    }

        //                }
        //            }
        //        }
        //        return oCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public List<CEntidadView> RegMostrarBExtraccion(OracleConnection cn, CEntidadView oCEntidad)
        {
            List<CEntidadView> lsCEntidad = new List<CEntidadView>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "doc_osinfor_erp_migracion.spRGuiaTransporte_PreVisualizar01", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidadView oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidadView();
                                oCampos.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                oCampos.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                oCampos.NUMERO_INDIVIDUOS = Int32.Parse(dr["TOTAL_ARBOLES"].ToString());
                                oCampos.VOLUMEN_APROBADO_RESOLUCION = Decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                oCampos.VOLUMEN_EXTRAIDO = Decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
                                oCampos.SALDO = Decimal.Parse(dr["SALDO"].ToString());
                                lsCEntidad.Add(oCampos);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadView> RegMostrarItemsSansion(OracleConnection cn, CEntidadView oCEntidad)
        {
            List<CEntidadView> lsCEntidad = new List<CEntidadView>();
            try
            {
                using (OracleDataReader dr =dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRGuiaTransporte_PreVisualizar01", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidadView oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidadView();
                                oCampos.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                oCampos.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                oCampos.VOLUMEN_APROBADO_RESOLUCION = Decimal.Parse(dr["VOL_APROB"].ToString());
                                oCampos.VOLUMEN_EXTRAIDO = Decimal.Parse(dr["VOL_MOVIL"].ToString());
                                oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                //oCampos.VOLUMEN_INI = Decimal.Parse(dr["VOL_INI"].ToString());
                                //oCampos.VOLUMEN_TER = Decimal.Parse(dr["VOL_TER"].ToString());  
                                lsCEntidad.Add(oCampos);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadView> RegMostrarNotificacionesTermino (SqlConnection cn, CEntidadView oCEntidad)
        //{
        //    List<CEntidadView> lsCEntidad = new List<CEntidadView>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRGuiaTransporteNotificacionTermino", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadView oCampos;
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_RESODIREC");
        //                    int pt1 = dr.GetOrdinal("NUMERO_NOTIFICACION");
        //                    int pt2 = dr.GetOrdinal("PERSONA_NOTIFICADA");
        //                    int pt3 = dr.GetOrdinal("FECHA_NOTIFICACION");
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidadView();
        //                        oCampos.COD_RESODIREC = dr.GetString(pt0);
        //                        oCampos.NUMERO_NOTIFICACION = dr.GetString(pt1);
        //                        oCampos.PERSONA_NOTIFICADA = dr.GetString(pt2);
        //                        oCampos.FECHA_NOTIFICACION = dr.GetString(pt3);

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
    }
}
