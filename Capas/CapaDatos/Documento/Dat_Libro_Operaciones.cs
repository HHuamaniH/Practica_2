using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using GeneralSQL.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos.DOC
{
    public class Dat_Libro_Operaciones
    {
        private SQL oGDataSQL = new SQL();
        public long createLibroOperacioneTH(Ent_Libro_Operaciones_THabilitante ent)
        {
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
            {
                SqlTransaction tr = null;
                string OUTPUTPARAM02 = "";
                long LIBRO_OPERACIONES_TH_ID;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.uspLIBRO_OP_Cabecera_Crear", ent))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = cmd.Parameters["@OUTPUTPARAM02"].Value.ToString();
                        if (OUTPUTPARAM02 != "EXITO")
                            throw new Exception(OUTPUTPARAM02);
                        LIBRO_OPERACIONES_TH_ID = long.Parse(cmd.Parameters["@LIBRO_OPERACIONES_TH_ID"].Value.ToString());
                    }
                    tr.Commit();
                    return LIBRO_OPERACIONES_TH_ID;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
        }
        public bool createLibroOperacionesMovimientos(List<Ent_Libro_Operaciones> lstLibroOP, Ent_LIBRO_OPERACIONES_ARCHIVO libroOperacionesArchivo)
        {
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
            {
                SqlTransaction tr = null;
                string OUTPUTPARAM02 = "";
                long LIBRO_OPERACIONES_ID;
                long idArchivo = 0;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.uspLIBRO_OP_Archivo_Grabar", libroOperacionesArchivo))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = cmd.Parameters["@OUTPUTPARAM02"].Value.ToString();
                        if (OUTPUTPARAM02 != "EXITO")
                            throw new Exception(OUTPUTPARAM02);
                        idArchivo = long.Parse(cmd.Parameters["@LIBRO_OPERACIONES_ARCHIVO_ID"].Value.ToString());


                    }
                    if (idArchivo < 1) throw new Exception("Sucedio un error. No se registro correctamente el archivo");
                    foreach (var item in lstLibroOP)
                    {
                        item.LIBRO_OPERACIONES_ARCHIVO_ID = idArchivo;
                        //registrando archivo
                        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.uspLIBRO_OP_Detalle_Grabar", item))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM02 = cmd.Parameters["@OUTPUTPARAM02"].Value.ToString();
                            if (OUTPUTPARAM02 != "EXITO")
                                throw new Exception(OUTPUTPARAM02);
                            LIBRO_OPERACIONES_ID = long.Parse(cmd.Parameters["@LIBRO_OPERACIONES_ID"].Value.ToString());

                            foreach (var item1 in item.detalleMovimientos)
                            {
                                item1.LIBRO_OPERACIONES_ID = LIBRO_OPERACIONES_ID;
                                oGDataSQL.ManExecute(cn, tr, "DOC.uspLIBRO_OP_Movimientos_Grabar", item1);
                            }
                        }

                    }
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
        }
        public VM_Libro_Operaciones_THabilitante mostrarLibroOperacioneTH(long LIBRO_OPERACIONES_TH_ID)
        {
            VM_Libro_Operaciones_THabilitante vm = new VM_Libro_Operaciones_THabilitante();
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "DOC.uspLIBRO_OP_Cabecera_Mostrar", LIBRO_OPERACIONES_TH_ID))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                vm.id_Libro_Operaciones_TH = long.Parse(dr["LIBRO_OPERACIONES_TH_ID"].ToString());
                                vm.numTHabilitante = dr["NUMERO"].ToString();
                                vm.titular = dr["TITULAR_ACTUAL"].ToString();
                                vm.poa = dr["NOMBRE_POA"].ToString();
                                vm.num_poa = dr["NUM_POA"].ToString();
                                vm.resolucion = dr["ARESOLUCION_NUM"].ToString();
                                vm.modalidad = dr["MODALIDAD"].ToString();
                                vm.cod_Thabilitante = dr["COD_THABILITANTE"].ToString();
                                vm.ZAFRA_PCA = dr["ZAFRA_PCA"].ToString();
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
