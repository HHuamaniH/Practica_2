using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_MasterFiltro;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_MasterFiltro
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostFiltro(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            int bandera = 0;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListAnios = new List<CEntidad>();
                        oCampos.ListArticulos = new List<CEntidad>();
                        oCampos.ListDLinea = new List<CEntidad>();
                        oCampos.ListDLinea2 = new List<CEntidad>();
                        oCampos.ListEspecies = new List<CEntidad>();
                        oCampos.ListModalidad = new List<CEntidad>();
                        oCampos.ListRegion = new List<CEntidad>();
                        oCampos.ListOD = new List<CEntidad>();
                        oCampos.ListProfesional = new List<CEntidad>();
                        oCampos.ListInstancia = new List<CEntidad>();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //

                        if (oCEntidad.BusValor.Split('|')[0] == "1" || oCEntidad.BusValor.Split('|')[0] == "2" || oCEntidad.BusValor.Split('|')[0] == "3" || oCEntidad.BusValor.Split('|')[0] == "5"
                            || oCEntidad.BusValor.Split('|')[0] == "6" || oCEntidad.BusValor.Split('|')[0] == "7")
                        {
                            //Años     
                            bandera = 1;
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
                            oCampos.ListAnios = lsDetDetalle;
                        }
                        if (oCEntidad.BusValor.Split('|')[1] == "1" || oCEntidad.BusValor.Split('|')[1] == "2" || oCEntidad.BusValor.Split('|')[1] == "3")
                        {
                            //Modalidad
                            if (bandera == 1) { dr.NextResult(); } else { bandera = 1; }
                            lsDetDetalle = new List<CEntidad>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    //PARTE_DIARIO_DETALLE
                                    oCamposDet = new CEntidad();
                                    oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                    oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                    lsDetDetalle.Add(oCamposDet);
                                }
                            }
                            oCampos.ListModalidad = lsDetDetalle;
                        }
                        if (oCEntidad.BusValor.Split('|')[2] == "1" || oCEntidad.BusValor.Split('|')[2] == "2" || oCEntidad.BusValor.Split('|')[2] == "3")
                        {
                            //Region
                            if (bandera == 1) { dr.NextResult(); } else { bandera = 1; }
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
                            oCampos.ListRegion = lsDetDetalle;
                        }
                        if (oCEntidad.BusValor.Split('|')[3] == "1" || oCEntidad.BusValor.Split('|')[3] == "2")
                        {
                            //Articulo
                            if (bandera == 1) { dr.NextResult(); } else { bandera = 1; }
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
                            oCampos.ListArticulos = lsDetDetalle;
                        }
                        switch (oCEntidad.BusValor.Split('|')[4])
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                            case "A":
                            case "B":
                                //Lista Direccion Linea
                                if (bandera == 1) { dr.NextResult(); } else { bandera = 1; }
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
                                oCampos.ListDLinea = lsDetDetalle;
                                break;
                        }
                        if (oCEntidad.BusValor.Split('|')[5] == "1" || oCEntidad.BusValor.Split('|')[5] == "2" || oCEntidad.BusValor.Split('|')[5] == "3" || oCEntidad.BusValor.Split('|')[5] == "4" || oCEntidad.BusValor.Split('|')[5] == "5" || oCEntidad.BusValor.Split('|')[5] == "6")
                        {
                            //Especies
                            if (bandera == 1) { dr.NextResult(); } else { bandera = 1; }
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
                        }
                        if (oCEntidad.BusValor.Split('|')[7] == "1" || oCEntidad.BusValor.Split('|')[7] == "2")
                        {
                            //ODs     
                            if (bandera == 1) { dr.NextResult(); } else { bandera = 1; }
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
                        }
                        if (oCEntidad.BusValor.Split('|')[8] == "1" || oCEntidad.BusValor.Split('|')[8] == "2" || oCEntidad.BusValor.Split('|')[8] == "3")
                        {
                            //Lista Profes
                            if (bandera == 1) { dr.NextResult(); } else { bandera = 1; }
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
                            oCampos.ListProfesional = lsDetDetalle;
                        }
                        switch (oCEntidad.BusValor.Split('|')[9])
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                            case "A":
                            case "B":
                                //Lista Direccion Linea
                                if (bandera == 1) { dr.NextResult(); } else { bandera = 1; }
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
                                oCampos.ListDLinea2 = lsDetDetalle;
                                break;
                        }
                        //if (oCEntidad.BusValor.Split('|')[10] == "1") //jose
                        //{
                        //    //Lista Instancia
                        //    if (bandera == 1) { dr.NextResult(); } else { bandera = 1; }
                        //    lsDetDetalle = new List<CEntidad>();
                        //    if (dr.HasRows)
                        //    {
                        //        while (dr.Read())
                        //        {
                        //            oCamposDet = new CEntidad();
                        //            oCamposDet.CODIGO = dr["CODIGO"].ToString();
                        //            oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                        //            lsDetDetalle.Add(oCamposDet);
                        //        }
                        //    }
                        //    oCampos.ListInstancia = lsDetDetalle;
                        //}
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
