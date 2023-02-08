using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;
using CapaEntidad.DOC;
using System.Data;
using CEntidad = CapaEntidad.DOC.Ent_TFFS;
using SQL = GeneralSQL.Data.SQL;
using CEntResodirec = CapaEntidad.DOC.Ent_RESODIREC;
using CEntidadC = CapaEntidad.DOC.Ent_RESODIREC;
//-----------------------------


namespace CapaDatos.DOC
{
    public class Dat_TFFS
    {
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
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
                        List<Ent_SBusqueda> lsDetDetalleB;
                        CEntidad oCamposDet;
                        Ent_SBusqueda oCamposDetB;
                        //
                        //Tipo
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoTFFS = lsDetDetalle;
                        //Referencia
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

                        oCampos.ListReferenciaTFFS = lsDetDetalle;
                        //resuelve
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
                        oCampos.ListResuelveTFFS = lsDetDetalle;
                        //Declara
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
                        oCampos.ListDeclaraTFFS = lsDetDetalle;
                        //Recurso de Apelación
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
                        oCampos.ListComboRecursoApelacion = lsDetDetalle;
                        //Tipos de Determinación  -------- Datos de Resolucion/Tipo de Resolucion -----------
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


                        oCampos.ListComboDetermina = lsDetDetalle;
                        //Tipos Documentos hasta donde se retrotra el proceso
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
                        oCampos.ListComboDocRetrotrae = lsDetDetalle;
                        //Tipos de Proveídos
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
                        oCampos.ListComboTipoProveido = lsDetDetalle;
                        //Estado Determina
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
                        oCampos.ListComboEstadoDetermina = lsDetDetalle;
                        //--------------Sentido de Resolucion----------

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
                        oCampos.ListComboSentidoRes = lsDetDetalle;

                        //--------------DETERMINA_Resolucion---------------

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
                        oCampos.ListComboDeterminaRes = lsDetDetalle;
                        //---------------Combo retrotraer------------------------
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
                        oCampos.ListComboRetrotraer = lsDetDetalle;

                        //------------------- Lista Otros ---------------------------------
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
                        oCampos.ListOtros = lsDetDetalle;

                        //------------------- Lista Improcedente ---------------------------------
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
                        oCampos.ListImprocedente = lsDetDetalle;

                        //------------------- Lista Inadmisible ---------------------------------
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
                        oCampos.ListInadmisible = lsDetDetalle;

                        //------------------- Lista Nulidad ---------------------------------
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
                        oCampos.ListNulidad = lsDetDetalle;

                        //------------------- Lista Determina ---------------------------------
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
                        oCampos.ListComboTipoProveido = lsDetDetalle;

                        //------------------- Lista Nulidad de Oficio ---------------------------------
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
                        oCampos.ListNulidadOficio = lsDetDetalle;

                        //------------------- Lista Ubigeo ---------------------------------
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
                        oCampos.ListUbigeo = lsDetDetalle;

                        //------------------- Lista Estado PAU ---------------------------------
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
                        oCampos.ListEstadoPAU = lsDetDetalle;

                        //------------------- Confirma Resolucion ---------------------------------
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
                        oCampos.ListConfirmResol = lsDetDetalle;

                        //------------------- Lista Medidas Correctivas ---------------------------------
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
                        oCampos.ListMedCorrectivas = lsDetDetalle;

                        //------------------- Lista Tipo de Aprovechamiento ---------------------------------
                        dr.NextResult();
                        lsDetDetalleB = new List<Ent_SBusqueda>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDetB = new Ent_SBusqueda();
                                oCamposDetB.Value = dr["Value"].ToString();
                                oCamposDetB.Text = dr["Text"].ToString();
                                lsDetDetalleB.Add(oCamposDetB);
                            }
                        }
                        oCampos.ListTipoAprovechamiento = lsDetDetalleB;

                        //------------------- Lista Articulo ---------------------------------
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
                        oCampos.ListArticulo = lsDetDetalle;

                        //------------------- Lista POA ---------------------------------
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
                        oCampos.ListPOA = lsDetDetalle;
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
                        oCampos.ListFlora = lsDetDetalle;
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
                        oCampos.ListFauna = lsDetDetalle;

                    }
                }
                return oCampos;
            }
            catch (OracleException e)
            {
                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "My Application";
                Debug.Write("mensaje de error de ORACLE");
                throw e;
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
        public CEntidad RegMostrariNFORME_Buscar(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad busqueda = new CEntidad();
            int cantidadRegistros = 0;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "doc_osinfor_erp_migracion.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                oCampos.D_LINEA = dr["D_LINEA"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.DESCRIPCION_MED_CORRECTIVAS = dr["DESCRIPCION_MED_CORRECTIVAS"].ToString();
                                lsCEntidad.Add(oCampos);
                                cantidadRegistros++;
                            }
                        }
                    }
                            busqueda.v_ROW_INDEX = cantidadRegistros;
                }
                busqueda.ListInformes = lsCEntidad;
                return busqueda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad RegMostrarListaTFFSItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spResolucion_TFFSMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformes = new List<CEntidad>();
                        lsCEntidad.ListEliTABLA = new List<CEntidad>();
                        lsCEntidad.ListPersonaFirma = new List<CEntidad>();
                        lsCEntidad.ListProveidoGenerar = new List<CEntidad>();
                        lsCEntidad.ListInfraccionRD = new List<CEntResodirec>();
                        lsCEntidad.ListLiteralRD = new List<CEntidad>();
                        lsCEntidad.ListEMaderable = new List<CapaEntidad.DOC.Ent_INFORME>();
                        lsCEntidad.ListEMaderableSemillero = new List<CapaEntidad.DOC.Ent_INFORME>();
                        lsCEntidad.ListNoti = new List<CEntidad>();
                        lsCEntidad.ListARFFS = new List<CEntidad>();
                        lsCEntidad.ListTFFSApel = new List<CEntidad>();
                        lsCEntidad.ListPOAObservatorio = new List<CEntResodirec>();
                        lsCEntidad.ListPOAs = new List<CEntidad>();
                        //CEntPresupSuper ocampodet;
                        CEntidad ocampoEnt;
                        // p1. procAlmaverif
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.NUM_RESOLUCION_TFFS = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION_TFFS"));
                            lsCEntidad.COD_TIPO = dr.GetString(dr.GetOrdinal("COD_TIPO"));
                            lsCEntidad.COD_REFERENCIA = dr.GetString(dr.GetOrdinal("COD_REFERENCIA"));
                            lsCEntidad.COD_RESUELVE = dr.GetString(dr.GetOrdinal("COD_RESUELVE"));
                            lsCEntidad.COD_DECLARA = dr.GetString(dr.GetOrdinal("COD_DECLARA"));
                            lsCEntidad.FECHA_DOCUMENTO = dr.GetString(dr.GetOrdinal("FECHA_DOCUMENTO"));
                            lsCEntidad.OBSERVACIONES = dr.GetString(dr.GetOrdinal("OBSERVACIONES"));
                            lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                            //lsCEntidad.MAE_TIP_RECAPEL = dr.GetString(dr.GetOrdinal("MAE_TIP_RECAPEL"));
                            lsCEntidad.TIP_RES = dr.GetString(dr.GetOrdinal("TIP_RES"));
                            lsCEntidad.RES_APE = dr.GetString(dr.GetOrdinal("RES_APE"));
                            lsCEntidad.MAE_TIP_DETERMI = dr.GetString(dr.GetOrdinal("MAE_TIP_DETERMI"));
                            lsCEntidad.MAE_TIP_MOT_DETERMI = dr.GetString(dr.GetOrdinal("MAE_TIP_MOT_DETERMI"));
                            lsCEntidad.MOT_DETERMI = dr.GetString(dr.GetOrdinal("MOT_DETERMI"));
                            lsCEntidad.CAMBIO_MULTA = dr.GetDecimal(dr.GetOrdinal("CAMBIO_MULTA"));
                            lsCEntidad.CADUCIDAD = dr.GetDecimal(dr.GetOrdinal("CADUCIDAD"));
                            //lsCEntidad.UBIGEO_DEPA = dr.GetString(dr.GetOrdinal("UBIGEO_DEPA"));
                            lsCEntidad.MULTA = dr.GetDecimal(dr.GetOrdinal("MULTA"));
                            lsCEntidad.MAE_TIP_DOC_RETRO = dr.GetString(dr.GetOrdinal("MAE_TIP_DOC_RETRO"));
                            lsCEntidad.DOC_RETRO = dr.GetString(dr.GetOrdinal("DOC_RETRO"));
                            lsCEntidad.CONFIRM_RESOL = dr.GetString(dr.GetOrdinal("CONFIRM_RESOL"));
                            lsCEntidad.CONFIRM_CMULTA = dr.GetDecimal(dr.GetOrdinal("CONFIRM_CMULTA"));
                            lsCEntidad.ESTADO_PAU = dr.GetString(dr.GetOrdinal("ESTADO_PAU"));
                            lsCEntidad.DESCRIPCION_MED_CORRECTIVAS = dr.GetString(dr.GetOrdinal("DESCRIPCION_MED_CORRECTIVAS"));
                            lsCEntidad.MEDIDAS_CORRECTIVAS = dr.GetInt32(dr.GetOrdinal("MEDIDAS_CORRECTIVAS"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.CAMBIA_ESTADO_ESPECIES = dr.GetBoolean(dr.GetOrdinal("CAMBIA_ESTADO_ESPECIES"));
                            lsCEntidad.MAE_ESTDETERMINA_CADUCIDAD = dr.GetString(dr.GetOrdinal("MAE_ESTDETERMINA_CADUCIDAD"));
                            lsCEntidad.MAE_ESTDETERMINA_MULTA = dr.GetString(dr.GetOrdinal("MAE_ESTDETERMINA_MULTA"));
                            lsCEntidad.MAE_ESTDETERMINA_MCORRECTIVA = dr.GetString(dr.GetOrdinal("MAE_ESTDETERMINA_MCORRECTIVA"));
                            lsCEntidad.FECHA_PRESENTACION = dr.GetString(dr.GetOrdinal("FECHA_PRESENTACION"));
                            lsCEntidad.TITULAR_INT = dr.GetString(dr.GetOrdinal("TITULAR_INT"));
                            lsCEntidad.RESPONSABLE_SOL = dr.GetString(dr.GetOrdinal("RESPONSABLE_SOL"));
                            lsCEntidad.REGENTE = dr.GetString(dr.GetOrdinal("REGENTE"));
                            lsCEntidad.ARFFS2 = dr.GetString(dr.GetOrdinal("ARFFS2"));
                            lsCEntidad.ATFFS = dr.GetString(dr.GetOrdinal("ATFFS"));
                            lsCEntidad.MINPUBLICO = dr.GetString(dr.GetOrdinal("MINPUBLICO"));
                            lsCEntidad.MINENERGIA = dr.GetString(dr.GetOrdinal("MINENERGIA"));
                            lsCEntidad.COLEINGE = dr.GetString(dr.GetOrdinal("COLEINGE"));
                            lsCEntidad.OCI = dr.GetString(dr.GetOrdinal("OCI"));
                            lsCEntidad.OEFA = dr.GetString(dr.GetOrdinal("OEFA"));
                            lsCEntidad.SUNAT = dr.GetString(dr.GetOrdinal("SUNAT"));
                            lsCEntidad.SERFOR = dr.GetString(dr.GetOrdinal("SERFOR"));
                            lsCEntidad.OTROS = dr.GetString(dr.GetOrdinal("OTROS"));
                            lsCEntidad.DFFFS = dr.GetString(dr.GetOrdinal("DFFFS"));
                            lsCEntidad.DSFFS = dr.GetString(dr.GetOrdinal("DSFFS"));
                            lsCEntidad.URH = dr.GetString(dr.GetOrdinal("URH"));
                            lsCEntidad.OCI2 = dr.GetString(dr.GetOrdinal("OCI2"));
                            lsCEntidad.OTROS2 = dr.GetString(dr.GetOrdinal("OTROS2"));
                            lsCEntidad.CHKTITULAR = dr.GetInt32(dr.GetOrdinal("CHKTITULAR"));
                            lsCEntidad.CHKRESPONSABLE = dr.GetInt32(dr.GetOrdinal("CHKRESPONSABLE"));
                            lsCEntidad.CHKREGENTE = dr.GetInt32(dr.GetOrdinal("CHKREGENTE"));
                            lsCEntidad.CHKARFFS2 = dr.GetInt32(dr.GetOrdinal("CHKARFFS2"));
                            lsCEntidad.CHKATFFS = dr.GetInt32(dr.GetOrdinal("CHKATFFS"));
                            lsCEntidad.CHKMINPUBLICO = dr.GetInt32(dr.GetOrdinal("CHKMINPUBLICO"));
                            lsCEntidad.CHKMINENERGIA = dr.GetInt32(dr.GetOrdinal("CHKMINENERGIA"));
                            lsCEntidad.CHKCOLEINGE = dr.GetInt32(dr.GetOrdinal("CHKCOLEINGE"));
                            lsCEntidad.CHKOCI = dr.GetInt32(dr.GetOrdinal("CHKOCI"));
                            lsCEntidad.CHKOEFA = dr.GetInt32(dr.GetOrdinal("CHKOEFA"));
                            lsCEntidad.CHKSUNAT = dr.GetInt32(dr.GetOrdinal("CHKSUNAT"));
                            lsCEntidad.CHKSERFOR = dr.GetInt32(dr.GetOrdinal("CHKSERFOR"));
                            lsCEntidad.CHKOTROS = dr.GetInt32(dr.GetOrdinal("CHKOTROS"));
                            lsCEntidad.CHKDFFFS = dr.GetInt32(dr.GetOrdinal("CHKDFFFS"));
                            lsCEntidad.CHKDSFFS = dr.GetInt32(dr.GetOrdinal("CHKDSFFS"));
                            lsCEntidad.CHKURH = dr.GetInt32(dr.GetOrdinal("CHKURH"));
                            lsCEntidad.CHKOCI2 = dr.GetInt32(dr.GetOrdinal("CHKOCI2"));
                            lsCEntidad.CHKOTROS2 = dr.GetInt32(dr.GetOrdinal("CHKOTROS2"));
                            lsCEntidad.QUEJA_OBS = dr.GetString(dr.GetOrdinal("QUEJA_OBS"));
                            lsCEntidad.RES_OTROS = dr.GetString(dr.GetOrdinal("RES_OTROS"));
                            lsCEntidad.DESCRIP_TEXT = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT"));
                            lsCEntidad.OTROS_NULI = dr.GetString(dr.GetOrdinal("OTROS_NULI"));
                            lsCEntidad.SENTIDO_RES = dr.GetString(dr.GetOrdinal("SENTIDO_RES"));
                            lsCEntidad.RESOL_IMPRO = dr.GetString(dr.GetOrdinal("RESOL_IMPRO"));
                            lsCEntidad.RESOL_DET = dr.GetString(dr.GetOrdinal("RESOL_DET"));
                            lsCEntidad.RESOL_INAD = dr.GetString(dr.GetOrdinal("RESOL_INAD"));
                            lsCEntidad.RESOL_DET2 = dr.GetString(dr.GetOrdinal("RESOL_DET2"));
                            lsCEntidad.RESOL_DET3 = dr.GetString(dr.GetOrdinal("RESOL_DET3"));
                            //lsCEntidad.DET_FUNDADO1 = dr.GetString(dr.GetOrdinal("DET_FUNDADO1"));
                            lsCEntidad.CMB_NULIDAD = dr.GetString(dr.GetOrdinal("CMB_NULIDAD"));
                            lsCEntidad.CMB_NULIDAD2 = dr.GetString(dr.GetOrdinal("CMB_NULIDAD2"));
                            lsCEntidad.RETRO_VALOR1 = dr.GetString(dr.GetOrdinal("RETRO_VALOR1"));
                            lsCEntidad.FEMISION_BEXTRACION = dr.GetString(dr.GetOrdinal("FEMISION_BEXTRACION"));
                            lsCEntidad.ARTICULO = dr.GetString(dr.GetOrdinal("ARTICULO"));
                            lsCEntidad.DESCRIP_TEXT_INFRACCION = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_INFRACCION"));
                            lsCEntidad.POA = dr.GetString(dr.GetOrdinal("POA"));
                            lsCEntidad.TIPO_APROVECHAMIENTO = dr.GetString(dr.GetOrdinal("TIPO_APROVECHAMIENTO"));
                            lsCEntidad.DESCRIP_TEXT_SUSPENSION = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_SUSPENSION"));
                            lsCEntidad.DESCRIP_TEXT_CUMPLIMIENTO = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_CUMPLIMIENTO"));
                            lsCEntidad.DESCRIP_TEXT_DESESTIMIENTO = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_DESESTIMIENTO"));
                            lsCEntidad.N_TRAMITE = dr.GetString(dr.GetOrdinal("N_TRAMITE")); //
                            lsCEntidad.ARCHIVO_ADJUNTO = dr.GetString(dr.GetOrdinal("ARCHIVO_ADJUNTO")); //
                            lsCEntidad.CHKCONFIRMAR = dr.GetInt32(dr.GetOrdinal("CHKCONFIRMAR"));
                            lsCEntidad.CHKCONFIRMAR2 = dr.GetInt32(dr.GetOrdinal("CHKCONFIRMAR2"));
                            lsCEntidad.CHKREVOCAR = dr.GetInt32(dr.GetOrdinal("CHKREVOCAR"));
                            lsCEntidad.RADREVOCAR = dr.GetString(dr.GetOrdinal("RADREVOCAR"));
                            lsCEntidad.RADNULIDAD = dr.GetString(dr.GetOrdinal("RADNULIDAD"));
                            lsCEntidad.RADREVOCARPARTE = dr.GetString(dr.GetOrdinal("RADREVOCARPARTE"));
                            lsCEntidad.CHKREVOCAR2 = dr.GetInt32(dr.GetOrdinal("CHKREVOCAR2"));
                            lsCEntidad.RADREVOCAR2 = dr.GetString(dr.GetOrdinal("RADREVOCAR2"));
                            lsCEntidad.RADNULIDAD2 = dr.GetString(dr.GetOrdinal("RADNULIDAD2"));
                            lsCEntidad.RADREVOCARPARTE2 = dr.GetString(dr.GetOrdinal("RADREVOCARPARTE2"));
                            lsCEntidad.CHKREVOCARPARTE = dr.GetInt32(dr.GetOrdinal("CHKREVOCARPARTE"));
                            lsCEntidad.CHKREVOCARPARTE2 = dr.GetInt32(dr.GetOrdinal("CHKREVOCARPARTE2"));
                            lsCEntidad.CHKRETROTRAER = dr.GetInt32(dr.GetOrdinal("CHKRETROTRAER"));
                            lsCEntidad.RADRETROTRAER = dr.GetString(dr.GetOrdinal("RADRETROTRAER"));
                            lsCEntidad.CHKRETROTRAER2 = dr.GetInt32(dr.GetOrdinal("CHKRETROTRAER2"));
                            lsCEntidad.RADRETROTRAER2 = dr.GetString(dr.GetOrdinal("RADRETROTRAER2"));
                            lsCEntidad.CHKPRESCRIBIR = dr.GetInt32(dr.GetOrdinal("CHKPRESCRIBIR"));
                            lsCEntidad.CHKPRESCRIBIR2 = dr.GetInt32(dr.GetOrdinal("CHKPRESCRIBIR2"));
                            lsCEntidad.CHKARCHIVAR = dr.GetInt32(dr.GetOrdinal("CHKARCHIVAR"));
                            lsCEntidad.CHKARCHIVAR2 = dr.GetInt32(dr.GetOrdinal("CHKARCHIVAR2"));
                            lsCEntidad.CHKNULIDAD = dr.GetInt32(dr.GetOrdinal("CHKNULIDAD"));
                            lsCEntidad.CHKNULIDAD2 = dr.GetInt32(dr.GetOrdinal("CHKNULIDAD2"));
                            lsCEntidad.CHKLEVANTAR = dr.GetInt32(dr.GetOrdinal("CHKLEVANTAR"));
                            lsCEntidad.CHKLEVANTAR2 = dr.GetInt32(dr.GetOrdinal("CHKLEVANTAR2"));
                            lsCEntidad.CHKCARECE = dr.GetInt32(dr.GetOrdinal("CHKCARECE"));
                            lsCEntidad.CHKCARECE2 = dr.GetInt32(dr.GetOrdinal("CHKCARECE2"));
                            lsCEntidad.CHKOTRO = dr.GetInt32(dr.GetOrdinal("CHKOTRO"));
                            lsCEntidad.CHKOTRO2 = dr.GetInt32(dr.GetOrdinal("CHKOTRO2"));
                            lsCEntidad.PROFESIONAL = dr.GetString(dr.GetOrdinal("PROFESIONAL"));
                            lsCEntidad.CARGO = dr.GetString(dr.GetOrdinal("CARGO"));
                            lsCEntidad.AMONESTACION = dr.GetString(dr.GetOrdinal("AMONESTACION"));
                            lsCEntidad.DESCRIP_TEXT_IMPRO = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_IMPRO"));
                            lsCEntidad.DESCRIP_TEXT_INAD = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_INAD"));
                            lsCEntidad.DESCRIP_TEXT_INFU = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_INFU"));
                            lsCEntidad.DESCRIP_TEXT_FUND = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_FUND"));
                            lsCEntidad.DESCRIP_TEXT_FPARTE = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_FPARTE"));
                            lsCEntidad.DESCRIP_TEXT_RETROTRAER = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_RETROTRAER"));
                            lsCEntidad.DESCRIP_TEXT_OTRO = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_OTRO"));
                            lsCEntidad.DESCRIP_TEXT_OTROS = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_OTROS"));
                            lsCEntidad.DESCRIP_TEXT_SENTIDO = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_SENTIDO"));
                            lsCEntidad.DETERMINA_RETROTRAER = dr.GetString(dr.GetOrdinal("DETERMINA_RETROTRAER"));
                            lsCEntidad.LEVANTAMIENTO = dr.GetString(dr.GetOrdinal("LEVANTAMIENTO"));
                            lsCEntidad.MEDIDAS_CORRECTIVAS2 = dr.GetString(dr.GetOrdinal("MEDIDAS_CORRECTIVAS2"));
                            lsCEntidad.CAMBIO_MULTA2 = dr.GetString(dr.GetOrdinal("CAMBIO_MULTA2"));
                            lsCEntidad.MULTA2 = dr.GetString(dr.GetOrdinal("MULTA2"));
                            lsCEntidad.AMONESTACION2 = dr.GetString(dr.GetOrdinal("AMONESTACION2"));
                            lsCEntidad.DETERMINA_RETROTRAER2 = dr.GetString(dr.GetOrdinal("DETERMINA_RETROTRAER2"));
                            lsCEntidad.RETRO_VALOR2 = dr.GetString(dr.GetOrdinal("RETRO_VALOR2"));
                            lsCEntidad.DESCRIP_TEXT_OTROS2 = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_OTROS2"));
                            lsCEntidad.DESCRIP_TEXT_RETROTRAER2 = dr.GetString(dr.GetOrdinal("DESCRIP_TEXT_RETROTRAER2"));                        
                        }
                        //Estado (Calidad)
                        // p2. Proc. Almaceverif 
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
                        }
                        //p3.
                        //Lista de INFORMES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_INFORME");
                            int pt1 = dr.GetOrdinal("NUMERO");
                            int pt2 = dr.GetOrdinal("D_LINEA");
                            int pt3 = dr.GetOrdinal("NUM_THABILITANTE");
                            int pt4 = dr.GetOrdinal("TITULAR");
                            int pt5 = dr.GetOrdinal("COD_RESODIREC");
                            int pt6 = dr.GetOrdinal("COD_RESODIREC_INI_PAU");
                            int pt7 = dr.GetOrdinal("DESCRIPCION_MED_CORRECTIVAS");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_INFORME = dr.GetString(pt0);
                                ocampoEnt.NUMERO = dr.GetString(pt1);
                                ocampoEnt.D_LINEA = dr.GetString(pt2);
                                ocampoEnt.NUM_THABILITANTE = dr.GetString(pt3);
                                ocampoEnt.TITULAR = dr.GetString(pt4);
                                ocampoEnt.COD_RESODIREC = dr.GetString(pt5);
                                ocampoEnt.COD_RESODIREC_INI_PAU = dr.GetString(pt6);
                                ocampoEnt.DESCRIPCION_MED_CORRECTIVAS = dr.GetString(pt7);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListInformes.Add(ocampoEnt);
                            }
                        }
                        //p4.procFirmaverif--
                        //Lista de personas que firma la resolución del TFFS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                                ocampoEnt.COD_RESOLUCION_TFFS = dr.GetString(dr.GetOrdinal("COD_RESOLUCION_TFFS"));
                                ocampoEnt.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                                ocampoEnt.CARGO = dr.GetString(dr.GetOrdinal("CARGO"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListPersonaFirma.Add(ocampoEnt);
                            }
                        }
                        //p5.procProveidoverif--
                        //Lista de Proveídos a Generar
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
                                ocampoEnt.COD_RESOLUCION_TFFS = dr.GetString(dr.GetOrdinal("COD_RESOLUCION_TFFS"));
                                lsCEntidad.ListProveidoGenerar.Add(ocampoEnt);
                            }
                        }
                        //p6.procInfracverif--
                        //Lista de Infracciones
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntResodirec oEntResodirec;

                            while (dr.Read())
                            {
                                oEntResodirec = new CEntResodirec();
                                oEntResodirec.COD_ILEGAL_ENCISOS = dr["COD_ILEGAL_ENCISOS"].ToString();
                                oEntResodirec.COD_ILEGAL_ARTICULOS = dr["COD_ILEGAL_ARTICULOS"].ToString();
                                oEntResodirec.DESCRIPCION_ARTICULOS = dr["DESCRIPCION_ARTICULOS"].ToString();
                                oEntResodirec.DESCRIPCION_ENCISOS = dr["DESCRIPCION_ENCISOS"].ToString();
                                oEntResodirec.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oEntResodirec.DESCRIPCION_ESPECIE = dr["DESCRIPCION_ESPECIE"].ToString();
                                oEntResodirec.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                oEntResodirec.AREA = Decimal.Parse(dr["AREA"].ToString());
                                oEntResodirec.NUMERO_INDIVIDUOS = Int32.Parse(dr["NUMERO_INDIVIDUOS"].ToString());
                                oEntResodirec.DESCRIPCION_INFRACCIONES = dr["DESCRIPCION_INFRACCIONES"].ToString();
                                oEntResodirec.NUM_POA = dr["NUM_POA"].ToString();
                                oEntResodirec.POA = dr["POA"].ToString();
                                oEntResodirec.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                                oEntResodirec.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oEntResodirec.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oEntResodirec.DETERMINACION = dr["DETERMINACION"].ToString();
                                oEntResodirec.COD_FCTIPO = dr["COD_FCTIPO"].ToString();
                                oEntResodirec.RegEstado = 0;
                                oEntResodirec.BTN_LITERALES = false;
                                oEntResodirec.BTN_LITERALES2 = true;
                                oEntResodirec.MAE_ESTDETERMINA_ART363I = dr["MAE_ESTDETERMINA_ART363I"].ToString();
                                oEntResodirec.ESTDETERMINA_ART363I = dr["ESTDETERMINA_ART363I"].ToString();

                                lsCEntidad.ListInfraccionRD.Add(oEntResodirec);
                            }
                        }
                        //p7.proc--
                        //Lista de infracciones (incisos) por las que se retrotrae el proceso
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr.GetString(dr.GetOrdinal("COD_ILEGAL_ENCISOS"));
                                ocampoEnt.DESCRIPCION_ENCISOS = dr.GetString(dr.GetOrdinal("DESCRIPCION_ENCISOS"));
                                ocampoEnt.DESCRIPCION_ARTICULOS = dr.GetString(dr.GetOrdinal("DESCRIPCION_ARTICULOS"));
                                ocampoEnt.RegEstado = 0;

                                lsCEntidad.ListLiteralRD.Add(ocampoEnt);
                            }
                        }

                        CapaEntidad.DOC.Ent_INFORME ocampoisup;
                        //p8.proc--
                        //Datos de campo maderable
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoisup = new CapaEntidad.DOC.Ent_INFORME();
                                ocampoisup.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoisup.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoisup.NUM_POA = Convert.ToInt32(dr["NUM_POA"].ToString());
                                ocampoisup.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoisup.COD_SECUENCIAL = Convert.ToInt32(dr["COD_SECUENCIAL"].ToString());
                                ocampoisup.POA = dr["POA"].ToString();
                                ocampoisup.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoisup.BLOQUE_CAMPO = dr["BLOQUE_CAMPO"].ToString();
                                ocampoisup.FAJA = dr["FAJA"].ToString();
                                ocampoisup.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                                ocampoisup.CODIGO = dr["CODIGO"].ToString();
                                ocampoisup.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                ocampoisup.DESC_ESPECIES = dr["ESPECIES"].ToString();
                                ocampoisup.DESC_ESPECIES_CAMPO = dr["ESPECIES_CAMPO"].ToString();
                                var oCoincideE = dr["COINCIDE_ESPECIES"];
                                if (!DBNull.Value.Equals(oCoincideE)) ocampoisup.DESC_COINCIDE_ESPECIES = oCoincideE.ToString();
                                ocampoisup.ZONA = dr["ZONA"].ToString();
                                ocampoisup.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoisup.COORDENADA_ESTE = Convert.ToInt32(dr["COORDENADA_ESTE"].ToString());
                                ocampoisup.COORDENADA_ESTE_CAMPO = Convert.ToInt32(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoisup.COORDENADA_NORTE = Convert.ToInt32(dr["COORDENADA_NORTE"].ToString());
                                ocampoisup.COORDENADA_NORTE_CAMPO = Convert.ToInt32(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoisup.DAP = Convert.ToDecimal(dr["DAP"].ToString());
                                ocampoisup.DAP_CAMPO = Convert.ToDecimal(dr["DAP_CAMPO"].ToString());
                                ocampoisup.DAP_CAMPO1 = Convert.ToDecimal(dr["DAP_CAMPO1"].ToString());
                                ocampoisup.DAP_CAMPO2 = Convert.ToDecimal(dr["DAP_CAMPO2"].ToString());
                                ocampoisup.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoisup.AC = Convert.ToDecimal(dr["AC"].ToString());
                                ocampoisup.AC_CAMPO = Convert.ToDecimal(dr["AC_CAMPO"].ToString());
                                ocampoisup.DESC_EESTADO = dr["EESTADO"].ToString();
                                ocampoisup.DESC_EESTADO_CAMPO = dr["EESTADO_CAMPO"].ToString();
                                ocampoisup.COD_EESTADO = dr["COD_EESTADO_CAMPO"].ToString();
                                ocampoisup.DESC_ECONDICION = dr["ECONDICION"].ToString();
                                ocampoisup.DESC_ECONDICION_CAMPO = dr["ECONDICION_CAMPO"].ToString();
                                ocampoisup.OBSERVACION = dr["OBSERVACION"].ToString();
                                lsCEntidad.ListEMaderable.Add(ocampoisup);
                            }
                        }
                        //p9.proc--
                        //Datos de campo maderable semillero
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoisup = new CapaEntidad.DOC.Ent_INFORME();
                                ocampoisup.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoisup.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoisup.NUM_POA = Convert.ToInt32(dr["NUM_POA"].ToString());
                                ocampoisup.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoisup.COD_SECUENCIAL = Convert.ToInt32(dr["COD_SECUENCIAL"].ToString());
                                ocampoisup.POA = dr["POA"].ToString();
                                ocampoisup.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoisup.BLOQUE_CAMPO = dr["BLOQUE_CAMPO"].ToString();
                                ocampoisup.FAJA = dr["FAJA"].ToString();
                                ocampoisup.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                                ocampoisup.CODIGO = dr["CODIGO"].ToString();
                                ocampoisup.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                ocampoisup.DESC_ESPECIES = dr["ESPECIES"].ToString();
                                ocampoisup.DESC_ESPECIES_CAMPO = dr["ESPECIES_CAMPO"].ToString();
                                var oCoincideE = dr["COINCIDE_ESPECIES"];
                                if (!DBNull.Value.Equals(oCoincideE)) ocampoisup.DESC_COINCIDE_ESPECIES = oCoincideE.ToString();
                                ocampoisup.ZONA = dr["ZONA"].ToString();
                                ocampoisup.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoisup.COORDENADA_ESTE = Convert.ToInt32(dr["COORDENADA_ESTE"].ToString());
                                ocampoisup.COORDENADA_ESTE_CAMPO = Convert.ToInt32(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoisup.COORDENADA_NORTE = Convert.ToInt32(dr["COORDENADA_NORTE"].ToString());
                                ocampoisup.COORDENADA_NORTE_CAMPO = Convert.ToInt32(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoisup.DAP = Convert.ToDecimal(dr["DAP"].ToString());
                                ocampoisup.DAP_CAMPO = Convert.ToDecimal(dr["DAP_CAMPO"].ToString());
                                ocampoisup.DAP_CAMPO1 = Convert.ToDecimal(dr["DAP_CAMPO1"].ToString());
                                ocampoisup.DAP_CAMPO2 = Convert.ToDecimal(dr["DAP_CAMPO2"].ToString());
                                ocampoisup.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoisup.AC = Convert.ToDecimal(dr["AC"].ToString());
                                ocampoisup.AC_CAMPO = Convert.ToDecimal(dr["AC_CAMPO"].ToString());
                                ocampoisup.DESC_EESTADO = dr["EESTADO"].ToString();
                                ocampoisup.DESC_EESTADO_CAMPO = dr["EESTADO_CAMPO"].ToString();
                                ocampoisup.COD_EESTADO = dr["COD_EESTADO_CAMPO"].ToString();
                                ocampoisup.DESC_EFENOLOGICO = dr["EFENOLOGICO"].ToString(); //
                                ocampoisup.DESC_CFUSTE = dr["CFUSTE"].ToString();//
                                ocampoisup.DESC_FCOPA = dr["FCOPA"].ToString();//
                                ocampoisup.DESC_PCOPA = dr["PCOPA"].ToString();//
                                ocampoisup.DESC_EFITOSANITARIO = dr["ESANITARIO"].ToString();//
                                ocampoisup.DESC_ILIANAS = dr["ILIANAS"].ToString();//
                                ocampoisup.OBSERVACION = dr["OBSERVACION"].ToString();
                                lsCEntidad.ListEMaderableSemillero.Add(ocampoisup);
                            }
                        }
                        //p10.proc--
                        // Notificacion a la ARFFS                        
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_RESOLUCION_TFFS = dr["COD_RESOLUCION_TFFS"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.NUMERO = dr["NUMERO"].ToString();
                                ocampoEnt.RESOLUCION_TFFS = dr["RESOLUCION_TFFS"].ToString();
                                ocampoEnt.TIPO_FISCALIZA = dr["TIPO_FISCALIZA"].ToString();
                                ocampoEnt.NUMERO_EXPEDIENTE = dr["NUMERO_EXPEDIENTE"].ToString();
                                ocampoEnt.NUMERO_INFORME = dr["NUMERO_INFORME"].ToString();
                                ocampoEnt.NUMERO_RESOLUCION = dr["NUMERO_RESOLUCION"].ToString();
                                ocampoEnt.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
                                ocampoEnt.FECHA = dr["FECHA"].ToString();
                                ocampoEnt.FECHA_NOTIFICACION = dr["FECHA_NOTIFICACION"].ToString();
                                ocampoEnt.DESTINATARIO = dr["DESTINATARIO"].ToString();
                                ocampoEnt.DIRECCION = dr["DIRECCION"].ToString();
                                ocampoEnt.RUTA = dr["RUTA"].ToString();
                                ocampoEnt.ESTADO = dr["ESTADO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListARFFS.Add(ocampoEnt);
                            }
                        }
                        //p11.proc--
                        // Resolucion TFFS la titulas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_RESOLUCION_TFFS = dr["COD_RESOLUCION_TFFS"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.NUMERO = dr["NUMERO"].ToString();
                                ocampoEnt.RESOLUCION_TFFS = dr["RESOLUCION_TFFS"].ToString();
                                ocampoEnt.TIPO_FISCALIZA = dr["TIPO_FISCALIZA"].ToString();
                                ocampoEnt.NUMERO_EXPEDIENTE = dr["NUMERO_EXPEDIENTE"].ToString();
                                ocampoEnt.NUMERO_INFORME = dr["NUMERO_INFORME"].ToString();
                                ocampoEnt.NUMERO_RESOLUCION = dr["NUMERO_RESOLUCION"].ToString();
                                ocampoEnt.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
                                ocampoEnt.FECHA = dr["FECHA"].ToString();
                                ocampoEnt.FECHA_NOTIFICACION = dr["FECHA_NOTIFICACION"].ToString();
                                ocampoEnt.DESTINATARIO = dr["DESTINATARIO"].ToString();
                                ocampoEnt.DIRECCION = dr["DIRECCION"].ToString();
                                ocampoEnt.RUTA = dr["RUTA"].ToString();
                                ocampoEnt.ESTADO = dr["ESTADO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListNoti.Add(ocampoEnt); 
                            }
                        }
                        dr.NextResult();
                        //p12.proc--
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUM_RESOLUCION_TFFS = dr["NUM_RESOLUCION_TFFS"].ToString();
                                ocampoEnt.COD_RESOLUCION_TFFS = dr["COD_RESOLUCION_TFFS"].ToString();
                                ocampoEnt.DES_REFERENCIA = dr["DES_REFERENCIA"].ToString();
                                ocampoEnt.NUM_RESOLUCION = dr["NUM_RESOLUCION"].ToString();
                                ocampoEnt.NUMERO_EXPEDIENTE = dr["NUMERO_EXPEDIENTE"].ToString();
                                ocampoEnt.FECHA = dr["FECHA"].ToString();
                                ocampoEnt.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                ocampoEnt.TITULAR = dr["TITULAR"].ToString();
                                ocampoEnt.MODALIDAD = dr["MODALIDAD"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListTFFSApel.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        //p13 para jalar numero habilitante y titular--
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lsCEntidad.NT_HABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                lsCEntidad.N_TITULAR_AD = dr.GetString(dr.GetOrdinal("TITULAR"));
                                lsCEntidad.UBIGEO_DEPA = dr.GetString(dr.GetOrdinal("ESTAB_UBIGEO"));
                            }
                        }
                        dr.NextResult();
                        //p14 para ListaPOA--
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_RESOLUCION_TFFS = dr.GetString(dr.GetOrdinal("COD_RESOLUCION_TFFS"));
                                ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA")).ToString();
                                ocampoEnt.POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                ocampoEnt.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                                lsCEntidad.ListPOAs.Add(ocampoEnt);
                            }
                        }
                        //dr.NextResult();
                        //if (dr.HasRows)
                        //{
                        //    dr.Read();
                        //    lsCEntidad.ESTADO_ARCHIVO = "0";
                        //    lsCEntidad.cCodificacion_SiTD = dr["cCodificacion_SiTD"].ToString();
                        //    lsCEntidad.NOMBRE_ARCHIVO = dr["nombreDescargar"].ToString();
                        //}

                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegImportarIncisos(OracleConnection cn, CEntidad oCampoEntrada)
        {
            throw new NotImplementedException();
        }

        public String RegGrabaResolucion_TFFS(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            String v_COD_RESODIREC = "";

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRESOLUCION_TFFSGrabar_v4", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                    else if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de la Resolución  ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Resolución existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar esta Résolución del TFFS");
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
                    oCEntidad.COD_RESOLUCION_TFFS = OUTPUTPARAM01;
                    //oCEntidad.COD_INFTEC_DESCARGO = OUTPUTPARAM02;
                }
                //  Eliminando Detalle        
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.CODIGO = OUTPUTPARAM01;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;

                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spResolucion_TFFSEliminarDetalle", oCamposDet);
                    }
                }
                //Grabando Detalle Inicio PAU  queda de lado VBR 10-06-2021
                if (oCEntidad.ListInformes != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformes)
                    {
                        v_COD_RESODIREC = loDatos.COD_RESODIREC;
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_RESOLUCION_TFFS = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;
                            String v_COD_RESODIREC_INI_PAU = Convert.ToString(loDatos.COD_RESODIREC_INI_PAU);
                            bool b_COD_RESODIREC_INI_PAU = String.IsNullOrEmpty(v_COD_RESODIREC_INI_PAU);                           
                            oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC; 
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spResolucion_TFFS_DET_RD_Grabar", oCamposDet);
                        }
                    }
                }
				//Grabando Detalle Inicio PAU  queda de lado VBR 10-06-2021
                if (oCEntidad.ListPersonaFirma != null)
                {
                    foreach (var loDatos in oCEntidad.ListPersonaFirma)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_RESOLUCION_TFFS = OUTPUTPARAM01;
                            oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                            oCamposDet.CARGO = loDatos.CARGO;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.RegEstado = loDatos.RegEstado;

                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRESOLUCION_TFFS_FIRMAGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListInfraccionRD != null)
                {
                    CEntResodirec oEntResodirec;

                    foreach (var loDatos in oCEntidad.ListInfraccionRD)
                    {
                        oEntResodirec = new CEntResodirec();
                        //oEntResodirec.COD_RESODIREC = v_COD_RESODIREC == "" ? loDatos.COD_RESODIREC : v_COD_RESODIREC;
                        oEntResodirec.COD_RESODIREC = v_COD_RESODIREC;
                        oEntResodirec.DETERMINACION = loDatos.DETERMINACION;
                        oEntResodirec.DESCRIPCION_INFRACCIONES = loDatos.DESCRIPCION_INFRACCIONES;
                        oEntResodirec.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oEntResodirec.VOLUMEN = loDatos.VOLUMEN;
                        oEntResodirec.AREA = loDatos.AREA;
                        oEntResodirec.NUMERO_INDIVIDUOS = loDatos.NUMERO_INDIVIDUOS;
                        oEntResodirec.COD_FCTIPO = loDatos.COD_FCTIPO;
                        oEntResodirec.COD_RESOLUCION_TFFS = OUTPUTPARAM01;
                        if (oCEntidad.CONFIRM_RESOL == "EP")
                        {
                            oEntResodirec.MAE_ESTDETERMINA_ART363I = loDatos.MAE_ESTDETERMINA_ART363I;  
                        }

                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRESODIREC_UPDATE_TFFS", oEntResodirec);
                    }
                }
                if (oCEntidad.ListLiteralRD != null)
                {
                    foreach (var loDatos in oCEntidad.ListLiteralRD)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_RESOLUCION_TFFS = OUTPUTPARAM01;
                            oCamposDet.COD_ILEGAL_ENCISOS = loDatos.COD_ILEGAL_ENCISOS;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.RegEstado = loDatos.RegEstado;

                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRESOLUCION_TFFS_ENCISOSGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListPOAs != null)
                {
                    if (oCEntidad.ListPOAs.Count > 0) 
                    {
                        foreach (var loDatos in oCEntidad.ListPOAs)
                        {
                            //if (!string.IsNullOrEmpty(loDatos.COD_RESOLUCION_TFFS))
                            //{
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_RESOLUCION_TFFS = OUTPUTPARAM01;
                                //oCamposDet.COD_RESOLUCION_TFFS = loDatos.COD_RESOLUCION_TFFS;
                                oCamposDet.NUM_POA = loDatos.NUM_POA;
                                oCamposDet.PUBLICAR = loDatos.PUBLICAR;
                                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            if (oCamposDet.NUM_POA != null)
                            {
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESOLUCION_TFFS_INFO_DOCUMENT_Grabar", oCamposDet);
                            }
                                
                            //}
                            
                        }
                    }
                }
                //if (oCEntidad.ListEMaderable != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListEMaderable)
                //    {
                //        oCamposDet = new CEntidad();
                //        oCamposDet.COD_RESOLUCION_TFFS = OUTPUTPARAM01;
                //        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                //        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                //        oCamposDet.NUM_POA = loDatos.NUM_POA.ToString();
                //        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                //        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //        oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
                //        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                //        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRESOLUCION_TFFS_EMADERABLEGrabar", oCamposDet);
                //    }
                //}
                //if (oCEntidad.ListEMaderableSemillero != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListEMaderableSemillero)
                //    {
                //        oCamposDet = new CEntidad();
                //        oCamposDet.COD_RESOLUCION_TFFS = OUTPUTPARAM01;
                //        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                //        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                //        oCamposDet.NUM_POA = loDatos.NUM_POA.ToString();
                //        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                //        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //        oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
                //        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                //        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRESOLUCION_TFFS_EMADERABLEGrabar", oCamposDet);
                //    }
                //}
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
        /// 





        // 12/10/2020 ---------------------------------------------------------------
        public List<CEntidad> ListarOtrosTFFS(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> oLista = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spMAESTRO_TFFSListar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                //
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oLista.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oLista;
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

        //------------------------------------------------------------------------------------


        public List<CEntidad> ListarDocuTFFS(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> ListTipoDocumento = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spBuscarDocumento", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCamposDet;
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["REMITENTE"].ToString();
                                oCamposDet.CODIGO = dr["DOCUMENTO"].ToString();
                                oCamposDet.CODIGO = dr["RESOLUCION"].ToString();
                                oCamposDet.CODIGO = dr["DIRECCION"].ToString();
                                ListTipoDocumento.Add(oCamposDet);
                            }
                        }
                    }
                }
                return ListTipoDocumento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<TipoDocumentos> ListarDocumentos(String NroResol, String TipoDoc)
        //{
        //    SqlConnection conexion = Conexion.getinstance().ConexionBD();
        //    SqlCommand cmd = null;
        //    SqlDataReader dr = null;
        //    List<TipoDocumentos> Lista = null;

        //    try
        //    {
        //        cmd = new SqlCommand("spBuscarDocumento", conexion);
        //        cmd.Parameters.AddWithValue("@NroResol", NroResol);
        //        cmd.Parameters.AddWithValue("@Documento", TipoDoc);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        conexion.Open();

        //        dr = cmd.ExecuteReader();
        //        Lista = new List<TipoDocumentos>();

        //        while (dr.Read())
        //        {
        //            TipoDocumentos Tipdoc = new TipoDocumentos();
        //            Tipdoc.Remitente = dr["REMITENTE"].ToString();
        //            Tipdoc.Documento= dr["DOCUMENTO"].ToString();
        //            Tipdoc.Resolucion= dr["RESOLUCION"].ToString();
        //            Tipdoc.Direccion= dr["DIRECCION"].ToString();

        //            Lista.Add(Tipdoc);
        //        }

        //    }
        //    catch ()
        //    {

        //    }

        //}



        //------------------------------------------------------------------------------------



        public List<CEntidad> ListarMaestroTFFS(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> oLista = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spMAESTRO_TFFSListar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                //
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oLista.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oLista;
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
        public List<CEntidad> ListarArticuloIncisoTFFS(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> oLista = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRESODIREC_INCISOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                //
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oLista.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oLista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegPreProcesarObservatorio(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            Int32 OUTPUTPARAM03 = 0;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "HERR_OSINFOR_ERP_MIGRACION.spPROCESAMIENTO_OBSERVATORIO_v3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM03 = Convert.ToInt32(cmd.Parameters["OUTPUTPARAM03"].Value);
                }
                tr.Commit();
                return OUTPUTPARAM03;
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
        public CEntidad RegMostListPOAs(OracleConnection cn, CEntidad oCEntidad)
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
                        //Lista de POAS
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NUM_POA = dr["NUM_POA"].ToString();
                                oCamposDet.POA = dr["POA"].ToString();
                                oCamposDet.RegEstado = 0;
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListPOAs = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_SBusqueda> RegMostCombo_V3(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Ent_SBusqueda> comboRecomendaciones = new List<Ent_SBusqueda>();
            Ent_SBusqueda oCampos = new Ent_SBusqueda();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.CR_FISCA_GENERAL_LISTAR", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new Ent_SBusqueda();
                        if (oCEntidad.BusCriterio != "ENCISOS")
                        {
                            oCampos.Value = "0000000";
                            oCampos.Text = "Seleccionar";
                            comboRecomendaciones.Add(oCampos);
                        }
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new Ent_SBusqueda();
                                oCampos.Value = dr["CODIGO"].ToString();
                                oCampos.Text = dr["DESCRIPCION"].ToString();
                                comboRecomendaciones.Add(oCampos);
                            }
                        }
                    }
                    cn.Close();
                }
                return comboRecomendaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidadC> RegImportarIncisos(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRESODIREC_INCISOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidadC ocampoEnt;
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr["COD_ILEGAL_ENCISOS"].ToString();
                                ocampoEnt.DESCRIPCION_ARTICULOS = dr["DESCRIPCION_ARTICULOS"].ToString();
                                ocampoEnt.DESCRIPCION_ENCISOS = dr["DESCRIPCION_ENCISOS"].ToString();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESCRIPCION_ESPECIE = dr["DESCRIPCION_ESPECIE"].ToString();
                                ocampoEnt.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoEnt.AREA = Decimal.Parse(dr["AREA"].ToString());
                                ocampoEnt.NUMERO_INDIVIDUOS = Int32.Parse(dr["NUMERO_INDIVIDUOS"].ToString());
                                ocampoEnt.DESCRIPCION_INFRACCIONES = dr["DESCRIPCION_INFRACCIONES"].ToString();
                                ocampoEnt.NUM_POA = dr["NUM_POA"].ToString();
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();

                                if (oCEntidad.BusValor == "INICIO_PAU")
                                {
                                    ocampoEnt.COD_SECUENCIAL = 0;
                                }
                                else if (oCEntidad.BusValor == "TERMINO_PAU" || oCEntidad.BusValor == "TERMINO_PAU_TFFS")
                                {
                                    ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    ocampoEnt.DETERMINACION = "No Evaluado";
                                    ocampoEnt.DESCRIPCION_INFRACCIONES = "";
                                    ocampoEnt.RegEstado = 1;
                                    ocampoEnt.BTN_LITERALES = false;
                                    ocampoEnt.BTN_LITERALES2 = true;

                                    if (oCEntidad.BusValor == "TERMINO_PAU_TFFS")
                                    {
                                        ocampoEnt.COD_FCTIPO = dr["COD_FCTIPO"].ToString();
                                        ocampoEnt.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                        ocampoEnt.MAE_ESTDETERMINA_ART363I = "0000000";
                                        ocampoEnt.ESTDETERMINA_ART363I = "No Evaluado";
                                    }
                                }
                                //ocampoEnt.RegEstado = 1;
                                lsCEntidad.Add(ocampoEnt);
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
        public Tra_M_Tramite_tffs ConsultarTramite(OracleConnection cn, string tramite)
        {
            Tra_M_Tramite_tffs data = new Tra_M_Tramite_tffs();
            try
            {
                using (OracleCommand cm = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.SPRESOLUCION_TFFS_BUSCAR_EXPEDIENTE", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("cCodificacion", tramite);
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr == null) return data;
                        if (!dr.HasRows) return data;
                        while (dr.Read())
                        {
                            data.iCodTramite = dr["iCodTramite"].ToString();
                            if (data.iCodTramite == "0")
                            {
                                data.cCodificacion = " ";
                                data.fFecDocumento = " ";
                                data.cNroDocumento = " ";
                                data.cAsunto = " ";
                            }
                            else
                            {
                                data.cCodificacion = dr["cCodificacion"].ToString();
                                data.fFecDocumento = dr["fFecDocumento"].ToString();
                                data.fFecDocumento = data.fFecDocumento.Substring(0,10);
                                data.cNroDocumento = dr["cNroDocumento"].ToString();
                                data.cAsunto = dr["cAsunto"].ToString();
                            }

                        }
                    }
                }
            }
            catch (Exception e) { throw (e); };
            return data;
        }
    }


}
