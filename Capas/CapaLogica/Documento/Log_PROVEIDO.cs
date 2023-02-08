using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//using System.Data.SqlClient;
using System.IO;
using System.Web;
using CDatos = CapaDatos.DOC.Dat_PROVEIDO;
using CEntidad = CapaEntidad.DOC.Ent_PROVEIDO;
namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_PROVEIDO
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarPROVEIDO_Buscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarPROVEIDO_Buscar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CEntidad RegMostCombo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String RegProveido_Grabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabaRegPROVEIDO(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaProveidoItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaProveidoItem(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///migracion 05/11/2020
        ///
        public VM_ProveidoElevacion init(string asCodigo)
        {
            VM_ProveidoElevacion vm = new VM_ProveidoElevacion();
            try
            {
                if (String.IsNullOrEmpty(asCodigo))
                {
                    //nuevo;
                    vm.hdcodigo = asCodigo;
                    vm.RegEstado = 0;
                    vm.lblItemTitulo = "Nuevo Registro";
                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = "0000000";
                    vm.ListInformes = new List<CEntidad>();
                    vm.RegEstado = 1;
                    this.initCombos(vm);

                }
                else
                {
                    //Verificando Estado Session
                    //Cargando datos
                    CEntidad oCampos = new CEntidad();
                    oCampos.COD_PROVEIDO = asCodigo;
                    vm.hdcodigo = asCodigo;
                    vm.RegEstado = 0;
                    vm.lblItemTitulo = "Modificando Registro";
                    oCampos = this.RegMostrarListaProveidoItem(oCampos);

                    //    //
                    vm.txtIdOficina = oCampos.COD_DLINEA;

                    vm.hdfFuncionarioCodigo = oCampos.COD_FDERIVA;
                    vm.txtFuncionario = oCampos.FUNCIONARIO;
                    vm.hsfProfesionalCodigo = oCampos.COD_PDERIVA;
                    vm.txtProfesional = oCampos.PROFESIONAL;

                    vm.txtFechaDerivacion = oCampos.FECHA_DERIVACION.ToString();
                    vm.txtObservacion = oCampos.OBSERVACIONES;
                    vm.txtIdOD = oCampos.COD_OD_REGISTRO;

                    try
                    {
                        vm.txtIdDerivadoPara = oCampos.COD_FCTIPO;
                        vm.txtDerivadopara = "";
                    }
                    catch (Exception)
                    {
                        vm.txtDerivadopara = oCampos.FCTIPO;

                    }

                    //Session["listadoinformes"] = oCEntProveido.ListInformes;
                    vm.ListInformes = oCampos.ListInformes;

                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = oCampos.COD_ESTADO_DOC;
                    vm.vmControlCalidad.txtUsuarioRegistro = oCampos.USUARIO_REGISTRO;
                    vm.vmControlCalidad.txtUsuarioControl = oCampos.USUARIO_CONTROL;
                    vm.vmControlCalidad.chkObsSubsanada = (bool)oCampos.OBSERV_SUBSANAR;
                    vm.vmControlCalidad.txtControlCalidadObservaciones = oCampos.OBSERVACIONES_CONTROL.ToString();

                    this.initCombos(vm);

                }
            }
            catch (Exception)
            {
         
            }
            return vm;
        }

        public void initCombos(VM_ProveidoElevacion vm)
        {
            CEntidad oCampos2 = new CEntidad();
            oCampos2.BusFormulario = "PROVEIDO_ELEVACION";
            oCampos2 = this.RegMostCombo(oCampos2);
            vm.ListODs = oCampos2.ListODs;
            vm.ListDirecionLinea = oCampos2.ListDirecionLinea;
            vm.ListDerivadopara = oCampos2.ListDerivadopara;
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo = new Ent_SBusqueda();
            vm.sBusqueda = new List<Ent_SBusqueda>();

            listCombo = new List<Ent_SBusqueda>();
            Combo = new Ent_SBusqueda();
            Combo.Value = "EXPADM_NUMERO";
            Combo.Text = "Expediente Administrativo";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "INF_NUMERO";
            Combo.Text = "Informe de Superv., Supen., Cancela., Técnicos, Acompañamiento u OSINFOR-INRENA";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "IAF_NUMERO";
            Combo.Text = "Informe Aut.Forestal";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "IT_EVALUACION_C";
            Combo.Text = "Informe Técnico de evaluación de medidas correctivas";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "IT_VERIFICACION_C";
            Combo.Text = " Informe Técnico de verificación de medidas correctivas";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "IT_VERIFICACION_M";
            Combo.Text = "Informe Técnico de verificación de mandatos";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "IT_EVLUACION_M";
            Combo.Text = "Informe Técnico de evaluación de mandatos";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "INF_QUINQ";
            Combo.Text = "Nro Informe Quinquenal";
            listCombo.Add(Combo);
            vm.sBusqueda = listCombo;
        }

        private void ValidarDatos(VM_ProveidoElevacion _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            //txtIdOficina
            //if (string.IsNullOrEmpty(_dto.txtFechaEmision)) throw new Exception("Seleccione la fecha de emisión");
            if (_dto.ListInformes == null) throw new Exception("Seleccione un informe, expediente");
            if (_dto.txtIdOficina == "0000000") throw new Exception("Seleccione un Oficina de origen");
            if (_dto.txtIdDerivadoPara == "0000000") throw new Exception("Seleccione motivo de derivacion");
            if (_dto.hdfFuncionarioCodigo == null) throw new Exception("Seleccione Profesional que deriva");
            if (_dto.hsfProfesionalCodigo == null) throw new Exception("Seleccione Profesional a quien se le deriva");
            if (_dto.txtIdOD == "0000000") throw new Exception("Seleccione Oficina Desconsentrada");
        }

        public ListResult GuardarDatos(VM_ProveidoElevacion _dto, string codCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                this.ValidarDatos(_dto);
                CEntidad oCEntProveido = new CEntidad();

                oCEntProveido.COD_UCUENTA = codCuenta;

                oCEntProveido.COD_PROVEIDO = _dto.hdcodigo;
                oCEntProveido.COD_DLINEA = _dto.txtIdOficina;
                oCEntProveido.OBSERVACIONES = _dto.txtObservacion;
                if (_dto.txtFechaDerivacion != null)
                {
                    if (_dto.txtFechaDerivacion.Trim() != "")
                    {
                        oCEntProveido.FECHA_DERIVACION = Convert.ToDateTime(_dto.txtFechaDerivacion);
                    }
                }
                oCEntProveido.COD_PDERIVA = _dto.hsfProfesionalCodigo;
                oCEntProveido.PROFESIONAL = null;
                oCEntProveido.FUNCIONARIO = null;
                oCEntProveido.COD_FDERIVA = _dto.hdfFuncionarioCodigo;
                //oCEntProveido.FECHA_CREACION = "";
                oCEntProveido.COD_OD_REGISTRO = _dto.txtIdOD;
                oCEntProveido.COD_FCTIPO = _dto.txtIdDerivadoPara;

                oCEntProveido.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                oCEntProveido.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                oCEntProveido.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;

                /*  
                  oCEntProveido.USUARIO_CONTROL = null;
                  oCEntProveido.USUARIO_REGISTRO = null;
                  */
                oCEntProveido.OUTPUTPARAM01 = "";
                oCEntProveido.RegEstado = _dto.RegEstado;
                oCEntProveido.ListInformes = _dto.ListInformes;
                oCEntProveido.ListEliTABLA = _dto.listEliTabla;

                var estado_final = this.RegProveido_Grabar(oCEntProveido);

                result.AddResultado("Proveido se Guardo Correctamente", true);

            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public List<Dictionary<string, string>> registroUsuarioProv(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegistroUsuarios(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ListResult RegistroUsuario(string asCodUsuario)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                //CLogica exeCap = new CLogica();
                paramCap.BusFormulario = "REGISTRO_USUARIO";
                paramCap.BusCriterio = "PROVEIDO_ELEVACION";
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = registroUsuarioProv(paramCap);

                // if (olResult.Count > 0)
                //  {
                string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = rutaBase + nombreFile;
                string rutaExcelBase = rutaBase + "PROVEIDONOTAE_REG.xlsx";

                try
                {
                    File.Delete(@rutaExcel);
                    File.Copy(@rutaExcelBase, @rutaExcel);
                }
                catch (IOException ix)
                {
                    throw new Exception(ix.Message);
                }

                //Creamos la cadena de conexión con el fichero excel
                OleDbConnectionStringBuilder cb = new OleDbConnectionStringBuilder();
                cb.DataSource = rutaExcel;
                if (Path.GetExtension(rutaExcel).ToUpper() == ".XLS")
                {
                    cb.Provider = "Microsoft.Jet.OLEDB.4.0";
                    cb.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=0;");
                }
                else if (Path.GetExtension(rutaExcel).ToUpper() == ".XLSX")
                {
                    cb.Provider = "Microsoft.ACE.OLEDB.12.0";
                    cb.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=0;");
                }

                using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
                {
                    string insertar = "";
                    int i = 1, ind = 1;
                    //Abrimos la conexión
                    conn.Open();
                    //Creamos la ficha
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        //Construyendo las Cabeceras
                        foreach (var itemPart in olResult)
                        {
                            insertar = "'" + (ind++).ToString() + "'";
                            insertar = insertar + ",'" + (itemPart["FECHA"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["CODIGO"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["DIRECCION_LINEA"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["FUNCIONARIO"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["PROFESIONAL"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["FECHA_DERIVACION"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["NUM_THABILITANTE"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["TITULAR"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["DOCUMENTO"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["NUM_RESOLUCION_TER"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["ESTADO_PAU_INTERNO"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["INFORME"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["TIPO_DERIVACION"] ?? "") + "'";
                            insertar = insertar + ",'" + (itemPart["USUARIO"] ?? "") + "'";

                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (olResult.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                            cmd.ExecuteNonQuery();
                        }

                        //Cerramos la conexión
                        conn.Close();
                    }
                }

                result.success = true;
                result.msj = nombreFile;
                //}
                // else 
                //{
                //throw new Exception("No se encontraron registros"); 
                //}
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }


    }
}
