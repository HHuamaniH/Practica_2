using GeneralSQL;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
//using System.Data.OracleClient;  using SQL = GeneralSQL.Data.SQL;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Persona;

namespace CapaDatos.DOC//9
{
    public class Dat_Persona
    {
        private DBOracle dBOracle = new DBOracle(); //private SQL dBOracle = new SQL();

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
                        CEntidad oCamposDet;
                        //Tipo Persona
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
                        oCampos.ListCTipoPersona = lsDetDetalle;
                        dr.NextResult();
                        //Tipo Documento de Identidad
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
                        oCampos.ListCTipoDocIdentidad = lsDetDetalle;
                        dr.NextResult();
                        //Sexo
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
                        oCampos.ListCSexo = lsDetDetalle;
                        dr.NextResult();
                        //Tipo de Teléfono
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
                        oCampos.ListCTipoTelefono = lsDetDetalle;
                        dr.NextResult();
                        //Tipo de Correo
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
                        oCampos.ListCTipoCorreo = lsDetDetalle;
                        dr.NextResult();
                        //Tipo de Cargo
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
                        oCampos.ListCTipoCargo = lsDetDetalle;
                        dr.NextResult();
                        //Nivel Académico
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
                        oCampos.ListCNivelAcademico = lsDetDetalle;
                        dr.NextResult();
                        //Especialidad
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
                        oCampos.ListCEspecialidad = lsDetDetalle;
                        dr.NextResult();
                        //Categoria de Regente
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
                        oCampos.ListCCategoria = lsDetDetalle;
                        dr.NextResult();
                        //Estado de Regente
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
                        oCampos.ListCEstado = lsDetDetalle;
                        dr.NextResult();
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
        public CEntidad RegMostrarListaItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            CEntidad oCamposDet;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.spPERSONAMostrarItem", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListDomicilio = new List<CEntidad>();
                        oCampos.ListEliTABLA = new List<CEntidad>();
                        oCampos.ListTelefono = new List<CEntidad>();
                        oCampos.ListCorreo = new List<CEntidad>();
                        oCampos.ListTipoCargo = new List<CEntidad>();
                        oCampos.ListMencion = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            //Datos Persona
                            dr.Read();
                            oCampos.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                            oCampos.COD_TPERSONA = dr.GetString(dr.GetOrdinal("COD_TPERSONA"));
                            oCampos.COD_DIDENTIDAD = dr.GetString(dr.GetOrdinal("COD_DIDENTIDAD"));
                            oCampos.APE_PATERNO = dr.GetString(dr.GetOrdinal("APE_PATERNO"));
                            oCampos.APE_MATERNO = dr.GetString(dr.GetOrdinal("APE_MATERNO"));
                            oCampos.NOMBRES = dr.GetString(dr.GetOrdinal("NOMBRES"));
                            oCampos.RAZON_SOCIAL = dr.GetString(dr.GetOrdinal("RAZON_SOCIAL"));
                            oCampos.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            oCampos.COD_SEXO = dr.GetString(dr.GetOrdinal("COD_SEXO"));
                            oCampos.N_DOCUMENTO = dr.GetString(dr.GetOrdinal("N_DOCUMENTO"));
                            oCampos.N_RUC = dr.GetString(dr.GetOrdinal("N_RUC"));
                            oCampos.NUM_REGISTRO_FFS = dr.GetString(dr.GetOrdinal("NUM_REGISTRO_FFS"));
                            oCampos.CARGO = dr.GetString(dr.GetOrdinal("CARGO"));
                            oCampos.COD_DPESPECIALIDAD = dr.GetString(dr.GetOrdinal("COD_DPESPECIALIDAD"));
                            oCampos.COD_NACADEMICO = dr.GetString(dr.GetOrdinal("COD_NACADEMICO"));
                            oCampos.COLEGIATURA_NUM = dr.GetString(dr.GetOrdinal("COLEGIATURA_NUM"));
                            oCampos.NUM_REGISTRO_PROFESIONAL = dr.GetString(dr.GetOrdinal("NUM_REGISTRO_PROFESIONAL"));
                            oCampos.NINTERNET = dr.GetInt32(dr.GetOrdinal("NINTERNET"));
                            oCampos.ANIO = dr.GetString(dr.GetOrdinal("ANIO"));
                            oCampos.NROLICENCIA = dr.GetString(dr.GetOrdinal("NROLICENCIA"));
                            oCampos.RESAPROBACION = dr.GetString(dr.GetOrdinal("RESAPROBACION"));
                            oCampos.OTORGAMIENTO = dr.GetString(dr.GetOrdinal("OTORGAMIENTO"));
                            oCampos.COD_CATEGORIA = dr.GetString(dr.GetOrdinal("COD_CATEGORIA"));
                            oCampos.ESTADO_REGENTE = dr.GetString(dr.GetOrdinal("ESTADO_REGENTE"));
                            oCampos.CIP = dr.GetString(dr.GetOrdinal("CIP"));
                            oCampos.OTRO = dr.GetString(dr.GetOrdinal("OTRO"));
                            oCampos.RegEstado = 0;
                            //Detalle Domicilio
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                                    oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    oCamposDet.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
                                    oCamposDet.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                                    oCamposDet.DIRECCION = dr.GetString(dr.GetOrdinal("DIRECCION"));
                                    oCamposDet.DATOS_REFERENCIALES = dr.GetString(dr.GetOrdinal("DATOS_REFERENCIALES"));
                                    oCamposDet.NACTIVO = dr.GetInt32(dr.GetOrdinal("NACTIVO"));
                                    oCamposDet.NACTIVO_NOM = oCamposDet.NACTIVO==1?"Activo":"Inactivo";
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListDomicilio.Add(oCamposDet);
                                }
                            }
                            //Detalle Teléfono
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                                    oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    oCamposDet.COD_TTELEFONO = dr.GetString(dr.GetOrdinal("COD_TTELEFONO"));
                                    oCamposDet.TIPO_TELEFONO = dr.GetString(dr.GetOrdinal("TIPO_TELEFONO"));
                                    oCamposDet.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                                    oCamposDet.ANEXO = dr.GetString(dr.GetOrdinal("ANEXO"));
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListTelefono.Add(oCamposDet);
                                }
                            }
                            //Detalle Correo
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                                    oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    oCamposDet.COD_TCORREO = dr.GetString(dr.GetOrdinal("COD_TCORREO"));
                                    oCamposDet.TIPO_CORREO = dr.GetString(dr.GetOrdinal("TIPO_CORREO"));
                                    oCamposDet.CORREO = dr.GetString(dr.GetOrdinal("CORREO"));
                                    oCamposDet.NOTIFICAR = dr.GetBoolean(dr.GetOrdinal("NOTIFICAR"));
                                    oCamposDet.TXT_NOTIFICAR = (dr.GetBoolean(dr.GetOrdinal("NOTIFICAR")) == true)?"SI":"NO";
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListCorreo.Add(oCamposDet);
                                }
                            }
                            //Detalle Tipo Cargo
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                                    oCamposDet.COD_PTIPO = dr.GetString(dr.GetOrdinal("COD_PTIPO"));
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListTipoCargo.Add(oCamposDet);
                                }
                            }
                            //Detalle Mencion Regencia
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                                    oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    oCamposDet.COD_MENSION = dr.GetString(dr.GetOrdinal("COD_MENSION"));
                                    oCamposDet.MENSION = dr.GetString(dr.GetOrdinal("MENSION"));
                                    oCampos.ListMencion.Add(oCamposDet);
                                }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONAGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    switch (OUTPUTPARAM01)
                    {
                        case "99":
                            tr.Rollback();
                            tr = null;
                            throw new Exception("Ud. no tiene permiso para realizar esta acción");
                        case "0":
                            tr.Rollback();
                            tr = null;
                            throw new Exception("La persona ya existe");
                        case "1":
                            tr.Rollback();
                            tr = null;
                            throw new Exception("La persona ya existe en otro registro");
                        default:
                            break;
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_PERSONA = OUTPUTPARAM01;
                }
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var itemEli in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PERSONA = oCEntidad.COD_PERSONA;
                        oCamposDet.COD_SECUENCIAL = itemEli.COD_SECUENCIAL;

                        oCamposDet.EliTABLA = itemEli.EliTABLA;
                        oCamposDet.EliVALOR01 = itemEli.EliVALOR01;
                        oCamposDet.EliVALOR02 = itemEli.EliVALOR02;
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONAEliminarDetalle", oCamposDet);
                    }
                }
                if (oCEntidad.ListDomicilio != null)
                {
                    foreach (var itemDom in oCEntidad.ListDomicilio)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PERSONA = oCEntidad.COD_PERSONA;
                        oCamposDet.COD_SECUENCIAL = itemDom.COD_SECUENCIAL;
                        oCamposDet.COD_UBIGEO = itemDom.COD_UBIGEO;
                        oCamposDet.DIRECCION = itemDom.DIRECCION;
                        oCamposDet.DATOS_REFERENCIALES = itemDom.DATOS_REFERENCIALES;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.NACTIVO = itemDom.NACTIVO;
                        oCamposDet.RegEstado = itemDom.RegEstado;
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_DET_DOMICILIOGrabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListTelefono != null)
                {
                    foreach (var itemTel in oCEntidad.ListTelefono)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PERSONA = oCEntidad.COD_PERSONA;
                        oCamposDet.COD_SECUENCIAL = itemTel.COD_SECUENCIAL;
                        oCamposDet.COD_TTELEFONO = itemTel.COD_TTELEFONO;
                        oCamposDet.NUMERO = itemTel.NUMERO;
                        oCamposDet.ANEXO = itemTel.ANEXO;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = itemTel.RegEstado;
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_DET_TELEFONOGrabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListCorreo != null)
                {
                    foreach (var itemCor in oCEntidad.ListCorreo)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PERSONA = oCEntidad.COD_PERSONA;
                        oCamposDet.COD_SECUENCIAL = itemCor.COD_SECUENCIAL;
                        oCamposDet.COD_TCORREO = itemCor.COD_TCORREO;
                        oCamposDet.CORREO = itemCor.CORREO;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.NOTIFICAR = itemCor.NOTIFICAR;
                        oCamposDet.RegEstado = itemCor.RegEstado;
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_DET_CORREOGrabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListTipoCargo != null)
                {
                    foreach (var itemCar in oCEntidad.ListTipoCargo)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PERSONA = oCEntidad.COD_PERSONA;
                        oCamposDet.COD_PTIPO = itemCar.COD_PTIPO;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = itemCar.RegEstado;
                        oCamposDet.BusFormulario = "DIRECTORIO_UNICO";
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_DET_TIPOGrabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListMencion != null)
                {
                    foreach (var itemMen in oCEntidad.ListMencion)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PERSONA = oCEntidad.COD_PERSONA;
                        oCamposDet.COD_SECUENCIAL = itemMen.COD_SECUENCIAL;
                        oCamposDet.COD_MENSION = itemMen.COD_MENSION;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = itemMen.RegEstado;
                        oCamposDet.BusFormulario = "DIRECTORIO_UNICO";
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_DET_MENSIONGrabar", oCamposDet);
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
        public Int32 RegEliminar(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "GENE_OSINFOR_ERP_MIGRACION.spPERSONAEliminarDetalle", oCEntidad);

                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String GrabarTipoCargo(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";

            try
            {
                tr = cn.BeginTransaction();
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spPERSONA_TIPOGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;

                    if (OUTPUTPARAM01.Split('|')[0] == "0")
                    {
                        throw new Exception(OUTPUTPARAM01.Split('|')[1]);
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
    }
}
