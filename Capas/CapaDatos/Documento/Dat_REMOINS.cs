using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_REMOINS;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_REMOINS
    {
        private SQL oGDataSQL = new SQL();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarREMOINS_Buscar(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            int p1 = dr.GetOrdinal("CODIGO");
                            int p2 = dr.GetOrdinal("NUMERO");
                            int p3 = dr.GetOrdinal("NUM_POA");
                            int p4 = dr.GetOrdinal("D_LINEA");
                            int p5 = dr.GetOrdinal("TITULAR");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.CODIGO = dr.GetString(p1);
                                oCampos.NUMERO = dr.GetString(p2);
                                oCampos.NUM_POA = dr.GetInt32(p3);
                                oCampos.D_LINEA = dr.GetString(p4);
                                oCampos.TITULAR = dr.GetString(p5);
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
                        //Tipo Documento
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_TIPO_DOCUMENTO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION_DOCUMENTO");


                            while (dr.Read())
                            {
                                //
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_TIPO_DOCUMENTO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION_DOCUMENTO = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoDocumento = lsDetDetalle;
                        //Entidad
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_FENTIDAD");
                            int pt2 = dr.GetOrdinal("DESCRIPCION_ENTIDAD");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_FENTIDAD = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION_ENTIDAD = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEntidad = lsDetDetalle;
                        //
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ESPECIES");
                            int pt2 = dr.GetOrdinal("DESCRIPCION_ESPECIES");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION_ESPECIES = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspecies = lsDetDetalle;
                        //Infraccion
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
                            int pt2 = dr.GetOrdinal("INFRACCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ILEGAL_ENCISOS = dr.GetString(pt1);
                                oCamposDet.INFRACCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListarInfracciones = lsDetDetalle;
                        //Sancion
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_SANCION");
                            int pt2 = dr.GetOrdinal("SANCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_SANCION = dr.GetString(pt1);
                                oCamposDet.SANCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListarSancion = lsDetDetalle;
                        //Nulidad
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_TIPO_NULIDAD");
                            int pt2 = dr.GetOrdinal("NULIDAD");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_TIPO_NULIDAD = dr.GetString(pt1);
                                oCamposDet.NULIDAD = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListarNulidad = lsDetDetalle;

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
        public String RegGrabaRegREMOINS(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            CEntidad oCamposDet;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spREMOINSGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    //     OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
                    if (OUTPUTPARAM01 == "100")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
                    }
                    else if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Doc. Remitido por otras instituciones ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Doc. Remitido por otras instituciones existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este documento remitido por otra institución");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado

                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_REMOINS = OUTPUTPARAM01;
                }
                //  Eliminando Detalle

                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_REMOINS = OUTPUTPARAM01;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oGDataSQL.ManExecute(cn, tr, "DOC.spREMOINSEliminarDetalle", oCamposDet);
                    }
                }

                //Grabando Detalle Inicio PAU 

                if (oCEntidad.TIPO == "PO")
                {

                    if (oCEntidad.ListInformes != null)
                    {
                        foreach (var loDatos in oCEntidad.ListInformes)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidad();

                                oCamposDet.COD_THABILITANTE = loDatos.CODIGO;
                                oCamposDet.NUM_POA = loDatos.NUM_POA;
                                oCamposDet.COD_REMOINS = OUTPUTPARAM01;
                                oCamposDet.RegEstado = 1;
                                oGDataSQL.ManExecute(cn, tr, "DOC.spREMOINS_DET_POA_Grabar", oCamposDet);
                            }
                        }
                    }
                }
                if (oCEntidad.TIPO == "TH")
                {

                    if (oCEntidad.ListInformes != null)
                    {
                        foreach (var loDatos in oCEntidad.ListInformes)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidad();

                                oCamposDet.COD_THABILITANTE = loDatos.CODIGO;
                                oCamposDet.COD_REMOINS = OUTPUTPARAM01;
                                oCamposDet.RegEstado = 1;
                                oGDataSQL.ManExecute(cn, tr, "DOC.spREMOINS_DET_THABILITANTE_Grabar", oCamposDet);
                            }
                        }
                    }
                }

                if (oCEntidad.Listardetbalance != null)
                {
                    foreach (var loDatos in oCEntidad.Listardetbalance)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();

                            oCamposDet.FECHA_EMISION = loDatos.FECHA_EMIBAL;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.VOLUMEN_AUTORIZADO = loDatos.VOLUMEN_AUTORIZADO;
                            oCamposDet.VOLUMEN_MOVILIZADO = loDatos.VOLUMEN_MOVILIZADO;
                            oCamposDet.SALDO = loDatos.SALDO;
                            oCamposDet.COD_REMOINS = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;
                            oGDataSQL.ManExecute(cn, tr, "DOC.spREMOINS_DET_BALANCEGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.Listardettitular != null)
                {
                    foreach (var loDatos in oCEntidad.Listardettitular)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();

                            oCamposDet.COD_ILEGAL_ENCISOS = loDatos.COD_ILEGAL_ENCISOS;
                            oCamposDet.COD_SANCION = loDatos.COD_SANCION;
                            oCamposDet.OBSERVACIONES_TITULAR = loDatos.OBSERVACIONES_TITULAR;
                            oCamposDet.COD_REMOINS = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;
                            oGDataSQL.ManExecute(cn, tr, "DOC.spREMOINS_DET_ANT_TITULARGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.Listardetresoluciones != null)
                {
                    foreach (var loDatos in oCEntidad.Listardetresoluciones)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();

                            oCamposDet.COD_FENTIDAD = loDatos.COD_FENTIDAD;
                            oCamposDet.COD_TIPO_NULIDAD = loDatos.COD_TIPO_NULIDAD;
                            oCamposDet.OBSERVACIONES_RESOLUCIONES = loDatos.OBSERVACIONES_RESOLUCIONES;
                            oCamposDet.COD_REMOINS = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;
                            oGDataSQL.ManExecute(cn, tr, "DOC.spREMOINS_DET_RESOLUCIONESGrabar", oCamposDet);
                        }
                    }
                }
                tr.Commit();
                return OUTPUTPARAM01 + '|' + OUTPUTPARAM02;
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
        public CEntidad RegMostrarListaRemoinsimItem(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spREMOINSMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformes = new List<CEntidad>();
                        lsCEntidad.Listardetbalance = new List<CEntidad>();
                        lsCEntidad.Listardettitular = new List<CEntidad>();
                        lsCEntidad.Listardetresoluciones = new List<CEntidad>();
                        CEntidad ocampoEnt;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
                            lsCEntidad.NUMERO_REMOINS = dr.GetString(dr.GetOrdinal("NUMERO_REMOINS"));
                            lsCEntidad.COD_FREMITE = dr.GetString(dr.GetOrdinal("COD_FREMITE"));
                            lsCEntidad.FREMITE = dr.GetString(dr.GetOrdinal("FREMITE"));
                            lsCEntidad.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            lsCEntidad.TIPO_FISCALIZA = dr.GetString(dr.GetOrdinal("TIPO_FISCALIZA"));
                            lsCEntidad.COD_TIPO_DOCUMENTO = dr.GetString(dr.GetOrdinal("COD_TIPO_DOCUMENTO"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                            lsCEntidad.DOCUMENTOS_ADJUNTOS = dr.GetString(dr.GetOrdinal("DOCUMENTOS_ADJUNTOS"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.SIN_INFRACCION = dr.GetBoolean(dr.GetOrdinal("SIN_INFRACCION"));
                            lsCEntidad.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
                            lsCEntidad.INSTITUCION = dr.GetString(dr.GetOrdinal("INSTITUCION"));
                            lsCEntidad.FECHA_RECEPCION = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));

                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                        }
                        else
                        {
                            lsCEntidad.COD_ESTADO_DOC = "";
                            lsCEntidad.OBSERVACIONES_CONTROL = "";
                            lsCEntidad.OBSERV_SUBSANAR = false;
                            lsCEntidad.USUARIO_CONTROL = "";
                        }
                        // Lista de Informe
                        dr.NextResult();
                        if (lsCEntidad.TIPO == "TH")
                        {
                            if (dr.HasRows)
                            {
                                int pt0 = dr.GetOrdinal("CODIGO");
                                int pt1 = dr.GetOrdinal("NUMERO");
                                int pt2 = dr.GetOrdinal("NUM_POA");
                                int pt3 = dr.GetOrdinal("D_LINEA");
                                int pt4 = dr.GetOrdinal("TITULAR");

                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidad();
                                    ocampoEnt.CODIGO = dr.GetString(pt0);
                                    ocampoEnt.NUMERO = dr.GetString(pt1);
                                    ocampoEnt.NUM_POA = dr.GetInt32(pt2);
                                    ocampoEnt.D_LINEA = dr.GetString(pt3);
                                    ocampoEnt.TITULAR = dr.GetString(pt4);
                                    ocampoEnt.RegEstado = 0;
                                    lsCEntidad.ListInformes.Add(ocampoEnt);
                                }
                            }
                        }
                        dr.NextResult();
                        if (lsCEntidad.TIPO == "PO")
                        {

                            if (dr.HasRows)
                            {
                                int pt0 = dr.GetOrdinal("CODIGO");
                                int pt1 = dr.GetOrdinal("NUMERO");
                                int pt2 = dr.GetOrdinal("NUM_POA");
                                int pt3 = dr.GetOrdinal("D_LINEA");
                                int pt4 = dr.GetOrdinal("TITULAR");

                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidad();
                                    ocampoEnt.CODIGO = dr.GetString(pt0);
                                    ocampoEnt.NUMERO = dr.GetString(pt1);
                                    ocampoEnt.NUM_POA = dr.GetInt32(pt2);
                                    ocampoEnt.D_LINEA = dr.GetString(pt3);
                                    ocampoEnt.TITULAR = dr.GetString(pt4);
                                    ocampoEnt.RegEstado = 0;
                                    lsCEntidad.ListInformes.Add(ocampoEnt);
                                }
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("FECHA_EMIBAL");
                            int pt2 = dr.GetOrdinal("COD_ESPECIES");
                            int pt3 = dr.GetOrdinal("DESCRIPCION_ESPECIES");
                            int pt4 = dr.GetOrdinal("VOLUMEN_AUTORIZADO");
                            int pt5 = dr.GetOrdinal("VOLUMEN_MOVILIZADO");
                            int pt6 = dr.GetOrdinal("SALDO");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.FECHA_EMIBAL = dr.GetString(pt1);
                                ocampoEnt.COD_ESPECIES = dr.GetString(pt2);
                                ocampoEnt.DESCRIPCION_ESPECIES = dr.GetString(pt3);
                                ocampoEnt.VOLUMEN_AUTORIZADO = dr.GetDecimal(pt4);
                                ocampoEnt.VOLUMEN_MOVILIZADO = dr.GetDecimal(pt5);
                                ocampoEnt.SALDO = dr.GetDecimal(pt6);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.Listardetbalance.Add(ocampoEnt);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
                            int pt1 = dr.GetOrdinal("INFRACCION");
                            int pt2 = dr.GetOrdinal("COD_SANCION");
                            int pt3 = dr.GetOrdinal("SANCION");
                            int pt4 = dr.GetOrdinal("OBSERVACIONES_TITULAR");
                            int pt5 = dr.GetOrdinal("COD_SECUENCIAL");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr.GetString(pt0);
                                ocampoEnt.INFRACCION = dr.GetString(pt1);
                                ocampoEnt.COD_SANCION = dr.GetString(pt2);
                                ocampoEnt.SANCION = dr.GetString(pt3);
                                ocampoEnt.OBSERVACIONES_TITULAR = dr.GetString(pt4);
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt5);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.Listardettitular.Add(ocampoEnt);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_FENTIDAD");
                            int pt1 = dr.GetOrdinal("ENTIDAD");
                            int pt2 = dr.GetOrdinal("COD_TIPO_NULIDAD");
                            int pt3 = dr.GetOrdinal("NULIDAD");
                            int pt4 = dr.GetOrdinal("OBSERVACIONES_RESOLUCIONES");
                            int pt5 = dr.GetOrdinal("COD_SECUENCIAL");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_FENTIDAD = dr.GetString(pt0);
                                ocampoEnt.ENTIDAD = dr.GetString(pt1);
                                ocampoEnt.COD_TIPO_NULIDAD = dr.GetString(pt2);
                                ocampoEnt.NULIDAD = dr.GetString(pt3);
                                ocampoEnt.OBSERVACIONES_RESOLUCIONES = dr.GetString(pt4);
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt5);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.Listardetresoluciones.Add(ocampoEnt);
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
    }
}
