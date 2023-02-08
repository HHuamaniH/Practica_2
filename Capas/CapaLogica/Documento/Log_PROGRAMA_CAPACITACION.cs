using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client; //using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_PROGRAMA_CAPACITACION;
using CEntidad = CapaEntidad.DOC.Ent_PROGRAMA_CAPACITACION;
using System.Data;

namespace CapaLogica.DOC//9
{
    public class Log_PROGRAMA_CAPACITACION
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItems(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegMostrarProgramacionCapacitacionesResumen(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarProgramacionCapacitacionesResumen(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegMostrarProgramacionCapacitacionesDetalle(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarProgramacionCapacitacionesDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*########################## SIGOsfc v3 ##############################*/
        #region SIGOsfc v3
        public VM_ProgramaCapacitacion IniDatosPCapacitacion(string asCodPCapacitacion, string asCodUCuenta)
        {
            VM_ProgramaCapacitacion VM_PC = new VM_ProgramaCapacitacion();

            try
            {
                VM_PC.lblTituloCabecera = "Programación de Capacitaciones";

                //Cargar las listas de selección (combos)
                CEntidad entProgCap = new CEntidad();
                entProgCap.BusFormulario = "PROGRAMA_CAPACITACION";
                entProgCap.COD_UCUENTA = asCodUCuenta;
                entProgCap = RegMostCombo(entProgCap);
                VM_PC.ddlTipPCapacitacion = entProgCap.ListMComboTipoCapacitacion.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_PC.ddlOd = entProgCap.ListMComboOD.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_PC.ddlEntFinancia = entProgCap.ListMComboEntidadFinancia.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_PC.ddlConvenio = entProgCap.ListMComboConvenios.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION, Group = i.GRUPO });

                if (String.IsNullOrEmpty(asCodPCapacitacion))
                {
                    VM_PC.lblTituloEstado = "Nuevo Registro";
                }
                else
                {
                    entProgCap = new CEntidad();
                    entProgCap.COD_PCAPACITACION = asCodPCapacitacion;
                    entProgCap = RegMostrarListaItems(entProgCap);

                    VM_PC.lblTituloEstado = "Modificando Registro";
                    VM_PC.hdfCodPCapacitacion = entProgCap.COD_PCAPACITACION;
                    VM_PC.txtNomPCapacitacion = entProgCap.NOMBRE;
                    VM_PC.ddlTipPCapacitacionId = entProgCap.COD_CAPATIPO;
                    VM_PC.ddlOdId = entProgCap.COD_OD;
                    VM_PC.ddlSumMetPoiId = (bool)entProgCap.SUMA_POI == true ? "1" : "0";
                    VM_PC.txtFecInicio = entProgCap.FECHA_INICIO.ToString();
                    VM_PC.txtDirigido = entProgCap.DIRIGIDO;
                    VM_PC.ddlEntFinanciaId = entProgCap.MAE_ENT_FINANCIA;
                    VM_PC.txtFueCooperante = entProgCap.FUENTE_COOPERANTE;
                    VM_PC.chkMarConvenio = (bool)entProgCap.MARCO_CONVENIO;
                    VM_PC.hdfUbigeo = entProgCap.COD_UBIGEO;
                    VM_PC.lblUbigeo = entProgCap.UBIGEO_DESCRIPCION;
                    VM_PC.txtLugar = entProgCap.LUGAR;
                    VM_PC.hdfRegEstado = 0;
                    VM_PC.ddlConvenioId = string.Join(",", entProgCap.ListCapacitacionConvenios.Select(i => i.COD_MARCO_CONVENIO).ToArray());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return VM_PC;
        }

        public ListResult GuardarDatosPCapacitacion(VM_ProgramaCapacitacion _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                ValidarDatosPCapacitacion(_dto);

                CEntidad paramsPCap = new CEntidad();
                paramsPCap.COD_PCAPACITACION = _dto.hdfCodPCapacitacion ?? "";
                paramsPCap.NOMBRE = _dto.txtNomPCapacitacion;
                paramsPCap.COD_CAPATIPO = _dto.ddlTipPCapacitacionId;
                paramsPCap.COD_OD = _dto.ddlOdId;
                paramsPCap.SUMA_POI = _dto.ddlSumMetPoiId == "1" ? true : false;
                paramsPCap.FECHA_INICIO = Convert.ToDateTime(_dto.txtFecInicio);
                paramsPCap.DIRIGIDO = _dto.txtDirigido ?? "";
                paramsPCap.MAE_ENT_FINANCIA = _dto.ddlEntFinanciaId;
                paramsPCap.FUENTE_COOPERANTE = paramsPCap.MAE_ENT_FINANCIA == "0000038" ? (_dto.txtFueCooperante ?? "") : "";
                paramsPCap.MARCO_CONVENIO = _dto.chkMarConvenio;
                paramsPCap.ListCapacitacionConvenios = new List<CEntidad>();
                if ((bool)paramsPCap.MARCO_CONVENIO && (_dto.ddlConvenioId ?? "") != "")
                {
                    string[] lstConvenio = _dto.ddlConvenioId.Split(',');
                    for (int i = 0; i < lstConvenio.Length; i++)
                    {
                        paramsPCap.ListCapacitacionConvenios.Add(new CEntidad() { COD_MARCO_CONVENIO = lstConvenio[i].ToString() });
                    }
                }
                paramsPCap.COD_UBIGEO = _dto.hdfUbigeo;
                paramsPCap.LUGAR = _dto.txtLugar ?? "";
                paramsPCap.RegEstado = _dto.hdfRegEstado;
                paramsPCap.COD_UCUENTA = asCodUCuenta;
                paramsPCap.OUTPUTPARAM01 = "";

                RegGrabar(paramsPCap);

                string msjRespuesta = _dto.hdfRegEstado == 1 ? "El Registro se Guardo Correctamente" : "El Registro se Modifico Correctamente";
                result.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
        private void ValidarDatosPCapacitacion(VM_ProgramaCapacitacion _dto)
        {
            if (string.IsNullOrEmpty(_dto.txtNomPCapacitacion)) throw new Exception("Ingrese el nombre de la capacitación programada");
            if (_dto.ddlTipPCapacitacionId == "0000000") throw new Exception("Seleccione el tipo de capacitación");
            if (_dto.ddlOdId == "0000000") throw new Exception("Seleccione la oficina desconcentrada");
            if (_dto.ddlSumMetPoiId == "0000000") throw new Exception("Seleccione una opción del campo 'Suma la Meta POI'");
            if (string.IsNullOrEmpty(_dto.txtFecInicio)) throw new Exception("Ingrese la fecha de inicio de la capacitación");
            if (_dto.ddlEntFinanciaId == "0000000") throw new Exception("Seleccione la entidad que financia el taller'");
            if (string.IsNullOrEmpty(_dto.hdfUbigeo)) throw new Exception("Seleccione el ubigeo donde se llevará a cabo la capacitación");
            //if (string.IsNullOrEmpty(_dto.txtLugar)) throw new Exception("Ingrese el lugar donde se llevará a cabo la capacitación");
        }

        public List<Dictionary<string, string>> ReportesProgramaCapacitacion(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReportesProgramaCapacitacion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
