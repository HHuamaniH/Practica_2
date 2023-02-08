using CapaDatos.Documento;
using CapaEntidad.DOC;
using CapaEntidad.Documento;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Linq;

namespace CapaLogica.Doc
{
    public class Log_SeguimientoMuestra
    {
        public VM_SeguimientoMuestra AddEditInit(string codSegMuestra, string codUsuarioCuenta, string VALIAS_ROL = null)
        {
            VM_SeguimientoMuestra vm;
            Ent_BUSQUEDA objBusqueda = new Ent_BUSQUEDA() { BusFormulario = "GENERAL", BusValor = VALIAS_ROL, COD_UCUENTA = codUsuarioCuenta };
            Log_BUSQUEDA oCLogicaBusqueda = new Log_BUSQUEDA();
            objBusqueda = oCLogicaBusqueda.RegMostCombo(objBusqueda);
            List<VM_Cbo> listIndicador = objBusqueda.ListIndicador.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();

            if (string.IsNullOrEmpty(codSegMuestra))
            {
                //nuevo
                vm = new VM_SeguimientoMuestra();
                vm.ddlODRegistro = objBusqueda.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vm.ddlItemIndicador = listIndicador;
                vm.lblTituloEstado = "Nuevo Registro";
                vm.hdEstado = 1;
                vm.id = "";
            }
            else
            {
                //editar
                Dat_SeguimientoMuestra dat = new Dat_SeguimientoMuestra();
                Ent_Seguimiento_Muestra ent = new Ent_Seguimiento_Muestra();
                ent.COD_SEG_MUESTRA = codSegMuestra;
                ent.BusCriterio = "SEGUIMIENTO";
                //obteniendo datos a modificar
                vm = dat.GetSeguimientoCabecera(ent);
                vm.ddlODRegistro = objBusqueda.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vm.ddlItemIndicador = listIndicador;
                vm.lblTituloEstado = "Modificando Registro";
                vm.hdEstado = 0;
            }
            return vm;
        }
        public ListResult AddEditSeguimientoCabecera(VM_SeguimientoMuestra vm, string codUsuarioCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_Seguimiento_Muestra ent = new Ent_Seguimiento_Muestra();
                Dat_SeguimientoMuestra dat = new Dat_SeguimientoMuestra();
                ent.COD_SEG_MUESTRA = string.IsNullOrEmpty(vm.id) ? "" : vm.id.Trim();
                ent.RegEstado = vm.hdEstado;
                ent.COD_INFORME = vm.codSupervision;
                ent.COD_TRAMITE_ENVIO = string.IsNullOrEmpty(vm.codTramiteEnvio) ? (int?)null : Convert.ToInt32(vm.codTramiteEnvio);
                ent.COD_TRAMITE_RESPUESTA = string.IsNullOrEmpty(vm.codTramiteRespuesta) ? (int?)null : Convert.ToInt32(vm.codTramiteRespuesta);
                ent.COD_OD_REGISTRO = vm.ddlODRegistroId;
                ent.COD_UCUENTA = codUsuarioCuenta;
                ent.OBSERVACION = string.IsNullOrEmpty(vm.observacion) ? null : vm.observacion.Trim();
                //cotrol de calidad
                ent.COD_ESTADO_DOC = vm.ddlItemIndicadorId;
                ent.OBSERVACIONES_CONTROL = vm.obsCalidad;
                ent.OBSERV_SUBSANAR = vm.obsSubsanar;
                ent.OUTPUTPARAM01 = "";
                ent.OUTPUTPARAM01 = dat.SaveSeguimientoCabecera(ent);
                result.success = true;
                result.msj = ent.RegEstado == 1 ? "Se registro correctamente la información" : "Se modifico correctamente la información";
                result.values = new List<string>();
                result.values.Add(ent.OUTPUTPARAM01);
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public VM_SeguimientoMuestraDetalle AddEditMuestraInit(string codSeguimientoMuestra, int secuencial)
        {
            VM_SeguimientoMuestraDetalle vm;
            if (secuencial == 0)
            {

                Ent_BUSQUEDA objBusqueda = new Ent_BUSQUEDA() { BusFormulario = "SEGUIMIENTO_MUESTRA" };
                Dat_SeguimientoMuestra dat = new Dat_SeguimientoMuestra();
                vm = dat.GetDatosCaracteristicas(objBusqueda);
                vm.fotos = new List<VM_ArchivoMuestra>();
                vm.titulo = "Muestra - Nuevo Registro";
                vm.estado = 1;
                vm.secuencial = 0;
                vm.codEspecie = "00000";
                vm.codSeguimiento = codSeguimientoMuestra;
                vm.codSecuencialCenso = 0;
                vm.esMaderable = 0;
            }
            else
            {
                Dat_SeguimientoMuestra dat = new Dat_SeguimientoMuestra();
                Ent_Seguimiento_Muestra ent = new Ent_Seguimiento_Muestra();
                ent.COD_SEG_MUESTRA = codSeguimientoMuestra;
                ent.COD_SECUENCIAL = secuencial;
                ent.BusCriterio = "SEGUIMIENTO_MUESTRA";
                vm = dat.GetSeguimienDetalle(ent);
                vm.titulo = "Muestra - Modificando Registro";
                vm.estado = 0;
            }
            return vm;
        }
        public List<Dictionary<string, string>> GetListSeguimientoDetalle(string codSeguimientoMuestra)
        {
            Dat_SeguimientoMuestra dat = new Dat_SeguimientoMuestra();
            Ent_Seguimiento_Muestra ent = new Ent_Seguimiento_Muestra();
            ent.COD_SEG_MUESTRA = codSeguimientoMuestra;
            ent.BusCriterio = "SEGUIMIENTO_MUESTRA_LISTAR";
            return dat.GetListSeguimientoDetalle(ent);
        }
        public string ObtenerCaracteristicaId(string codigo)
        {
            if (codigo == "0000000")
                return null;
            else return codigo;
        }
        public ListResult AddEditSeguimientoDetalle(VM_SeguimientoMuestraDetalle vm, string codUsuarioCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_Seguimiento_Muestra_Detalle ent = new Ent_Seguimiento_Muestra_Detalle();
                ent.RegEstado = vm.estado; //0 modificar - 1 nuevo
                ent.COD_SEG_MUESTRA = vm.codSeguimiento;
                ent.COD_SECUENCIAL = vm.secuencial;
                ent.COD_MUESTRA = vm.codMuestra;
                ent.ZONAUTM = vm.Z_UTMId;
                ent.COORDENADA_ESTE = Convert.ToInt32(vm.C_ESTE);
                ent.COORDENADA_NORTE = Convert.ToInt32(vm.C_NORTE);
                ent.SECTOR = vm.SECTOR;
                ent.FECHA_COLECCION =Convert.ToDateTime(vm.fColeccion);
                ent.OBSERVACION = string.IsNullOrEmpty(vm.obs) ? null : vm.obs.Trim();
                ent.NUM_POA = vm.idPoa;
                ent.COD_CENSO = vm.ddlCensoId;
                ent.COD_UCUENTA = codUsuarioCuenta;
                ent.ESPECIE_IDENTIFICADO = vm.especieIdent;
                ent.COD_ESPECIES = vm.especieIdent == true ? vm.codEspecie : null;
                ent.OUTPUTPARAMDET01 = "";
                //otras caracteristicas
                ent.C_FFuste = this.ObtenerCaracteristicaId(vm.cboFFusteId);
                ent.C_TRAMIFICACION = this.ObtenerCaracteristicaId(vm.cboTRamificacionId);
                ent.C_TRAICES = this.ObtenerCaracteristicaId(vm.cboTRaicesId);
                ent.C_CECOLOR = this.ObtenerCaracteristicaId(vm.cboCEColorId);
                ent.C_CELENTICELAS = this.ObtenerCaracteristicaId(vm.cboCELenticelasId);
                ent.C_CERITIDOMA = this.ObtenerCaracteristicaId(vm.cboCERitidomaId);
                ent.C_CEOTRAS_ESTRUCTURAS = this.ObtenerCaracteristicaId(vm.cboCEOExtructuraId);
                ent.C_CICOLOR = vm.cortezaiColor;
                ent.C_CIOLOR = vm.cortezaiOlor;
                ent.C_CI_EXU_TIPO = this.ObtenerCaracteristicaId(vm.cboCIETipoId);
                ent.C_CI_EXU_COLOR = this.ObtenerCaracteristicaId(vm.cboCIEColorId);
                ent.C_CI_EXU_OLOR = this.ObtenerCaracteristicaId(vm.cortezaiExuOlor);
                ent.C_CI_EXU_SABOR = this.ObtenerCaracteristicaId(vm.cboCIESaborId);
                ent.C_CI_EXU_ABUNDANCIA = this.ObtenerCaracteristicaId(vm.cboCIEAbundanciaId);
                ent.C_CI_EXU_OTRA_CARACT = vm.otrasCaracteristica;
                ent.C_CI_TIPO = this.ObtenerCaracteristicaId(vm.cboCITipoId);
                ent.C_IFUSTE_ESPINAS = this.ObtenerCaracteristicaId(vm.cboIFEspinasId);
                ent.C_IFUSTE_AGUIJONES = this.ObtenerCaracteristicaId(vm.cboIFAguijonesId);
                ent.C_IFUSTE_OTRAS_ESTRUCTURAS = vm.otrasEstructuras;
                ent.C_HABITO_ARBOL = vm.habitoArbol;
                ent.C_HOJA_SIMPLE = vm.chkHSimple;
                ent.C_HOJA_COMPUESTA = vm.chkHCompuesta;
                ent.C_HOJA_FORMA = this.ObtenerCaracteristicaId(vm.cboHojaFormaId);
                ent.C_HOJA_BORDE = this.ObtenerCaracteristicaId(vm.cboHojaBordeId);
                ent.C_HOJA_DISPOSICION = this.ObtenerCaracteristicaId(vm.cboHojaLaminaId);
                ent.C_FLORES_COLOR = this.ObtenerCaracteristicaId(vm.cboFloresColorId);
                ent.C_FLORES_TAMAÑO = vm.floresTamaño;
                ent.C_FLORES_SIMPLE = vm.chkFSimple;
                ent.C_FLORES_INFLORESCENCIA = vm.chkFInflorescencia;
                ent.C_FLORES_OTRA_CARACT = vm.floresOtrasCaract;
                ent.C_FRUTOS_TIPO = this.ObtenerCaracteristicaId(vm.cboFrutosTipoId);
                ent.C_FRUTOS_COLOR = this.ObtenerCaracteristicaId(vm.cboFrutosColorId);
                ent.C_FRUTOS_TAMANIO = vm.frutosTamanio;
                ent.C_FRUTOS_OTRA_CARACT = vm.frutosOtrasCaract;
                ent.COD_SECUENCIAL_CENSO = vm.codSecuencialCenso == 0 ? (Int32?)null : vm.codSecuencialCenso;
                ent.ESMADERABLE = vm.esMaderable == 0 ? (bool?)null : true;
                ent.COD_COLECTOR = vm.colectorId;
                ent.COD_SUPERVISOR = vm.supervisorId;
                if (vm.fotos != null)
                {   //nuevas fotos
                    ent.fotos = new List<Ent_SEG_MUESTRA_DETALLE_ARCHIVO>();
                    foreach (var item in vm.fotos)
                    {
                        ent.fotos.Add(new Ent_SEG_MUESTRA_DETALLE_ARCHIVO()
                        {
                            COD_SEG_MUESTRA = ent.COD_SEG_MUESTRA,
                            COD_SECUENCIAL_ARCHIVO = 0,
                            NOMBRE_ARCH = item.archivo,
                            EXTENSION_ARCH = item.ext,
                            fname = item.generado,
                            COD_UCUENTA = codUsuarioCuenta,
                            OUTPUTPARAMDET01 = "",
                            RegEstado = 1
                        });
                    }
                }
                if (vm.fotosDelete != null)
                {   //nuevas fotos
                    ent.fotosEli = new List<Ent_SEG_MUESTRA_DETALLE_ARCHIVO>();
                    foreach (var item in vm.fotosDelete)
                    {
                        ent.fotosEli.Add(new Ent_SEG_MUESTRA_DETALLE_ARCHIVO()
                        {
                            COD_SEG_MUESTRA = ent.COD_SEG_MUESTRA,
                            COD_SECUENCIAL = ent.COD_SECUENCIAL,
                            COD_SECUENCIAL_ARCHIVO = item.secuencial,
                            NOMBRE_ARCH = item.archivo,
                            EXTENSION_ARCH = item.ext,
                            fname = "",
                            COD_UCUENTA = codUsuarioCuenta,
                            RegEstado = 0,
                            OUTPUTPARAMDET01 = ""
                        });
                    }
                }
                Dat_SeguimientoMuestra dat = new Dat_SeguimientoMuestra();
                dat.SaveSeguimientoMuestra(ent);
                result.success = true;
                result.msj = ent.RegEstado == 0 ? "Se modifico correctamente la muestra" : "Se registro correctamente la muestra";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public ListResult DeleteSeguimientoDetalle(List<VM_SeguimientoMuestraDetalle> lstVm, string codUsuarioCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                List<Ent_Seguimiento_Muestra_Detalle> lstEntEli = new List<Ent_Seguimiento_Muestra_Detalle>();
                int cantidadItem = 0;
                if (lstVm != null)
                {
                    Ent_Seguimiento_Muestra_Detalle ent;
                    foreach (var vm in lstVm)
                    {
                        ent = new Ent_Seguimiento_Muestra_Detalle();
                        ent.RegEstado = 2;//eliminar
                        ent.COD_SEG_MUESTRA = vm.codSeguimiento;
                        ent.COD_SECUENCIAL = vm.secuencial;
                        ent.COD_MUESTRA = "";
                        ent.ZONAUTM = "";
                        ent.COORDENADA_ESTE = 0;
                        ent.COORDENADA_NORTE = 0;
                        ent.FECHA_COLECCION = DateTime.Now;
                        ent.COD_UCUENTA = codUsuarioCuenta;
                        ent.OUTPUTPARAMDET01 = "";
                        lstEntEli.Add(ent);
                        cantidadItem = cantidadItem + 1;
                    }
                }
                else throw new Exception("No selecciono items a eliminar");
                Dat_SeguimientoMuestra dat = new Dat_SeguimientoMuestra();
                dat.DeleteSeguimientoMuestra(lstEntEli);
                result.success = true;
                result.msj = cantidadItem == 1 ? "Se elimino correctamente la muestra seleccionada" : "Se elimino correctamente las muestras";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public List<VM_SeguimientoMuestra> reporteDendrenales()
        {
            List<VM_SeguimientoMuestra> lista;
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    Dat_SeguimientoMuestra dat = new Dat_SeguimientoMuestra();
                    lista = dat.reporteDendrenales(cn);
                }


            }
            catch (Exception)
            {
                lista = new List<VM_SeguimientoMuestra>();
            }
            return lista;
        }
    }
}
