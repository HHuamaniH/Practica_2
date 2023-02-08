using CapaEntidad.DOC;
using CapaEntidad.ViewModel.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IDENUNCIA_ITECNICO = CapaEntidad.DOC.IDENUNCIA_ITECNICO;
using IDENUNCIA_ITECNICO_ARCHIVOS = CapaEntidad.DOC.IDENUNCIA_ITECNICO_ARCHIVOS;
using SQL = GeneralSQL.Data.SQL;
using Tra_M_Tramite = CapaEntidad.DOC.Tra_M_Tramite;

namespace CapaDatos.DOC
{
    public class Dat_Denuncia
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        public IDENUNCIA InsertarDenunciaCabecera(OracleConnection cn, IDENUNCIA denuncia, string CodUsuario)
        {
            try
            {
                /*Insertar - Actualizar Cabecera*/
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("TIPO", denuncia.COD_IDENUNCIA.Equals("0") ? 1 : 4);
                    cm.Parameters.Add("B_DENUNCIA", denuncia.ENT_INFORME.B_DENUNCIA);
                    cm.Parameters.Add("COD_DENUNCIA", denuncia.COD_IDENUNCIA);
                    cm.Parameters.Add("ICOMPETENCIA", denuncia.ICOMPETENCIA);
                    cm.Parameters.Add("COD_INFORME", denuncia.ENT_INFORME.COD_INFORME);
                    cm.Parameters.Add("NOMBRE_DEPENDENCIA", denuncia.NOMBRE_DEPENDENCIA);
                    cm.Parameters.Add("iCodTramite", denuncia.tra_M_Tramite.iCodTramite);
                    cm.Parameters.Add("cCodCodificacion", denuncia.tra_M_Tramite.cCodificacion);
                    cm.Parameters.Add("CONCLUSION", denuncia.CONCLUSION);
                    cm.Parameters.Add("RECOMENDACION", denuncia.RECOMENDACION);
                    cm.Parameters.Add("IATENDIDO", denuncia.IATENDIDO);
                    cm.Parameters.Add("COD_UCUENTA", CodUsuario);
                    cm.Parameters.Add("FLAG_THABILITANTE", denuncia.FLAG_THABILITANTE);
                    cm.Parameters.Add("TIPO_REQUERIMIENTO", denuncia.TIPO_REQUERIMIENTO);
                    cm.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", denuncia.TIPO_REQUERIMIENTO_OTRO);
                    cm.Parameters.Add("TIPO_TRASLADO", denuncia.TIPO_TRASLADO);
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    denuncia.COD_IDENUNCIA = dr["COD_INFORME_DENUNCIA"].ToString();
                                }
                            }
                        }
                    }
                }
                /*Eliminar Detalles*/
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("TIPO", 5);
                    cm.Parameters.Add("B_DENUNCIA", null);
                    cm.Parameters.Add("COD_DENUNCIA", null);
                    cm.Parameters.Add("ICOMPETENCIA", null);
                    cm.Parameters.Add("COD_INFORME", null);
                    cm.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                    cm.Parameters.Add("iCodTramite", denuncia.tra_M_Tramite.iCodTramite);
                    cm.Parameters.Add("cCodCodificacion", null);
                    cm.Parameters.Add("CONCLUSION", null);
                    cm.Parameters.Add("RECOMENDACION", null);
                    cm.Parameters.Add("IATENDIDO", null);
                    cm.Parameters.Add("COD_UCUENTA", CodUsuario);

                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    denuncia.COD_IDENUNCIA = dr["COD_INFORME_DENUNCIA"].ToString();
                                }
                            }
                        }
                    }
                }
                /*Insertar Archivo Auditoria*/
                if (denuncia.iDENUNCIA_AUDITORIA_ARCHIVO != null)
                {
                    foreach (var auditoriaArchivo in denuncia.iDENUNCIA_AUDITORIA_ARCHIVO)
                    {
                        using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.Add("TIPO", 10);
                            cm.Parameters.Add("B_DENUNCIA", null);
                            cm.Parameters.Add("COD_DENUNCIA", denuncia.COD_IDENUNCIA);
                            cm.Parameters.Add("ICOMPETENCIA", null);
                            cm.Parameters.Add("COD_INFORME", null);
                            cm.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                            cm.Parameters.Add("iCodTramite", null);
                            cm.Parameters.Add("cCodCodificacion", null);
                            cm.Parameters.Add("CONCLUSION", null);
                            cm.Parameters.Add("RECOMENDACION", null);
                            cm.Parameters.Add("IATENDIDO", null);
                            cm.Parameters.Add("COD_UCUENTA", CodUsuario);
                            cm.Parameters.Add("FLAG_THABILITANTE", denuncia.FLAG_THABILITANTE);
                            cm.Parameters.Add("TIPO_REQUERIMIENTO", denuncia.TIPO_REQUERIMIENTO);
                            cm.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", denuncia.TIPO_REQUERIMIENTO_OTRO);
                            cm.Parameters.Add("TIPO_TRASLADO", denuncia.TIPO_TRASLADO);
                            cm.Parameters.Add("COD_IDENUNCIA_AUDITORIA_ARCHIVO", auditoriaArchivo.COD_IDENUNCIA_AUDITORIA_ARCHIVO ?? string.Empty);
                            cm.Parameters.Add("URL_TECNICO", auditoriaArchivo.URL_TECNICO);
                            cm.Parameters.Add("NOMBRE_ARCHIVO", auditoriaArchivo.NOMBRE_ARCHIVO);
                            cm.Parameters.Add("ARCHIVO_EXTENSION", auditoriaArchivo.ARCHIVO_EXTENSION);
                            using (OracleDataReader dr = cm.ExecuteReader())
                            {
                                if (dr != null)
                                {
                                    if (dr.HasRows)
                                    {
                                        while (dr.Read())
                                        {
                                            denuncia.COD_IDENUNCIA = dr["COD_INFORME_DENUNCIA"].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                /*Insertar Detalles*/
                if (denuncia.IDENUNCIA_ITECNICOS != null)
                {
                    foreach (var x in denuncia.IDENUNCIA_ITECNICOS)
                    {
                        using (OracleCommand CM = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                        {
                            CM.CommandType = CommandType.StoredProcedure;
                            CM.Parameters.Add("TIPO", 2);
                            CM.Parameters.Add("B_DENUNCIA", null);
                            CM.Parameters.Add("COD_DENUNCIA", denuncia.COD_IDENUNCIA);
                            CM.Parameters.Add("ICOMPETENCIA", null);
                            CM.Parameters.Add("COD_INFORME", null);
                            CM.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                            CM.Parameters.Add("iCodTramite", null);
                            CM.Parameters.Add("cCodCodificacion", null);
                            CM.Parameters.Add("CONCLUSION", null);
                            CM.Parameters.Add("RECOMENDACION", null);
                            CM.Parameters.Add("IATENDIDO", null);
                            CM.Parameters.Add("COD_UCUENTA", CodUsuario);
                            CM.Parameters.Add("FLAG_THABILITANTE", denuncia.FLAG_THABILITANTE);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO", denuncia.TIPO_REQUERIMIENTO);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", denuncia.TIPO_REQUERIMIENTO_OTRO);
                            CM.Parameters.Add("TIPO_TRASLADO", denuncia.TIPO_TRASLADO);
                            CM.Parameters.Add("COD_IDENUNCIA_AUDITORIA_ARCHIVO", null);
                            CM.Parameters.Add("URL_TECNICO", null);
                            CM.Parameters.Add("NOMBRE_ARCHIVO", null);
                            CM.Parameters.Add("ARCHIVO_EXTENSION", null);

                            CM.Parameters.Add("NOMBRE_INFORME", x.NOMBRE_INFORME);

                            OracleDataReader dr = CM.ExecuteReader();
                            while (dr.Read())
                            {
                                x.COD_IDENUNCIA_ITECNICO = dr["COD_INFORME_DENUNCIA"].ToString();
                                x.COD_IDENUNCIA = denuncia.COD_IDENUNCIA;
                                if (x.IDENUNCIA_ITECNICO_ARCHIVOS != null)
                                {
                                    foreach (var archivos in x.IDENUNCIA_ITECNICO_ARCHIVOS)
                                    {
                                        using (OracleCommand CM1 = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                                        {
                                            CM1.CommandType = CommandType.StoredProcedure;
                                            CM1.Parameters.Add("TIPO", 3);
                                            CM1.Parameters.Add("B_DENUNCIA", null);
                                            CM1.Parameters.Add("COD_DENUNCIA", null);
                                            CM1.Parameters.Add("ICOMPETENCIA", null);
                                            CM1.Parameters.Add("COD_INFORME", null);
                                            CM1.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                                            CM1.Parameters.Add("iCodTramite", null);
                                            CM1.Parameters.Add("cCodCodificacion", null);
                                            CM1.Parameters.Add("CONCLUSION", null);
                                            CM1.Parameters.Add("RECOMENDACION", null);
                                            CM1.Parameters.Add("IATENDIDO", null);
                                            CM1.Parameters.Add("COD_UCUENTA", CodUsuario);
                                            CM1.Parameters.Add("FLAG_THABILITANTE", denuncia.FLAG_THABILITANTE);
                                            CM1.Parameters.Add("TIPO_REQUERIMIENTO", denuncia.TIPO_REQUERIMIENTO);
                                            CM1.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", denuncia.TIPO_REQUERIMIENTO_OTRO);
                                            CM1.Parameters.Add("TIPO_TRASLADO", denuncia.TIPO_TRASLADO);
                                            CM1.Parameters.Add("COD_IDENUNCIA_AUDITORIA_ARCHIVO", null);
                                            CM1.Parameters.Add("URL_TECNICO", archivos.URL_TECNICO);
                                            CM1.Parameters.Add("NOMBRE_ARCHIVO", archivos.NOMBRE_ARCHIVO);
                                            CM1.Parameters.Add("ARCHIVO_EXTENSION", archivos.ARCHIVO_EXTENSION);
                                            CM1.Parameters.Add("NOMBRE_INFORME", x.NOMBRE_INFORME);
                                            CM.Parameters.Add("COD_INFO_HEADER", null);
                                            CM.Parameters.Add("COD_THABILITANTE", null);
                                            CM.Parameters.Add("FLAG_THABILITANTE", null);
                                            CM.Parameters.Add("TIPO_REQUERIMIENTO", null);
                                            CM.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", null);
                                            CM.Parameters.Add("TIPO_TRASLADO", null);


                                            CM1.Parameters.Add("COD_INFO_HEADER", x.COD_IDENUNCIA_ITECNICO);
                                            OracleDataReader dr1 = CM1.ExecuteReader();
                                            while (dr1.Read())
                                            {
                                                archivos.ESTADO = "1";
                                                archivos.COD_COD_IDENUNCIA_ITECNICO = x.COD_IDENUNCIA_ITECNICO;
                                                archivos.COD_IDENUNCIA_ITECNICO_ARCHIVOS = dr["COD_INFORME_DENUNCIA"].ToString();
                                            }
                                            dr1.Close();
                                        }
                                    }
                                }
                            }
                            dr.Close();
                        }
                    }
                }
                if (denuncia.iDENUNCIA_THABILITANTEs != null)
                {
                    foreach (var x in denuncia.iDENUNCIA_THABILITANTEs)
                    {
                        using (OracleCommand CM = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                        {
                            CM.CommandType = CommandType.StoredProcedure;
                            CM.Parameters.Add("TIPO", 9);
                            CM.Parameters.Add("B_DENUNCIA", null);
                            CM.Parameters.Add("COD_DENUNCIA", denuncia.COD_IDENUNCIA);
                            CM.Parameters.Add("ICOMPETENCIA", null);
                            CM.Parameters.Add("COD_INFORME", null);
                            CM.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                            CM.Parameters.Add("iCodTramite", null);
                            CM.Parameters.Add("cCodCodificacion", null);
                            CM.Parameters.Add("CONCLUSION", null);
                            CM.Parameters.Add("RECOMENDACION", null);
                            CM.Parameters.Add("IATENDIDO", null);
                            CM.Parameters.Add("COD_UCUENTA", CodUsuario);
                            CM.Parameters.Add("FLAG_THABILITANTE", denuncia.FLAG_THABILITANTE);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO", denuncia.TIPO_REQUERIMIENTO);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", denuncia.TIPO_REQUERIMIENTO_OTRO);
                            CM.Parameters.Add("TIPO_TRASLADO", denuncia.TIPO_TRASLADO);
                            CM.Parameters.Add("COD_IDENUNCIA_AUDITORIA_ARCHIVO", null);
                            CM.Parameters.Add("URL_TECNICO", null);
                            CM.Parameters.Add("NOMBRE_ARCHIVO", null);
                            CM.Parameters.Add("ARCHIVO_EXTENSION", null);
                            CM.Parameters.Add("NOMBRE_INFORME", null);
                            CM.Parameters.Add("COD_INFO_HEADER", null);

                            CM.Parameters.Add("COD_THABILITANTE", x.COD_THABILITANTE);

                            OracleDataReader dr = CM.ExecuteReader();
                            while (dr.Read())
                            {
                                denuncia.COD_IDENUNCIA = dr["COD_INFORME_DENUNCIA"].ToString();
                            }
                            dr.Close();
                        }
                    }
                }
                if (denuncia.IDENUNCIA_CARTA_OFICIO != null)
                {
                    foreach (var x in denuncia.IDENUNCIA_CARTA_OFICIO)
                    {
                        using (OracleCommand CM = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                        {
                            CM.CommandType = CommandType.StoredProcedure;
                            CM.Parameters.Add("TIPO", 11);
                            CM.Parameters.Add("B_DENUNCIA", null);
                            CM.Parameters.Add("COD_DENUNCIA", denuncia.COD_IDENUNCIA);
                            CM.Parameters.Add("ICOMPETENCIA", null);
                            CM.Parameters.Add("COD_INFORME", null);
                            CM.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                            CM.Parameters.Add("iCodTramite", null);
                            CM.Parameters.Add("cCodCodificacion", null);
                            CM.Parameters.Add("CONCLUSION", null);
                            CM.Parameters.Add("RECOMENDACION", null);
                            CM.Parameters.Add("IATENDIDO", null);
                            CM.Parameters.Add("COD_UCUENTA", CodUsuario);
                            CM.Parameters.Add("FLAG_THABILITANTE", denuncia.FLAG_THABILITANTE);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO", denuncia.TIPO_REQUERIMIENTO);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", denuncia.TIPO_REQUERIMIENTO_OTRO);
                            CM.Parameters.Add("TIPO_TRASLADO", denuncia.TIPO_TRASLADO);
                            CM.Parameters.Add("COD_IDENUNCIA_AUDITORIA_ARCHIVO", null);
                            CM.Parameters.Add("URL_TECNICO", null);
                            CM.Parameters.Add("NOMBRE_ARCHIVO", null);
                            CM.Parameters.Add("ARCHIVO_EXTENSION", null);

                            CM.Parameters.Add("NOMBRE_INFORME", x.NOMBRE_INFORME);

                            OracleDataReader dr = CM.ExecuteReader();
                            while (dr.Read())
                            {
                                x.COD_IDENUNCIA_ITECNICO = dr["COD_INFORME_DENUNCIA"].ToString();
                                x.COD_IDENUNCIA = denuncia.COD_IDENUNCIA;
                                if (x.IDENUNCIA_ITECNICO_ARCHIVOS != null)
                                {
                                    foreach (var archivos in x.IDENUNCIA_ITECNICO_ARCHIVOS)
                                    {
                                        using (OracleCommand CM1 = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                                        {
                                            CM1.CommandType = CommandType.StoredProcedure;
                                            CM1.Parameters.Add("TIPO", 3);
                                            CM1.Parameters.Add("B_DENUNCIA", null);
                                            CM1.Parameters.Add("COD_DENUNCIA", null);
                                            CM1.Parameters.Add("ICOMPETENCIA", null);
                                            CM1.Parameters.Add("COD_INFORME", null);
                                            CM1.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                                            CM1.Parameters.Add("iCodTramite", null);
                                            CM1.Parameters.Add("cCodCodificacion", null);
                                            CM1.Parameters.Add("CONCLUSION", null);
                                            CM1.Parameters.Add("RECOMENDACION", null);
                                            CM1.Parameters.Add("IATENDIDO", null);
                                            CM1.Parameters.Add("COD_UCUENTA", CodUsuario);
                                            CM1.Parameters.Add("FLAG_THABILITANTE", denuncia.FLAG_THABILITANTE);
                                            CM1.Parameters.Add("TIPO_REQUERIMIENTO", denuncia.TIPO_REQUERIMIENTO);
                                            CM1.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", denuncia.TIPO_REQUERIMIENTO_OTRO);
                                            CM1.Parameters.Add("TIPO_TRASLADO", denuncia.TIPO_TRASLADO);
                                            CM1.Parameters.Add("COD_IDENUNCIA_AUDITORIA_ARCHIVO", null);
                                            CM1.Parameters.Add("URL_TECNICO", archivos.URL_TECNICO);
                                            CM1.Parameters.Add("NOMBRE_ARCHIVO", archivos.NOMBRE_ARCHIVO);
                                            CM1.Parameters.Add("ARCHIVO_EXTENSION", archivos.ARCHIVO_EXTENSION);
                                            CM1.Parameters.Add("NOMBRE_INFORME", x.NOMBRE_INFORME);

                                            CM1.Parameters.Add("COD_INFO_HEADER", x.COD_IDENUNCIA_ITECNICO);
                                            OracleDataReader dr1 = CM1.ExecuteReader();
                                            while (dr1.Read())
                                            {
                                                archivos.ESTADO = "1";
                                                archivos.COD_COD_IDENUNCIA_ITECNICO = x.COD_IDENUNCIA_ITECNICO;
                                                archivos.COD_IDENUNCIA_ITECNICO_ARCHIVOS = dr["COD_INFORME_DENUNCIA"].ToString();
                                            }
                                            dr1.Close();
                                        }
                                    }
                                }
                            }
                            dr.Close();
                        }
                    }
                }
                if (denuncia.IDenunciaDetInformeSupervision != null)
                {
                    foreach (var x in denuncia.IDenunciaDetInformeSupervision)
                    {
                        using (OracleCommand CM = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                        {
                            CM.CommandType = CommandType.StoredProcedure;
                            CM.Parameters.Add("TIPO", 12);
                            CM.Parameters.Add("B_DENUNCIA", null);
                            CM.Parameters.Add("COD_DENUNCIA", denuncia.COD_IDENUNCIA);
                            CM.Parameters.Add("ICOMPETENCIA", null);
                            CM.Parameters.Add("COD_INFORME", x.VCODINFORME);
                            CM.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                            CM.Parameters.Add("iCodTramite", null);
                            CM.Parameters.Add("cCodCodificacion", null);
                            CM.Parameters.Add("CONCLUSION", null);
                            CM.Parameters.Add("RECOMENDACION", null);
                            CM.Parameters.Add("IATENDIDO", null);
                            CM.Parameters.Add("COD_UCUENTA", CodUsuario);
                            CM.Parameters.Add("FLAG_THABILITANTE", denuncia.FLAG_THABILITANTE);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO", denuncia.TIPO_REQUERIMIENTO);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", denuncia.TIPO_REQUERIMIENTO_OTRO);
                            CM.Parameters.Add("TIPO_TRASLADO", denuncia.TIPO_TRASLADO);
                            CM.Parameters.Add("COD_IDENUNCIA_AUDITORIA_ARCHIVO", null);
                            CM.Parameters.Add("URL_TECNICO", null);
                            CM.Parameters.Add("NOMBRE_ARCHIVO", null);
                            CM.Parameters.Add("ARCHIVO_EXTENSION", null);
                            CM.Parameters.Add("NOMBRE_INFORME", null);
                            CM.Parameters.Add("COD_INFO_HEADER", null);

                            CM.Parameters.Add("COD_THABILITANTE", null);

                            OracleDataReader dr = CM.ExecuteReader();
                            while (dr.Read())
                            {
                                denuncia.COD_IDENUNCIA = dr["COD_INFORME_DENUNCIA"].ToString();
                            }
                            dr.Close();
                        }
                    }
                }
                if (denuncia.IDenunciaDetDocumentosSITD != null)
                {
                    foreach (var x in denuncia.IDenunciaDetDocumentosSITD)
                    {
                        using (OracleCommand CM = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                        {
                            CM.CommandType = CommandType.StoredProcedure;
                            CM.Parameters.Add("TIPO", 13);
                            CM.Parameters.Add("B_DENUNCIA", null);
                            CM.Parameters.Add("COD_DENUNCIA", denuncia.COD_IDENUNCIA);
                            CM.Parameters.Add("ICOMPETENCIA", null);
                            CM.Parameters.Add("COD_INFORME", null);
                            CM.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                            CM.Parameters.Add("iCodTramite", null);
                            CM.Parameters.Add("cCodCodificacion", null);
                            CM.Parameters.Add("CONCLUSION", null);
                            CM.Parameters.Add("RECOMENDACION", null);
                            CM.Parameters.Add("IATENDIDO", null);
                            CM.Parameters.Add("COD_UCUENTA", CodUsuario);
                            CM.Parameters.Add("COD_IDENUNCIA_AUDITORIA_ARCHIVO", null);
                            CM.Parameters.Add("URL_TECNICO", null);
                            CM.Parameters.Add("NOMBRE_ARCHIVO", null);
                            CM.Parameters.Add("ARCHIVO_EXTENSION", null);
                            CM.Parameters.Add("NOMBRE_INFORME", null);
                            CM.Parameters.Add("COD_INFO_HEADER", null);
                            CM.Parameters.Add("COD_THABILITANTE", null);
                            CM.Parameters.Add("FLAG_THABILITANTE", null);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO", null);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", null);
                            CM.Parameters.Add("TIPO_TRASLADO", null);
                            CM.Parameters.Add("VCODTRAMITE", x.VCODTRAMITE);
                            CM.Parameters.Add("VCODIFICACION", x.VCODIFICACION);
                            CM.Parameters.Add("VNRODOCUMENTO", x.VNRODOCUMENTO);
                            CM.Parameters.Add("VFECDOCUMENTO", x.VFECDOCUMENTO);
                            CM.Parameters.Add("VDESCTIPODOC", x.VDESCTIPODOC);
                            CM.Parameters.Add("VASUNTO", x.VASUNTO);
                            CM.Parameters.Add("VPDF_TRAMITE_SITD", x.VPDF_TRAMITE_SITD);

                            OracleDataReader dr = CM.ExecuteReader();
                            while (dr.Read())
                            {
                                denuncia.COD_IDENUNCIA = dr["COD_INFORME_DENUNCIA"].ToString();
                            }
                            dr.Close();
                        }
                    }
                }
                if (denuncia.ENT_INFORME.ListPOAs != null)
                {
                    foreach (var x in denuncia.ENT_INFORME.ListPOAs)
                    {
                        using (OracleCommand CM = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                        {
                            CM.CommandType = CommandType.StoredProcedure;
                            CM.Parameters.Add("TIPO", 14);
                            CM.Parameters.Add("B_DENUNCIA", null);
                            CM.Parameters.Add("COD_DENUNCIA", denuncia.COD_IDENUNCIA);
                            CM.Parameters.Add("ICOMPETENCIA", null);
                            CM.Parameters.Add("COD_INFORME", x.COD_INFORME);
                            CM.Parameters.Add("NOMBRE_DEPENDENCIA", null);
                            CM.Parameters.Add("iCodTramite", null);
                            CM.Parameters.Add("cCodCodificacion", null);
                            CM.Parameters.Add("CONCLUSION", null);
                            CM.Parameters.Add("RECOMENDACION", null);
                            CM.Parameters.Add("IATENDIDO", null);
                            CM.Parameters.Add("COD_UCUENTA", CodUsuario);
                            CM.Parameters.Add("COD_IDENUNCIA_AUDITORIA_ARCHIVO", null);
                            CM.Parameters.Add("URL_TECNICO", null);
                            CM.Parameters.Add("NOMBRE_ARCHIVO", null);
                            CM.Parameters.Add("ARCHIVO_EXTENSION", null);
                            CM.Parameters.Add("NOMBRE_INFORME", null);
                            CM.Parameters.Add("COD_INFO_HEADER", null);
                            CM.Parameters.Add("COD_THABILITANTE", null);
                            CM.Parameters.Add("FLAG_THABILITANTE", null);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO", null);
                            CM.Parameters.Add("TIPO_REQUERIMIENTO_OTRO", null);
                            CM.Parameters.Add("TIPO_TRASLADO", null);
                            CM.Parameters.Add("VCODTRAMITE", null);
                            CM.Parameters.Add("VCODIFICACION", null);
                            CM.Parameters.Add("VNRODOCUMENTO", null);
                            CM.Parameters.Add("VFECDOCUMENTO", null);
                            CM.Parameters.Add("VDESCTIPODOC", null);
                            CM.Parameters.Add("VASUNTO", null);
                            CM.Parameters.Add("VPDF_TRAMITE_SITD", null);
                            CM.Parameters.Add("VPDF_TRAMITE_SITD", x.NUM_POA);
                            OracleDataReader dr = CM.ExecuteReader();
                            while (dr.Read())
                            {
                                denuncia.COD_IDENUNCIA = dr["COD_INFORME_DENUNCIA"].ToString();
                            }
                            dr.Close();
                        }
                    }
                }
            }
            catch (Exception e) { throw (e); }
            return denuncia;
        }
        public List<Ent_INFORME> ConsultarInforme(OracleConnection cn, Ent_INFORME _INFORME)
        {
            List<Ent_INFORME> listaResponse = new List<Ent_INFORME>();
            try
            {
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.BUSCAR_INFORME_DENUNCIA", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("NUMERO", _INFORME.NUMERO ?? string.Empty);
                    cm.Parameters.Add("v_pagesize", _INFORME.pagesize);
                    cm.Parameters.Add("v_currentpage", _INFORME.currentpage);
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr == null) return listaResponse;
                        if (!dr.HasRows) return listaResponse;
                        while (dr.Read())
                        {
                            listaResponse.Add(new Ent_INFORME
                            {
                                COD_INFORME = dr["COD_INFORME"].ToString(),
                                NUMERO = dr["NUMERO"].ToString(),
                                NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString(),
                                MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString(),
                                B_DENUNCIA = Int32.Parse(dr["B_DENUNCIA"].ToString()),
                                FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"].ToString(),
                                FECHA_SUPERVISION_FIN = dr["FECHA_SUPERVISION_FIN"].ToString(),
                                UBIGEO = dr["DEPARTAMENTO"].ToString(),
                                COD_MTIPO = dr["COD_MTIPO"].ToString(),
                                COD_THABILITANTE = dr["COD_THABILITANTE"].ToString(),
                                NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString(),
                                COD_ITIPO = dr["COD_ITIPO"].ToString(),
                                TITULAR = dr["TITULAR"].ToString(),
                                COD_DLINEA = dr["COD_DLINEA"].ToString(),
                                rowcount = Int32.Parse(dr["rowcount"].ToString())
                            });
                        }
                    }
                }
            }
            catch (Exception e) { throw (e); };
            return listaResponse;
        }
        public Tra_M_Tramite ConsultarTramite(OracleConnection cn, IDENUNCIA tramite)
        {
            Tra_M_Tramite data = new Tra_M_Tramite();
            try
            {
                tramite.tra_M_Tramite.iCodTupa = 1043;
                tramite.tra_M_Tramite.iCodTupaClase = 3;
                tramite.tra_M_Tramite.iCodTramite = 0;
                if (tramite.ENT_INFORME.COD_INFORME == null) tramite.ENT_INFORME = new Ent_INFORME();
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.BUSCAR_EXPEDIENTE_DENUNCIA", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("iCodTupa", tramite.tra_M_Tramite.iCodTupa);
                    cm.Parameters.Add("iCodTupaClase", tramite.tra_M_Tramite.iCodTupaClase);
                    cm.Parameters.Add("cCodificacion", tramite.tra_M_Tramite.cCodificacion);
                    cm.Parameters.Add("iCodTramite", tramite.tra_M_Tramite.iCodTramite);
                    cm.Parameters.Add("COD_INFORME", tramite.ENT_INFORME.COD_INFORME ?? string.Empty);
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr == null) return data;
                        if (!dr.HasRows) return data;
                        while (dr.Read())
                        {
                            data.iCodTramite = Int32.Parse(dr["iCodTramite"].ToString());
                            data.cNomTupa = dr["cNomTupa"].ToString();
                            data.cNomTupaClase = dr["cNomTupaClase"].ToString();
                            data.cCodificacion = dr["cCodificacion"].ToString();
                            data.fFecDocumento = dr["fFecDocumento"].ToString();
                            data.vTrabajador = dr["vTrabajador"].ToString();
                            data.cDescTipoDoc = dr["cDescTipoDoc"].ToString();
                            data.cNroDocumento = dr["cNroDocumento"].ToString();
                            data.cNombre = dr["cNombre"].ToString();
                            data.cAsunto = dr["cAsunto"].ToString();
                            data.cNombreNuevo = dr["cNombreNuevo"].ToString();
                            data.DESCARGA = dr["DESCARGA"].ToString();
                        }
                    }
                }
            }
            catch (Exception e) { throw (e); };
            return data;
        }
        public Tra_M_Tramite ConsultarTramite2(OracleConnection cn, Tra_M_Tramite tramite)
        {
            Tra_M_Tramite data = new Tra_M_Tramite();
            try
            {
                // tramite.iCodTupa = 1043;
                //tramite.iCodTupaClase = 3;
                tramite.iCodTramite = 0;
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.BUSCAR_EXPEDIENTE", tramite))
                {
                    if (dr == null) return data;
                    if (!dr.HasRows) return data;
                    while (dr.Read())
                    {
                        data.iCodTramite = Int32.Parse(dr["iCodTramite"].ToString());
                        data.cNomTupa = dr["cNomTupa"].ToString();
                        data.cNomTupaClase = dr["cNomTupaClase"].ToString();
                        data.cCodificacion = dr["cCodificacion"].ToString();
                        data.fFecDocumento = dr["fFecDocumento"].ToString();
                        data.vTrabajador = dr["vTrabajador"].ToString();
                        data.cDescTipoDoc = dr["cDescTipoDoc"].ToString();
                        data.cNroDocumento = dr["cNroDocumento"].ToString();
                        data.cNombre = dr["cNombre"].ToString();
                        data.cAsunto = dr["cAsunto"].ToString();
                        data.cNombreNuevo = dr["cNombreNuevo"].ToString();
                        data.DESCARGA = dr["DESCARGA"].ToString();
                    }
                }
            }
            catch (Exception e) { throw (e); };
            return data;
        }
        public IDENUNCIA obtenerDenuncias(OracleConnection cn, IDENUNCIA denuncia)
        {
            IDENUNCIA response = new IDENUNCIA();
            try
            {
                response = new CapaEntidad.DOC.IDENUNCIA();
                response.ENT_INFORME = new CapaEntidad.DOC.Ent_INFORME();
                response.tra_M_Tramite = new Tra_M_Tramite();
                response.DocsSITD = new Tra_M_Tramite();
                response.IDENUNCIA_ITECNICOS = new List<IDENUNCIA_ITECNICO>();
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.sp_Listar_Denuncia", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("TIPO", 1);
                    cm.Parameters.Add("iCodTramite", denuncia.tra_M_Tramite.iCodTramite);
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (dr["COD_IDENUNCIA"].ToString() != " ")
                                    {
                                        response.COD_IDENUNCIA = dr["COD_IDENUNCIA"].ToString();
                                        response.ICOMPETENCIA = Int32.Parse(dr["ICOMPETENCIA"].ToString());
                                        response.NOMBRE_DEPENDENCIA = dr["DEPENDENCIA"].ToString();
                                        response.ENT_INFORME.COD_INFORME = dr["COD_INFORME"].ToString();
                                        response.CONCLUSION = dr["CONCLUSION"].ToString();
                                        response.RECOMENDACION = dr["RECOMENDACION"].ToString();
                                        response.IATENDIDO = Int32.Parse(dr["IATENDIDO"].ToString());
                                        response.ENT_INFORME.B_DENUNCIA = Int32.Parse(dr["B_DENUNCIA"].ToString());
                                        response.ENT_INFORME.NUMERO = dr["NUMERO"].ToString();
                                        response.ENT_INFORME.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"].ToString();
                                        response.ENT_INFORME.FECHA_SUPERVISION_FIN = dr["FECHA_SUPERVISION_FIN"].ToString();
                                        response.ENT_INFORME.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
                                        response.ENT_INFORME.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                        response.ENT_INFORME.UBIGEO = dr["DEPARTAMENTO"].ToString();
                                        response.ENT_INFORME.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                        response.ENT_INFORME.COD_MTIPO = dr["COD_MODALIDAD"].ToString();
                                        response.ENT_INFORME.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                        response.ENT_INFORME.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                        response.ENT_INFORME.COD_ITIPO = dr["COD_ITIPO"].ToString();
                                        response.ENT_INFORME.TITULAR = dr["TITULAR"].ToString();
                                        response.ENT_INFORME.COD_DLINEA = dr["COD_DLINEA"].ToString();
                                        response.ENT_INFORME.COD_DLINEA = dr["D_LINEA"].ToString();
                                        response.FLAG_THABILITANTE = Int32.Parse(dr["FLAG_THABILITANTE"].ToString());
                                        response.TIPO_REQUERIMIENTO = dr["TIPO_REQUERIMIENTO"].ToString();
                                        response.TIPO_REQUERIMIENTO_OTRO = dr["TIPO_REQUERIMIENTO_OTRO"].ToString();
                                        response.TIPO_TRASLADO = dr["TIPO_TRASLADO"].ToString();
                                    }
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                response.IDENUNCIA_ITECNICOS = new List<IDENUNCIA_ITECNICO>();
                                while (dr.Read())
                                {
                                    if (dr["COD_IDENUNCIA_ITECNICO"].ToString() != " ")
                                    {
                                        IDENUNCIA_ITECNICO tecnico = new IDENUNCIA_ITECNICO();
                                        tecnico.COD_IDENUNCIA_ITECNICO = dr["COD_IDENUNCIA_ITECNICO"].ToString();
                                        tecnico.COD_IDENUNCIA = dr["COD_IDENUNCIA"].ToString();
                                        tecnico.NOMBRE_INFORME = dr["NOMBRE_INFORME"].ToString();
                                        tecnico.B_FLAG = true;
                                        response.IDENUNCIA_ITECNICOS.Add(tecnico);
                                    }
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                response.iDENUNCIA_AUDITORIA_ARCHIVO = new List<IDENUNCIA_AUDITORIA_ARCHIVO>();
                                while (dr.Read())
                                {
                                    if (dr["COD_IDENUNCIA_AUDITORIA_ARCHIVO"].ToString() != " ")
                                    {
                                        IDENUNCIA_AUDITORIA_ARCHIVO archivo = new IDENUNCIA_AUDITORIA_ARCHIVO();
                                        archivo.COD_IDENUNCIA_AUDITORIA_ARCHIVO = dr["COD_IDENUNCIA_AUDITORIA_ARCHIVO"].ToString();
                                        archivo.COD_IDENUNCIA = dr["COD_IDENUNCIA"].ToString();
                                        archivo.URL_TECNICO = dr["URL_TECNICO"].ToString();
                                        archivo.NOMBRE_ARCHIVO = dr["NOMBRE_ARCHIVO"].ToString();
                                        archivo.ARCHIVO_EXTENSION = dr["ARCHIVO_EXTENSION"].ToString();
                                        response.iDENUNCIA_AUDITORIA_ARCHIVO.Add(archivo);
                                    }
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                response.iDENUNCIA_THABILITANTEs = new List<IDENUNCIA_THABILITANTE>();
                                while (dr.Read())
                                {
                                    if (dr["COD_THABILITANTE"].ToString() != " ")
                                    {
                                        response.iDENUNCIA_THABILITANTEs.Add(new IDENUNCIA_THABILITANTE
                                        {
                                            ent_THABILITANTE = new Ent_THABILITANTE
                                            {
                                                COD_THABILITANTE = dr["COD_THABILITANTE"].ToString(),
                                                FECHA = dr["FECHA"].ToString(),
                                                MODALIDAD = dr["MODALIDAD"].ToString(),
                                                NUMERO = dr["NUMERO"].ToString(),
                                                PERSONA_TITULAR = dr["PERSONA_TITULAR"].ToString(),
                                                PERSONA_RLEGAL = dr["PERSONA_RLEGAL"].ToString()
                                            },
                                            COD_THABILITANTE = dr["COD_THABILITANTE"].ToString(),
                                            COD_IDENUNCIA = dr["COD_IDENUNCIA"].ToString()
                                        });
                                    }
                                }
                            }

                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                response.IDENUNCIA_CARTA_OFICIO = new List<IDENUNCIA_ITECNICO>();
                                while (dr.Read())
                                {
                                    if (dr["COD_IDENUNCIA_ITECNICO"].ToString() != " ")
                                    {
                                        IDENUNCIA_ITECNICO tecnico = new IDENUNCIA_ITECNICO();
                                        tecnico.COD_IDENUNCIA_ITECNICO = dr["COD_IDENUNCIA_ITECNICO"].ToString();
                                        tecnico.COD_IDENUNCIA = dr["COD_IDENUNCIA"].ToString();
                                        tecnico.NOMBRE_INFORME = dr["NOMBRE_INFORME"].ToString();
                                        tecnico.B_FLAG = true;
                                        response.IDENUNCIA_CARTA_OFICIO.Add(tecnico);
                                    }
                                }
                            }

                            // response.ENT_INFORME.COD_INFORME = dr["COD_INFORME"].ToString();
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                response.IDenunciaDetInformeSupervision = new List<IDenunciaDetInformeSupervision>();
                                while (dr.Read())
                                {
                                    if (dr["VCODINFORME"].ToString() != " ")
                                    {
                                        response.IDenunciaDetInformeSupervision.Add(new IDenunciaDetInformeSupervision
                                        {
                                            ent_INFORME = new Ent_INFORME
                                            {
                                                COD_INFORME = dr["VCODINFORME"].ToString(),
                                                NUMERO = dr["NUMERO"].ToString(),
                                                FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"].ToString(),
                                                FECHA_SUPERVISION_FIN = dr["FECHA_SUPERVISION_FIN"].ToString(),
                                                NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString(),
                                                MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString(),
                                                UBIGEO = dr["DEPARTAMENTO"].ToString()+ "||"+dr["PROVINCIA"].ToString()+"||"+ dr["DISTRITO"].ToString(),
                                                // COD_MTIPO = dr["COD_MTIPO"].ToString(),
                                                COD_MTIPO = dr["COD_MODALIDAD"].ToString(),
                                                COD_THABILITANTE = dr["COD_THABILITANTE"].ToString(),
                                                NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString(),
                                                COD_ITIPO = dr["COD_ITIPO"].ToString(),
                                                TITULAR = dr["TITULAR"].ToString(),
                                                // COD_DLINEA = dr["COD_DLINEA"].ToString(),
                                                COD_DLINEA = dr["D_LINEA"].ToString()
                                            },
                                            VCODINFORME = dr["VCODINFORME"].ToString(),
                                            VCODIDENUNCIA = dr["VCODIDENUNCIA"].ToString()
                                        });
                                    }
                                }
                            }
                            //DOCS SITD
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                response.IDenunciaDetDocumentosSITD = new List<IDenunciaDetDocumentosSITD>();
                                while (dr.Read())
                                {
                                    if (dr["VCODTRAMITE"].ToString() != " ")
                                    {
                                        response.IDenunciaDetDocumentosSITD.Add(new IDenunciaDetDocumentosSITD
                                        {
                                            VCODTRAMITE = dr["VCODTRAMITE"].ToString(),
                                            VCODIDENUNCIA = dr["VCODIDENUNCIA"].ToString(),
                                            VCODIFICACION = dr["VCODIFICACION"].ToString(),
                                            VNRODOCUMENTO = dr["VNRODOCUMENTO"].ToString(),
                                            VFECDOCUMENTO = dr["VFECDOCUMENTO"].ToString(),
                                            VDESCTIPODOC = dr["VDESCTIPODOC"].ToString(),
                                            VASUNTO = dr["VASUNTO"].ToString(),
                                            VPDF_TRAMITE_SITD = dr["VPDF_TRAMITE_SITD"].ToString()

                                        });
                                    }
                                }
                            }

                            //PAO
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                response.ENT_INFORME.ListPOAs = new List<Ent_INFORME>();
                                while (dr.Read())
                                {
                                    if (dr["COD_INFORME"].ToString() != " ")
                                    {
                                        response.ENT_INFORME.ListPOAs.Add(new Ent_INFORME
                                        {
                                            COD_THABILITANTE = dr["COD_THABILITANTE"].ToString(),
                                            NUM_POA = Int32.Parse(dr["NUM_POA"].ToString()),
                                            POA = dr["POA"].ToString(),
                                            PUBLICAR = Convert.ToBoolean(dr["PUBLICAR"]),
                                            SUPERVISADO = Convert.ToBoolean(dr["SUPERVISADO"]),
                                            B_POA = Convert.ToInt32(dr["B_POA"]),
                                            CODIGO_SEC_NOPOA = dr["CODIGO_SEC_NOPOA"].ToString(),
                                            COD_INFORME = dr["COD_INFORME"].ToString(),
                                            COD_ITIPO= dr["COD_ITIPO"].ToString(),

                                            RegEstado = 0,

                                        });
                                    }
                                }
                            }

                            response.tra_M_Tramite = ConsultarTramite2(cn, denuncia.tra_M_Tramite);
                        }
                    }
                }
                foreach (var iTecnico in response.IDENUNCIA_ITECNICOS)
                {
                    using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.sp_Listar_Denuncia", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("TIPO", 2);
                        cm.Parameters.Add("iCodTramite", 2);
                        cm.Parameters.Add("COD_ITECNICO_ARCHIVO", iTecnico.COD_IDENUNCIA_ITECNICO);
                        using (OracleDataReader dr = cm.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                iTecnico.IDENUNCIA_ITECNICO_ARCHIVOS = new List<IDENUNCIA_ITECNICO_ARCHIVOS>();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        if (dr["COD_IDENUNCIA_ITECNICO_ARCHIVOS"].ToString() != " ")
                                        {
                                            IDENUNCIA_ITECNICO_ARCHIVOS archivos = new IDENUNCIA_ITECNICO_ARCHIVOS();
                                            archivos.COD_IDENUNCIA_ITECNICO_ARCHIVOS = dr["COD_IDENUNCIA_ITECNICO_ARCHIVOS"].ToString();
                                            archivos.COD_COD_IDENUNCIA_ITECNICO = dr["COD_COD_IDENUNCIA_ITECNICO"].ToString();
                                            archivos.URL_TECNICO = dr["URL_TECNICO"].ToString();
                                            archivos.ARCHIVO_EXTENSION = dr["ARCHIVO_EXTENSION"].ToString();
                                            archivos.NOMBRE_ARCHIVO = dr["NOMBRE_ARCHIVO"].ToString();
                                            archivos.ESTADO = dr["ESTADO"].ToString();
                                            iTecnico.IDENUNCIA_ITECNICO_ARCHIVOS.Add(archivos);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (var iTecnico in response.IDENUNCIA_CARTA_OFICIO)
                {
                    using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.sp_Listar_Denuncia", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("TIPO", 2);
                        cm.Parameters.Add("iCodTramite", 2);
                        cm.Parameters.Add("COD_ITECNICO_ARCHIVO", iTecnico.COD_IDENUNCIA_ITECNICO);
                        using (OracleDataReader dr = cm.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                iTecnico.IDENUNCIA_ITECNICO_ARCHIVOS = new List<IDENUNCIA_ITECNICO_ARCHIVOS>();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        if (dr["COD_IDENUNCIA_ITECNICO_ARCHIVOS"].ToString() != " ")
                                        {
                                            IDENUNCIA_ITECNICO_ARCHIVOS archivos = new IDENUNCIA_ITECNICO_ARCHIVOS();
                                            archivos.COD_IDENUNCIA_ITECNICO_ARCHIVOS = dr["COD_IDENUNCIA_ITECNICO_ARCHIVOS"].ToString();
                                            archivos.COD_COD_IDENUNCIA_ITECNICO = dr["COD_COD_IDENUNCIA_ITECNICO"].ToString();
                                            archivos.URL_TECNICO = dr["URL_TECNICO"].ToString();
                                            archivos.ARCHIVO_EXTENSION = dr["ARCHIVO_EXTENSION"].ToString();
                                            archivos.NOMBRE_ARCHIVO = dr["NOMBRE_ARCHIVO"].ToString();
                                            archivos.ESTADO = dr["ESTADO"].ToString();
                                            iTecnico.IDENUNCIA_ITECNICO_ARCHIVOS.Add(archivos);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (var info in response.IDenunciaDetInformeSupervision)
                {
                    using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.sp_Listar_Denuncia", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("TIPO", 3);
                        cm.Parameters.Add("iCodTramite", null);
                        cm.Parameters.Add("COD_ITECNICO_ARCHIVO", null);
                        cm.Parameters.Add("COD_INFORME", info.ent_INFORME.COD_INFORME);
                        using (OracleDataReader dr = cm.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                Ent_INFORME ocampoEnt;
                                info.ent_INFORME.ListPOAs = new List<Ent_INFORME>();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        if (dr["COD_THABILITANTE"].ToString() != " ")
                                        {
                                            ocampoEnt = new Ent_INFORME();
                                            ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                            ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                            ocampoEnt.POA = dr["POA"].ToString();
                                            ocampoEnt.PUBLICAR = Convert.ToBoolean(dr["PUBLICAR"]);
                                            ocampoEnt.SUPERVISADO = Convert.ToBoolean(dr["SUPERVISADO"]);
                                            ocampoEnt.B_POA = Convert.ToInt32(dr["B_POA"]);
                                            ocampoEnt.CODIGO_SEC_NOPOA = dr["CODIGO_SEC_NOPOA"].ToString();
                                            ocampoEnt.RegEstado = 0;
                                            info.ent_INFORME.ListPOAs.Add(ocampoEnt);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e) { throw (e); }
            return response;
        }
        public IDENUNCIA obtenerPoaPorInformeSupervision(OracleConnection cn, IDENUNCIA denuncia)
        {
            IDENUNCIA response = new IDENUNCIA();
            try
            {
                response = new CapaEntidad.DOC.IDENUNCIA();
                response.ENT_INFORME = new CapaEntidad.DOC.Ent_INFORME();
                response.IDENUNCIA_ITECNICOS = new List<IDENUNCIA_ITECNICO>();
                foreach (var info in denuncia.IDenunciaDetInformeSupervision)
                {
                    using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.sp_Listar_Denuncia", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("TIPO", 3);
                        cm.Parameters.Add("iCodTramite", null);
                        cm.Parameters.Add("COD_ITECNICO_ARCHIVO", null);
                        cm.Parameters.Add("COD_INFORME", info.ent_INFORME.COD_INFORME);
                        using (OracleDataReader dr = cm.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                Ent_INFORME ocampoEnt;
                                info.ent_INFORME.ListPOAs = new List<Ent_INFORME>();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        if (dr["COD_THABILITANTE"].ToString() != " ")
                                        {
                                            ocampoEnt = new Ent_INFORME();
                                            ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                            ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                            ocampoEnt.POA = dr["POA"].ToString();
                                            ocampoEnt.PUBLICAR = Convert.ToBoolean(dr["PUBLICAR"]);
                                            ocampoEnt.SUPERVISADO = Convert.ToBoolean(dr["SUPERVISADO"]);
                                            ocampoEnt.B_POA = Convert.ToInt32(dr["B_POA"]);
                                            ocampoEnt.CODIGO_SEC_NOPOA = dr["CODIGO_SEC_NOPOA"].ToString();
                                            ocampoEnt.RegEstado = 0;
                                            info.ent_INFORME.ListPOAs.Add(ocampoEnt);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e) { throw (e); }
            return denuncia;
        }
        public List<IINCIDENCIA> crudIncidencias(OracleConnection cn, IINCIDENCIA Obj)
        {
            List<IINCIDENCIA> listado = new List<IINCIDENCIA>();
            string hora_minuto_segundo;
            DateTime fechaActual = DateTime.Now;
            try
            {
                using (OracleCommand CM = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.SP_CRUD_IINCIDENCIA", cn))
                {
                    CM.CommandType = CommandType.StoredProcedure;
                    CM.Parameters.Add("TIPO", Obj.ITipo);
                    CM.Parameters.Add("COD_IINCIDENCIA", Obj.COD_IINCIDENCIA);
                    CM.Parameters.Add("COD_INFORME", Obj.COD_INFORME);
                    CM.Parameters.Add("FECHA_SUCESO", Convert.ToDateTime(Obj.FECHA_SUCESO));
                    if (Obj.HORA_SUCESO != null)
                    {
                        hora_minuto_segundo = Obj.HORA_SUCESO;
                        TimeSpan ts;
                        try
                        {
                            ts = new TimeSpan(Convert.ToInt32(hora_minuto_segundo.Split(':')[0]), Convert.ToInt32(hora_minuto_segundo.Split(':')[1]), 0);
                        }
                        catch (Exception)
                        {

                            throw new Exception("Ingrese formato correcto en HH:MM:SS");
                        }

                        CM.Parameters.Add("HORA_SUCESO", fechaActual.Date + ts);
                    }
                    else
                    {
                        CM.Parameters.Add("HORA_SUCESO", Obj.HORA_SUCESO);
                    }

                    CM.Parameters.Add("RIESGO", Obj.COD_IINCIDENCIA_PROTOCOLOS_RIESGO);
                    CM.Parameters.Add("PROCESO", Obj.COD_IINCIDENCIA_PROTOCOLOS_PROCESO);
                    CM.Parameters.Add("CIRCUNSTANCIA", Obj.COD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA);
                    CM.Parameters.Add("UBICACION", Obj.UBICACION);
                    CM.Parameters.Add("EFECTO", Obj.COD_IINCIDENCIA_PROTOCOLOS_EFECTO);
                    CM.Parameters.Add("NIVEL_1", Obj.COD_IINCIDENCIA_PROTOCOLOS_NIVEL_1);
                    CM.Parameters.Add("NIVEL_2", Obj.COD_IINCIDENCIA_PROTOCOLOS_NIVEL_2);
                    CM.Parameters.Add("DSCRP_INCIDENCIA", Obj.DSCRP_INCIDENCIA);
                    CM.Parameters.Add("OBSERVACIONES", Obj.OBSERVACIONES);
                    CM.Parameters.Add("v_currentpage", Obj.CurrentPage);
                    CM.Parameters.Add("v_pagesize", Obj.PageSize);
                    using (OracleDataReader dr = CM.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (Obj.ITipo == 4 || Obj.ITipo == 5)
                                    {
                                        IINCIDENCIA_PROTOCOLOS RIESGO = new IINCIDENCIA_PROTOCOLOS();
                                        RIESGO.COD_IINCIDENCIA_PROTOCOLOS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_IINCIDENCIA_PROTOCOLOS_RIESGO")));
                                        RIESGO.NOMBRE_PROTOCOLO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("RIESGO")));
                                        IINCIDENCIA_PROTOCOLOS PROCESO = new IINCIDENCIA_PROTOCOLOS();
                                        PROCESO.COD_IINCIDENCIA_PROTOCOLOS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_IINCIDENCIA_PROTOCOLOS_PROCESO")));
                                        PROCESO.NOMBRE_PROTOCOLO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("PROCESO")));
                                        IINCIDENCIA_PROTOCOLOS CIRCUNSTANCIA = new IINCIDENCIA_PROTOCOLOS();
                                        CIRCUNSTANCIA.COD_IINCIDENCIA_PROTOCOLOS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA")));
                                        CIRCUNSTANCIA.NOMBRE_PROTOCOLO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("CIRCUNSTANCIA")));
                                        IINCIDENCIA_PROTOCOLOS EFECTO = new IINCIDENCIA_PROTOCOLOS();
                                        EFECTO.COD_IINCIDENCIA_PROTOCOLOS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_IINCIDENCIA_PROTOCOLOS_EFECTO")));
                                        EFECTO.NOMBRE_PROTOCOLO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("EFECTO")));
                                        IINCIDENCIA_PROTOCOLOS NIVEL_1 = new IINCIDENCIA_PROTOCOLOS();
                                        NIVEL_1.COD_IINCIDENCIA_PROTOCOLOS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_IINCIDENCIA_PROTOCOLOS_NIVEL_1")));
                                        NIVEL_1.NOMBRE_PROTOCOLO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("NIVEL_1")));
                                        IINCIDENCIA_PROTOCOLOS NIVEL_2 = new IINCIDENCIA_PROTOCOLOS();
                                        NIVEL_2.COD_IINCIDENCIA_PROTOCOLOS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_IINCIDENCIA_PROTOCOLOS_NIVEL_2")));
                                        NIVEL_2.NOMBRE_PROTOCOLO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("NIVEL_2")));
                                        IINCIDENCIA iINCIDENCIA = new IINCIDENCIA();
                                        iINCIDENCIA.COD_IINCIDENCIA = dr["COD_IINCIDENCIA"].ToString();
                                        iINCIDENCIA.COD_INFORME = dr["COD_INFORME"].ToString();
                                        iINCIDENCIA.FECHA_SUCESO = dr["FECHA_SUCESO"] == DBNull.Value ? "" : Convert.ToDateTime(dr["FECHA_SUCESO"]).ToShortDateString();

                                        iINCIDENCIA.HORA_SUCESO = dr["HORA_SUCESO"].ToString().Substring(0, 5);
                                        iINCIDENCIA.OBJCOD_IINCIDENCIA_PROTOCOLOS_RIESGO = RIESGO;
                                        iINCIDENCIA.OBJCOD_IINCIDENCIA_PROTOCOLOS_PROCESO = PROCESO;
                                        iINCIDENCIA.OBJCOD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA = CIRCUNSTANCIA;
                                        iINCIDENCIA.UBICACION = dr["UBICACION"].ToString();
                                        iINCIDENCIA.OBJCOD_IINCIDENCIA_PROTOCOLOS_EFECTO = EFECTO;
                                        iINCIDENCIA.OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_1 = NIVEL_1;
                                        iINCIDENCIA.OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_2 = NIVEL_2;
                                        iINCIDENCIA.DSCRP_INCIDENCIA = dr["DSCRP_INCIDENCIA"].ToString();
                                        iINCIDENCIA.OBSERVACIONES = dr["OBSERVACIONES"].ToString();
                                        iINCIDENCIA.rowCount = Convert.ToInt32(dr["rowCount"].ToString());
                                        listado.Add(iINCIDENCIA);
                                    }
                                    else
                                    {
                                        Obj.COD_IINCIDENCIA = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_IINCIDENCIA")));
                                        listado.Add(Obj);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return listado;
        }
        public List<IDENUNCIA> exportarDenuncias(OracleConnection cn)
        {
            List<IDENUNCIA> listado = new List<IDENUNCIA>();
            try
            {
                using (OracleCommand CM = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.sp_Listar_Denuncia_Excel", cn))
                {
                    CM.CommandType = CommandType.StoredProcedure;
                    using (OracleDataReader dr = CM.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    listado.Add(new IDENUNCIA
                                    {
                                        ENT_INFORME = new Ent_INFORME
                                        {
                                            NUMERO = dr["NUMERO"].ToString()
                                        },
                                        tra_M_Tramite = new Tra_M_Tramite
                                        {
                                            iCodTramite = Convert.ToInt32(dr["iCodTramite"].ToString()),
                                            cNomTupa = dr["cNomTupa"].ToString(),
                                            cNomTupaClase = dr["cNomTupaClase"].ToString(),
                                            cCodificacion = dr["cCodificacion"].ToString(),
                                            fFecDocumento = dr["fecha"].ToString(),
                                            vTrabajador = dr["vTrabajador"].ToString(),
                                            cDescTipoDoc = dr["cDescTipoDoc"].ToString(),
                                            cNroDocumento = dr["cNroDocumento"].ToString(),
                                            cNombre = dr["cNombre"].ToString(),
                                            cAsunto = dr["cAsunto"].ToString(),
                                            cNombreNuevo = dr["cNombreNuevo"].ToString()
                                        },
                                        DEPENDENCIA = dr["DEPENDENCIA"].ToString(),
                                        NOMBRE_DEPENDENCIA = dr["NOMBRE_DEPENDENCIA"].ToString(),
                                        iAnio = Convert.ToInt32(dr["iANIO"].ToString()),
                                        Informes = dr["Informes"].ToString(),
                                        Auditoria = dr["Auditoria"].ToString(),
                                        THabilitante = dr["THabilitante"].ToString(),
                                        TIPO_REQUERIMIENTO= dr["TIPO_REQUERIMIENTO"].ToString(),
                                        TIPO_REQUERIMIENTO_OTRO = dr["TIPO_REQUERIMIENTO_OTRO"].ToString(),
                                        TIPO_TRASLADO = dr["TIPO_TRASLADO"].ToString(),
                                        FLAG_THABILITANTE =int.Parse( dr["FLAG_THABILITANTE"].ToString())
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return listado;
        }
        public List<Dictionary<string, string>> exportarDenunciasGrl(OracleConnection cn)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.sp_Listar_Denuncia_Excel",null))
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
        public IDENUNCIA insertarTramiteDenuncia(OracleConnection cn, IDENUNCIA denuncia)
        {
            try
            {
                denuncia.tra_M_Tramite = (denuncia.tra_M_Tramite == null ? new Tra_M_Tramite() : denuncia.tra_M_Tramite);
                if (denuncia.tra_M_Tramite.cCodificacion != null) denuncia.tra_M_Tramite.cCodificacion.Trim();
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.spINSERTAR_DENUNCIA", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("TIPO", 7);
                    cm.Parameters.Add("B_DENUNCIA", null);
                    cm.Parameters.Add("COD_DENUNCIA", denuncia.COD_IDENUNCIA ?? string.Empty);
                    cm.Parameters.Add("ICOMPETENCIA", null);
                    cm.Parameters.Add("COD_INFORME", denuncia.ENT_INFORME.COD_INFORME);
                    cm.Parameters.Add("NOMBRE_DEPENDENCIA", denuncia.ENT_INFORME.COD_INFORME);
                    cm.Parameters.Add("iCodTramite", denuncia.tra_M_Tramite.iCodTramite);
                    cm.Parameters.Add("cCodCodificacion", denuncia.tra_M_Tramite.cCodificacion);
                    cm.Parameters.Add("CONCLUSION", null);
                    cm.Parameters.Add("RECOMENDACION", null);
                    cm.Parameters.Add("IATENDIDO", denuncia.IATENDIDO);
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    denuncia.COD_IDENUNCIA = dBOracle.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_INFORME_DENUNCIA")));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return denuncia;
        }
        public IDENUNCIA obtenerDenunciaxInforme(OracleConnection cn, IDENUNCIA denuncia)
        {
            try
            {
                denuncia.tra_M_Tramite = new Tra_M_Tramite();
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.USP_DENUNCIA_LISTAR", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("TIPO", 8);
                    cm.Parameters.Add("COD_INFORME", denuncia.ENT_INFORME.COD_INFORME);
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    denuncia.COD_IDENUNCIA = dr["COD_IDENUNCIA"].ToString();
                                    denuncia.IATENDIDO = Convert.ToInt32(dr["IATENDIDO"]);
                                    denuncia.ICOMPETENCIA = Convert.ToInt32(dr["ICOMPETENCIA"]);
                                    denuncia.ENT_INFORME.COD_INFORME = dr["COD_INFORME"].ToString();
                                    denuncia.CONCLUSION = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("CONCLUSION")));
                                    denuncia.RECOMENDACION = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("RECOMENDACION")));
                                    denuncia.tra_M_Tramite.iCodTramite = Convert.ToInt32(dr["iCodTramite"]);
                                    denuncia.tra_M_Tramite.cCodificacion = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cCodificacion")));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return denuncia;
        }
        public List<IINCIDENCIA_PROTOCOLOS> listarProtocolos(OracleConnection cn, IINCIDENCIA_PROTOCOLOS denuncia)
        {
            List<IINCIDENCIA_PROTOCOLOS> listad = new List<IINCIDENCIA_PROTOCOLOS>();
            try
            {
                if (denuncia.OBJPROTOCOLO_PADRE == null) denuncia.OBJPROTOCOLO_PADRE = new IINCIDENCIA_PROTOCOLOS();
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.SP_LISTAR_PROTOCOLOS", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.Parameters.AddWithValue("@TIPO", 1);
                    //cm.Parameters.AddWithValue("@NOMBRE_BUSCAR", denuncia.iINCIDENCIA_TIPO_PROTOCOLO.NOMBRE_TIPO_PROTOCOLO);
                    //cm.Parameters.AddWithValue("@PROTOCOLO_PADRE", denuncia.OBJPROTOCOLO_PADRE.COD_IINCIDENCIA_PROTOCOLOS ?? string.Empty);
                    cm.Parameters.Add("TIPO", 1);
                    cm.Parameters.Add("NOMBRE_BUSCAR", denuncia.iINCIDENCIA_TIPO_PROTOCOLO.NOMBRE_TIPO_PROTOCOLO);
                    cm.Parameters.Add("PROTOCOLO_PADRE", denuncia.OBJPROTOCOLO_PADRE.COD_IINCIDENCIA_PROTOCOLOS ?? string.Empty);

                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    IINCIDENCIA_TIPO_PROTOCOLO d = new IINCIDENCIA_TIPO_PROTOCOLO();
                                    d.NOMBRE_TIPO_PROTOCOLO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("NOMBRE_TIPO_PROTOCOLO")));
                                    IINCIDENCIA_PROTOCOLOS data = new IINCIDENCIA_PROTOCOLOS();
                                    data.COD_IINCIDENCIA_PROTOCOLOS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_IINCIDENCIA_PROTOCOLOS")));
                                    data.NOMBRE_PROTOCOLO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("NOMBRE_PROTOCOLO")));
                                    data.SECCION = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("SECCION")));
                                    data.iINCIDENCIA_TIPO_PROTOCOLO = d;
                                    listad.Add(data);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return listad;
        }
        //public Tra_M_Tramite cambioEtadoTramite(SqlConnection cn, Tra_M_Tramite tramite)
        //{
        //    try
        //    {
        //        using (SqlCommand cm = new SqlCommand("DOC.ESTADO_EXPEDIENTE_MC", cn))
        //        {
        //            cm.CommandType = CommandType.StoredProcedure;
        //            cm.Parameters.AddWithValue("@iCodTramite", tramite.iCodTramite);
        //            cm.Parameters.AddWithValue("@USUARIO", tramite.USUARIO);
        //            cm.Parameters.AddWithValue("@iEstado", tramite.iEstado);
        //            using (SqlDataReader dr = cm.ExecuteReader())
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        while (dr.Read())
        //                        {
        //                            tramite.COD_EXPEDIENTE = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("cod_expediente")));
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e) { throw (e); };
        //    return tramite;
        //}
        //public Tra_M_Tramite guardarTramite(SqlConnection cn, Tra_M_Tramite tramite)
        //{
        //    try
        //    {
        //        if (tramite.ADJMANDATO == null) tramite.ADJMANDATO = new IMANDATO_SUPERVISION_ARCHIVOS();
        //        using (SqlCommand cm = new SqlCommand("DOC.INSERTA_EXPEDIENTE_MC", cn))
        //        {
        //            cm.CommandType = CommandType.StoredProcedure;
        //            cm.Parameters.AddWithValue("@COD_RESODIREC", tramite.COD_RESODIREC);
        //            cm.Parameters.AddWithValue("@iCodTramite", tramite.iCodTramite);
        //            cm.Parameters.AddWithValue("@USUARIO", tramite.USUARIO);
        //            cm.Parameters.AddWithValue("@iTipo", tramite.iTipo);
        //            cm.Parameters.AddWithValue("@iEstado", tramite.iEstado);
        //            cm.Parameters.AddWithValue("@PLAZO_DIA", tramite.PLAZO_DIA);
        //            cm.Parameters.AddWithValue("@PLAZO_MES", tramite.PLAZO_MES);
        //            cm.Parameters.AddWithValue("@iCodMandato", tramite.iCodMandato);
        //            cm.Parameters.AddWithValue("@URLDIGITAL", tramite.ADJMANDATO.URLDIGITAL);
        //            cm.Parameters.AddWithValue("@URLNOMBRE", tramite.ADJMANDATO.URLNOMBRE);
        //            cm.Parameters.AddWithValue("@ARCHIVO_EXTENSION", tramite.ADJMANDATO.ARCHIVO_EXTENSION);

        //            using (SqlDataReader dr = cm.ExecuteReader())
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        while (dr.Read())
        //                        {
        //                            tramite.COD_EXPEDIENTE = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("cod_expediente")));
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e) { throw (e); };
        //    return tramite;
        //}
        //public Tra_M_Tramite ConsultarTramiteMandatos(SqlConnection cn, Tra_M_Tramite tramite)
        //{
        //    Tra_M_Tramite data = new Tra_M_Tramite();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.BUSCAR_EXPEDIENTE", tramite))
        //        {
        //            if (dr == null) return data;
        //            if (!dr.HasRows) return data;
        //            while (dr.Read())
        //            {
        //                data.iCodTramite = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("iCodTramite")));
        //                data.cNomTupa = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cNomTupa")));
        //                data.cNomTupaClase = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cNomTupaClase")));
        //                data.cCodificacion = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cCodificacion")));
        //                data.fFecDocumento = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("fFecDocumento")));
        //                data.vTrabajador = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("vTrabajador")));
        //                data.cDescTipoDoc = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cDescTipoDoc")));
        //                data.cNroDocumento = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cNroDocumento")));
        //                data.cNombre = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cNombre")));
        //                data.cAsunto = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cAsunto")));
        //            }
        //        }
        //    }
        //    catch (Exception e) { throw (e); };
        //    return data;
        //}
        public List<IINCIDENCIA> consultaGenerica(OracleConnection cn)
        {
            List<IINCIDENCIA> listado = new List<IINCIDENCIA>();
            try
            {
                using (OracleCommand CM = new OracleCommand("[DOC_OSINFOR_ERP_MIGRACION].[SP_CRUD_IINCIDENCIA]", cn))
                {
                    CM.CommandType = CommandType.StoredProcedure;
                    CM.Parameters.Add("@TIPO", 6);
                    using (OracleDataReader dr = CM.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Dictionary<string, string> sFila;
                                    string sColumn = string.Empty;
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return listado;
        }
        public List<IDENUNCIA_THABILITANTE> ConsultarTHabilitante(OracleConnection cn, IDENUNCIA_THABILITANTE iDENUNCIA_THABILITANTE)
        {
            List<IDENUNCIA_THABILITANTE> listaResponse = new List<IDENUNCIA_THABILITANTE>();
            try
            {
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.BUSCAR_THABILITANTE", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("THabilitante", iDENUNCIA_THABILITANTE.ent_THABILITANTE.NUMERO ?? string.Empty);
                    cm.Parameters.Add("v_pagesize", iDENUNCIA_THABILITANTE.PageSize);
                    cm.Parameters.Add("v_currentpage", iDENUNCIA_THABILITANTE.CurrentPage);
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr == null) return listaResponse;
                        if (!dr.HasRows) return listaResponse;
                        while (dr.Read())
                        {
                            listaResponse.Add(new IDENUNCIA_THABILITANTE
                            {
                                ent_THABILITANTE = new Ent_THABILITANTE
                                {
                                    COD_THABILITANTE = dr["COD_THABILITANTE"].ToString(),
                                    FECHA = dr["FECHA"].ToString(),
                                    MODALIDAD = dr["MODALIDAD"].ToString(),
                                    NUMERO = dr["NUMERO"].ToString(),
                                    PERSONA_TITULAR = dr["PERSONA_TITULAR"].ToString(),
                                    PERSONA_RLEGAL = dr["PERSONA_RLEGAL"].ToString()
                                },
                                COD_THABILITANTE = dr["COD_THABILITANTE"].ToString(),
                                rowCount = Int32.Parse(dr["rowCount"].ToString())
                            });
                        }
                    }
                }
            }
            catch (Exception e) { throw (e); };
            return listaResponse;
        }
        //public VW_REPORTE_INFORME_SUPERVISION InformeDeSupervision(SqlConnection cn)
        //{
        //    VW_REPORTE_INFORME_SUPERVISION vw = new VW_REPORTE_INFORME_SUPERVISION();
        //    vw.listadoitems = new List<VM_FControlCalidadSupervision_Det>();
        //    vw.listadoFechas = new List<VM_FControlCalidadSupervision_Det>();
        //    vw.iNFORME_CONTROL_CALIDADs = new List<INFORME_CONTROL_CALIDAD>();
        //    vw.respuestasLista = new List<INFORME_CONTROL_CALIDAD>();
        //    try
        //    {
        //        using (SqlCommand cm = new SqlCommand("DOC.SP_LISTAR_SOBRE_INFORME_SUPERVISION", cn))
        //        {
        //            cm.CommandType = CommandType.StoredProcedure;
        //            using (SqlDataReader dr = cm.ExecuteReader())
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        while (dr.Read())
        //                        {
        //                            vw.listadoitems.Add(new VM_FControlCalidadSupervision_Det
        //                            {
        //                                padre = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("PADRE"))),
        //                                ORDEN_PADRE = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("ORDEN_PADRE"))),
        //                                hijo = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("HIJO"))),
        //                                id = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("MAESTRO_FORMATO_ID"))),
        //                                codigo = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("CODIGO")))
        //                            });
        //                        }
        //                    }
        //                    dr.NextResult();
        //                    if (dr.HasRows)
        //                    {
        //                        while (dr.Read())
        //                        {
        //                            vw.listadoFechas.Add(new VM_FControlCalidadSupervision_Det
        //                            {
        //                                padre = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("PADRE"))),
        //                                ORDEN_PADRE = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("ORDEN_PADRE"))),
        //                                id = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("MAESTRO_FORMATO_ID")))
        //                            });
        //                        }
        //                    }
        //                    dr.NextResult();
        //                    if (dr.HasRows)
        //                    {
        //                        while (dr.Read())
        //                        {
        //                            vw.iNFORME_CONTROL_CALIDADs.Add(new INFORME_CONTROL_CALIDAD
        //                            {
        //                                Ent_Informe = new Ent_INFORME
        //                                {
        //                                    COD_INFORME = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_INFORME"))),
        //                                    NUMERO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("NUMERO"))),
        //                                    MODALIDAD_TIPO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("MODALIDAD_TIPO"))),
        //                                    NUM_THABILITANTE = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("NUM_THABILITANTE"))),
        //                                    TITULAR = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("TITULAR"))),
        //                                    USUARIO_REGISTRO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("USUARIO_REGISTRO"))),
        //                                    SUPERVISOR = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("SUPERVISORES"))),
        //                                    COD_OD_REGISTRO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("OD_REGISTRO"))),
        //                                    FECHA_ENTREGA = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("FECHA_ENTREGA"))),
        //                                    ANO = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("ANIO_ENTREGA"))),
        //                                    AREA_TH = oGDataSQL.ValidateNullDB<decimal>(dr.GetValue(dr.GetOrdinal("AREA_TH"))),
        //                                    AREA_POA = oGDataSQL.ValidateNullDB<decimal>(dr.GetValue(dr.GetOrdinal("AREA_POA"))),
        //                                    FECHA_SALIDA_CAMPO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("FECHA_SALIDA_CAMPO"))),
        //                                    FECHA_RECEPCION_CHEQUE = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("FECHA_RECEPCION_CHEQUE"))),
        //                                    FECHA_COBRO_CHEQUE = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("FECHA_COBRO_CHEQUE"))),
        //                                    FECHA_REGRESO_CAMPO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("FECHA_REGRESO_CAMPO"))),
        //                                    FECHA_INICIO_LABORES = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("FECHA_INICIO_LABORES"))),
        //                                    ELAB_TERCERO = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("ELAB_TERCERO")))

        //                                },
        //                                vM_FControlCalidadSupervision = new VM_FControlCalidadSupervision
        //                                {
        //                                    eJefeODC = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("JEFEOD_CONTROL_CALIDAD"))),
        //                                    fechaRecepcionIS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("FECHA_RECEPCION_IS")))
        //                                }
        //                            });
        //                        }
        //                    }
        //                    dr.NextResult();
        //                    if (dr.HasRows)
        //                    {
        //                        while (dr.Read())
        //                        {
        //                            string codInforme = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("COD_INFORME")));
        //                            VM_FControlCalidadSupervision_Det vM_FControlCalidadSupervision = new VM_FControlCalidadSupervision_Det
        //                            {
        //                                id = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("ID"))),
        //                                ORDEN_PADRE = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("ORDEN_PADRE"))),
        //                                padre = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("PADRE"))),
        //                                codigo = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("CODIGO"))),
        //                                ORDEN_HIJO = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("ORDEN_HIJO"))),
        //                                hijo = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("HIJO"))),
        //                                PRESENTA_OBS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("PRESENTA_OBS"))),
        //                                DETALLE = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("DETALLE"))),
        //                                FECHA_VARIOS = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("FECHA_VARIOS")))
        //                            };
        //                            var item = vw.respuestasLista.Find(info => info.Ent_Informe.COD_INFORME.Trim() == codInforme.Trim());
        //                            if (item == null)
        //                            {
        //                                vw.respuestasLista.Add(new INFORME_CONTROL_CALIDAD
        //                                {
        //                                    Ent_Informe = new Ent_INFORME { COD_INFORME = codInforme },
        //                                    vM_FControlCalidadSupervision = new VM_FControlCalidadSupervision
        //                                    {
        //                                        lstISupervision = new List<VM_FControlCalidadSupervision_Det>
        //                                        {
        //                                            vM_FControlCalidadSupervision
        //                                        }
        //                                    }
        //                                });
        //                            }
        //                            else
        //                            {
        //                                item.vM_FControlCalidadSupervision
        //                                    .lstISupervision
        //                                    .Add(vM_FControlCalidadSupervision);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e) { throw (e); };
        //    return vw;
        //}
    }
}
