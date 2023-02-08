using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_PrecioEspecie;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_PrecioEspecie
    {
        private SQL oGDataSQL = new SQL();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaPrecios(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spLISTADO_PRECIO_ESPECIES_MostItems", oCEntidad))
                {
                    if (dr != null)
                    {

                        lsCEntidad.ListadoPrecioEspecies = new List<CEntidad>();
                        lsCEntidad.ListEliTABLA = new List<CEntidad>();
                        //CEntPresupSuper ocampodet;
                        CEntidad ocampoEnt;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.NOMBRE_LISTA_PRECIOS = dr.GetString(dr.GetOrdinal("NOMBRE_LISTA_PRECIOS"));
                            lsCEntidad.COD_OD = dr.GetString(dr.GetOrdinal("COD_OD"));
                            lsCEntidad.FECHA_SONDEO = dr.GetString(dr.GetOrdinal("FECHA_SONDEO"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_ENCIENTIFICO");
                            int pt1 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
                            int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt3 = dr.GetOrdinal("NOMBRE_COMUN");
                            int pt4 = dr.GetOrdinal("PRECIO");
                            int pt5 = dr.GetOrdinal("OBSERVACION");

                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_ENCIENTIFICO = dr.GetString(pt0);
                                ocampoEnt.NOM_ENCIENTIFICO = dr.GetString(pt1);
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt2);
                                ocampoEnt.NOMBRE_COMUN = dr.GetString(pt3);
                                ocampoEnt.PRECIO = dr.GetDecimal(pt4);
                                ocampoEnt.OBSERVACION = dr.GetString(pt5);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListadoPrecioEspecies.Add(ocampoEnt);
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
        public CEntidad RegMostCombo(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Combo_Listar", oCEntidad))
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
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {

                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspecies = lsDetDetalle;
                        //
                        //Oficinas Desconcentradas
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListOD = lsDetDetalle;
                    }
                }
                return oCampos;
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
        public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spLISTADO_PRECIO_ESPECIESGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Nombre del Listado ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Listado de Precios de Especies Forestales");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_LISTA_PRECIO_ESPECIE = OUTPUTPARAM01;
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_LISTA_PRECIO_ESPECIE = oCEntidad.COD_LISTA_PRECIO_ESPECIE;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.COD_ENCIENTIFICO = loDatos.COD_ENCIENTIFICO;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oGDataSQL.ManExecute(cn, tr, "DOC.spLISTADO_PRECIO_ESPECIES_EliminarDetalle", oCamposDet);
                    }
                }
                //
                //Grabando Detalle THABILITANTE_DET_TITULARES
                if (oCEntidad.ListadoPrecioEspecies != null)
                {
                    foreach (var loDatos in oCEntidad.ListadoPrecioEspecies)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_LISTA_PRECIO_ESPECIE = oCEntidad.COD_LISTA_PRECIO_ESPECIE;
                            oCamposDet.COD_ENCIENTIFICO = loDatos.COD_ENCIENTIFICO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                            oCamposDet.PRECIO = loDatos.PRECIO;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oGDataSQL.ManExecute(cn, tr, "DOC.spLISTADO_PRECIO_ESPECIES_DET_PRECIOGrabar", oCamposDet);
                        }
                    }
                }
                ///<summary>
                ///Grabando Detalle THABILITANTE_DGENERAL_ADENDA_AREA
                ///</summary>

                //
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
    }
}
