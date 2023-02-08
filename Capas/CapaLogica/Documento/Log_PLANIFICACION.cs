using CapaDatos.DOC;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaLogica.DOC
{
    public class Log_PLANIFICACION
    {
        private Dat_PLANIFICACION _datPlan;
        Log_BUSQUEDA _logBus;

        public Log_PLANIFICACION()
        {
            _datPlan = new Dat_PLANIFICACION();
            _logBus = new Log_BUSQUEDA();
        }

        #region "PLAN"
        public VM_Plan InitPlan(string asCodPlan)
        {
            VM_Plan vm = new VM_Plan();

            vm.lblTituloCabecera = "PASPEQ";

            if (string.IsNullOrEmpty(asCodPlan)) //Nuevo registro
            {
                vm.lblTituloEstado = "Nuevo registro";
                vm.txtAnioPlan = DateTime.Now.Year + 1;
            }
            else //Modificar registro
            {
                Ent_PLAN entPlan = _datPlan.ObtenerPlan(new Ent_PLAN() { COD_PLAN = asCodPlan });

                vm.lblTituloEstado = "Modificar registro";
                vm.hdfCodPlan = entPlan.COD_PLAN;
                vm.txtAnioPlan = entPlan.ANIO;
                vm.txtFechaCorte = entPlan.FECHA_CORTE.ToString() + " " + entPlan.HORA_CORTE;
                vm.txtNumResolucion = entPlan.NUMERO_RESOLUCION;
                vm.txtFechaEmision = entPlan.FECHA_EMISION.ToString();
                vm.hdfCodFuncionario = entPlan.COD_FUNCIONARIO;
                vm.txtFuncionario = entPlan.FUNCIONARIO;
                vm.txtObservacion = entPlan.OBSERVACION;

                vm.vmControlCalidad.ddlIndicadorId = entPlan.COD_ESTADO_DOC;
                vm.vmControlCalidad.txtUsuarioRegistro = entPlan.USUARIO_REGISTRO;
                vm.vmControlCalidad.txtUsuarioControl = entPlan.USUARIO_CONTROL;
                vm.vmControlCalidad.chkObsSubsanada = (bool)entPlan.OBSERV_SUBSANAR;
                vm.vmControlCalidad.txtControlCalidadObservaciones = entPlan.OBSERVACIONES_CONTROL;
            }

            return vm;
        }

        public ListResult GrabarPlan(VM_Plan vm, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                Ent_PLAN entPlan = new Ent_PLAN();

                entPlan.COD_PLAN = vm.hdfCodPlan ?? "";
                entPlan.ANIO = vm.txtAnioPlan;
                entPlan.NUMERO_RESOLUCION = vm.txtNumResolucion;
                entPlan.FECHA_EMISION = vm.txtFechaEmision;
                entPlan.COD_FUNCIONARIO = vm.hdfCodFuncionario;
                entPlan.OBSERVACION = vm.txtObservacion;
                entPlan.COD_UCUENTA = asCodUCuenta;
                entPlan.COD_ESTADO_DOC = vm.vmControlCalidad.ddlIndicadorId;
                entPlan.OBSERVACIONES_CONTROL = vm.vmControlCalidad.txtControlCalidadObservaciones;
                entPlan.OBSERV_SUBSANAR = vm.vmControlCalidad.chkObsSubsanada;

                _datPlan.GrabarPlan(entPlan);

                result.AddResultado("Los datos del plan se registraron correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
        #endregion

        #region "PLAN_COLABORADOR"
        public ListResult GrabarPlanColaborador(Ent_PLAN_COLABORADOR dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                dto.COD_UCUENTA = asCodUCuenta;
                _datPlan.GrabarPlanColaborador(dto);

                result.AddResultado("Datos registrados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public List<Ent_PLAN_COLABORADOR> ListarPlanColaborador(string asCodPlan)
        {
            return _datPlan.ListarPlanColaborador(new Ent_PLAN_COLABORADOR() { COD_PLAN = asCodPlan });
        }

        public ListResult EliminarPlanColaborador(string asCodPlan, string asCodColaborador)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.EliminarPlanColaborador(new Ent_PLAN_COLABORADOR() { COD_PLAN = asCodPlan, COD_COLABORADOR = asCodColaborador });

                result.AddResultado("Registro eliminado correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
        #endregion

        #region "PLAN_UNIVERSO"
        public VM_PlanUniverso InitPlanUniverso(string asCodPlan)
        {
            VM_PlanUniverso vm = new VM_PlanUniverso();

            vm.lblTituloCabecera = "Universo de títulos habilitantes y planes de manejo";
            vm.lblTituloEstado = "Generar universo";

            if (!string.IsNullOrEmpty(asCodPlan)) //Modificar registro
            {
                Ent_PLAN entPlan = _datPlan.ObtenerPlan(new Ent_PLAN() { COD_PLAN = asCodPlan });

                vm.hdfCodPlan = entPlan.COD_PLAN;
                vm.txtAnioPlan = entPlan.ANIO;
                vm.txtFechaCorte = entPlan.FECHA_CORTE.ToString();
                vm.txtHoraCorte = entPlan.HORA_CORTE;
                vm.hdfPlanCompleto = entPlan.COD_ESTADO_DOC == "0000006" ? true : false;
            }

            return vm;
        }

        public List<Dictionary<string, string>> ListarPlanUniverso(string asCodPlan)
        {
            return _datPlan.ListarPlanUniverso(new Ent_PLAN_UNIVERSO() { COD_PLAN = asCodPlan });
        }

        public ListResult GenerarPlanUniverso(string asCodPlan, string asFechaCorte, string asHoraCorte)
        {
            ListResult result = new ListResult();

            try
            {
                var dd = Convert.ToInt32(asFechaCorte.Split('/')[0]);
                var mm = Convert.ToInt32(asFechaCorte.Split('/')[1]);
                var aaaa = Convert.ToInt32(asFechaCorte.Split('/')[2]);
                var hh = Convert.ToInt32(asHoraCorte.Split(':')[0]);
                var mn = Convert.ToInt32(asHoraCorte.Split(':')[1]);

                DateTime fechaCorte = new DateTime(aaaa, mm, dd, hh, mn, 0);

                Ent_PLAN_UNIVERSO entUniverso = new Ent_PLAN_UNIVERSO()
                {
                    COD_PLAN = asCodPlan,
                    FECHA_CORTE = fechaCorte
                };

                _datPlan.GenerarPlanUniverso(entUniverso);

                result.AddResultado("Universo generado correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult LimpiarPlanUniverso(string asCodPlan)
        {
            ListResult result = new ListResult();

            try
            {
                Ent_PLAN_UNIVERSO entUniverso = new Ent_PLAN_UNIVERSO()
                {
                    COD_PLAN = asCodPlan
                };

                _datPlan.LimpiarPlanUniverso(entUniverso);

                result.AddResultado("Universo eliminado correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult ActualizarPlanUniverso(string asCodPlan)
        {
            ListResult result = new ListResult();

            try
            {
                Ent_PLAN_UNIVERSO entUniverso = new Ent_PLAN_UNIVERSO()
                {
                    COD_PLAN = asCodPlan
                };

                _datPlan.ActualizarPlanUniverso(entUniverso);

                result.AddResultado("Los datos del universo se actualizaron correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
        #endregion

        #region "PLAN_CRITERIO"
        public VM_PlanCriterio InitPlanCriterio(string asCodPCriterio, string asCodPlan)
        {
            VM_PlanCriterio vm = new VM_PlanCriterio();

            vm.lblTituloCabecera = "Criterio de priorización";
            vm.lblTituloEstado = "Nuevo Registro";
            vm.ddlColumna = _logBus.RegMostComboIndividual("PLAN_PCOLUMNA", "");
            vm.ddlTipoAplicacion = _logBus.RegMostComboIndividual("PLAN_TAPLICACION", "");
            vm.ddlTipoCriterio = _logBus.RegMostComboIndividual("PLAN_TCRITERO", "");

            if (!string.IsNullOrEmpty(asCodPCriterio)) //Modificar registro
            {
                Ent_PLAN_CRITERIO entCriterio = _datPlan.ObtenerPlanCriterio(new Ent_PLAN_CRITERIO() { COD_PCRITERIO = asCodPCriterio });

                vm.lblTituloEstado = "Modificar Registro";
                vm.hdfCodCriterio = entCriterio.COD_PCRITERIO;
                vm.hdfCodPlan = entCriterio.COD_PLAN;
                vm.hdfActivo = (bool)entCriterio.ACTIVO;
                vm.ddlColumnaId = entCriterio.COD_PCOLUMNA;
                vm.ddlTipoAplicacionId = entCriterio.COD_TAPLICACION;
                vm.ddlTipoCriterioId = entCriterio.COD_TCRITERIO;
                vm.txtCodigo = entCriterio.CODIGO;
                vm.txtCriterio = entCriterio.PCRITERIO;
                vm.txtDescripcion = entCriterio.DESCRIPCION;
            }
            else //Nuevo registro
            {
                vm.hdfCodPlan = asCodPlan;
            }

            return vm;
        }

        public ListResult GrabarPlanCriterio(VM_PlanCriterio vm, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                if (vm.ddlTipoAplicacionId == "0000003")
                {
                    vm.ddlColumnaId = "0000000";
                }

                Ent_PLAN_CRITERIO entCriterio = new Ent_PLAN_CRITERIO()
                {
                    CODIGO = vm.txtCodigo,
                    COD_PCOLUMNA = vm.ddlColumnaId,
                    COD_PCRITERIO = vm.hdfCodCriterio ?? "",
                    COD_PLAN = vm.hdfCodPlan,
                    COD_TAPLICACION = vm.ddlTipoAplicacionId,
                    COD_TCRITERIO = vm.ddlTipoCriterioId,
                    COD_UCUENTA = asCodUCuenta,
                    DESCRIPCION = vm.txtDescripcion,
                    PCRITERIO = vm.txtCriterio
                };

                string cod_pcriterio = _datPlan.GrabarPlanCriterio(entCriterio);

                result.AddResultado("Datos registrados correctamente", true);
                result.data = cod_pcriterio;
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public List<Ent_PLAN_CRITERIO> ListarPlanCriterio(string asCodPlan)
        {
            return _datPlan.ListarPlanCriterio(new Ent_PLAN_CRITERIO() { COD_PLAN = asCodPlan });
        }

        public ListResult EliminarPlanCriterio(string asCodPlan, string asCodPCriterio)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.EliminarPlanCriterio(new Ent_PLAN_CRITERIO() { COD_PCRITERIO = asCodPCriterio, COD_PLAN = asCodPlan });

                result.AddResultado("Registro eliminado correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult ReplicarPlanCriterio(string asCodPlanBase, string asCodPlan, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.ReplicarPlanCriterio(new Ent_PLAN_CRITERIO() { COD_PLAN_BASE = asCodPlanBase, COD_PLAN = asCodPlan, COD_UCUENTA = asCodUCuenta });

                result.AddResultado("Criterios replicados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
        #endregion

        #region "PLAN_COLUMNA"
        public ListResult ObtenerPlanColumnaTipoDato(string asCodPColumna)
        {
            ListResult result = new ListResult();

            try
            {
                var columna = _datPlan.ObtenerPlanColumna(new Ent_PLAN_COLUMNA() { COD_PCOLUMNA = asCodPColumna });
                result.data = columna.TIPO_DATO;
                result.success = true;
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
        #endregion

        #region "PLAN_CRITERIO_VALOR"
        public VM_PlanCriterioValor InitPlanCriterioValor(string asCodPCriterio, int aiCodSecuencial, string asCodPColumna, string asCodTAplicacion)
        {
            VM_PlanCriterioValor vm = new VM_PlanCriterioValor();

            vm.hdfCodPColumna = asCodPColumna;
            vm.hdfCodTAplicacion = asCodTAplicacion;

            if (aiCodSecuencial == 0) //Nuevo
            {
                vm.hdfCodPCriterio = asCodPCriterio;
                vm.hdfCodSecuencial = aiCodSecuencial;
            }
            else
            {
                Ent_PLAN_CRITERIO_VALOR entValor = _datPlan.ObtenerPlanCriterioValor(new Ent_PLAN_CRITERIO_VALOR() { COD_PCRITERIO = asCodPCriterio, COD_SECUENCIAL = aiCodSecuencial });
                vm.hdfCodPCriterio = entValor.COD_PCRITERIO;
                vm.hdfCodSecuencial = entValor.COD_SECUENCIAL;
                vm.txtOpcionFecha_1 = entValor.OPCION_FECHA_1.ToString();
                vm.txtOpcionFecha_2 = entValor.OPCION_FECHA_2.ToString();
                vm.txtOpcionNumero_1 = entValor.OPCION_NUMERO_1;
                vm.txtOpcionNumero_2 = entValor.OPCION_NUMERO_2;
                vm.txtOpcionTexto_1 = entValor.OPCION_TEXTO_1;
                vm.txtRiesgo = entValor.RIESGO;
                vm.txtValor = entValor.VALOR;
            }

            var opciones = _datPlan.ListarPlanColumnaOpcion(new Ent_PLAN_COLUMNA() { COD_PCRITERIO = asCodPCriterio, COD_PCOLUMNA = asCodPColumna });
            vm.ddlOpcionTexto_1 = opciones.Select(i => new VM_Cbo { Value = i.OPCION, Text = i.OPCION });
            var columna = _datPlan.ObtenerPlanColumna(new Ent_PLAN_COLUMNA() { COD_PCOLUMNA = asCodPColumna });
            vm.hdfTipoDato = columna.TIPO_DATO;
            vm.ddlValorRiesgo = new List<VM_Cbo>() {
                new VM_Cbo() { Value = "0000000", Text = "Seleccionar" }, new VM_Cbo() { Value = "1", Text = "1" }, new VM_Cbo() { Value = "2", Text = "2" }, new VM_Cbo() { Value = "3", Text = "3" }
            };

            return vm;
        }

        public List<Ent_PLAN_CRITERIO_VALOR> ListarPlanCriterioValor(string asCodPCriterio)
        {
            return _datPlan.ListarPlanCriterioValor(new Ent_PLAN_CRITERIO_VALOR() { COD_PCRITERIO = asCodPCriterio });
        }

        public ListResult GrabarPlanCriterioValor(Ent_PLAN_CRITERIO_VALOR dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                dto.COD_UCUENTA = asCodUCuenta;
                _datPlan.GrabarPlanCriterioValor(dto);

                result.AddResultado("Datos registrados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult EliminarPlanCriterioValor(string asCodPCriterio, int aiCodSecuencial)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.EliminarPlanCriterioValor(new Ent_PLAN_CRITERIO_VALOR() { COD_PCRITERIO = asCodPCriterio, COD_SECUENCIAL = aiCodSecuencial });

                result.AddResultado("Registro eliminado correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
        #endregion

        #region "PLAN_CASUISTICA"
        public VM_PlanCasuistica InitPlanCasuistica(string asCodPCasuistica, string asCodPlan)
        {
            VM_PlanCasuistica vm = new VM_PlanCasuistica();

            vm.ddlTipoCriterio = _logBus.RegMostComboIndividual("PLAN_TCRITERO", "");

            if (string.IsNullOrEmpty(asCodPCasuistica)) //Nuevo
            {
                vm.hdfCodCasuistica = asCodPCasuistica;
                vm.hdfCodPlan = asCodPlan;
            }
            else
            {
                Ent_PLAN_CASUISTICA entCaso = _datPlan.ObtenerPlanCasuistica(new Ent_PLAN_CASUISTICA() { COD_PCASUISTICA = asCodPCasuistica });
                vm.hdfCodCasuistica = entCaso.COD_PCASUISTICA;
                vm.hdfCodPlan = entCaso.COD_PLAN;
                vm.ddlTipoCriterioId = entCaso.COD_TCRITERIO;
                vm.txtCasuistica = entCaso.PCASUISTICA;
                vm.txtDescripcion = entCaso.DESCRIPCION;
                vm.txtDescripcionFiltro = entCaso.DESCRIPCION_FILTRO;
            }

            return vm;
        }

        public List<Ent_PLAN_CASUISTICA> ListarPlanCasuistica(string asCodPlan)
        {
            return _datPlan.ListarPlanCasuistica(new Ent_PLAN_CASUISTICA() { COD_PLAN = asCodPlan });
        }

        public ListResult GrabarPlanCasuistica(VM_PlanCasuistica vm, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                Ent_PLAN_CASUISTICA entCaso = new Ent_PLAN_CASUISTICA()
                {
                    COD_PCASUISTICA = vm.hdfCodCasuistica ?? "",
                    COD_PLAN = vm.hdfCodPlan,
                    PCASUISTICA = vm.txtCasuistica,
                    COD_TCRITERIO = vm.ddlTipoCriterioId,
                    DESCRIPCION = vm.txtDescripcion,
                    DESCRIPCION_FILTRO = vm.txtDescripcionFiltro,
                    COD_UCUENTA = asCodUCuenta
                };

                _datPlan.GrabarPlanCasuistica(entCaso);

                result.AddResultado("Datos registrados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult EliminarPlanCasuistica(string asCodPlan, string asCodPCasuistica)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.EliminarPlanCasuistica(new Ent_PLAN_CASUISTICA() { COD_PLAN = asCodPlan, COD_PCASUISTICA = asCodPCasuistica });

                result.AddResultado("Registro eliminado correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
        #endregion

        #region "PLAN_CASUISTICA_CRITERIO"
        public List<Ent_PLAN_CASUISTICA_CRITERIO> ListarPlanCasuisticaCriterio(string asCodPCasuistica, string asCodTCriterio)
        {
            return _datPlan.ListarPlanCasuisticaCriterio(new Ent_PLAN_CASUISTICA_CRITERIO() { COD_PCASUISTICA = asCodPCasuistica, COD_TCRITERIO = asCodTCriterio });
        }

        public ListResult GrabarPlanCasuisticaCriterio(string asCodPCasuistica, string asCodPCriterio, bool abAsignar, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                Ent_PLAN_CASUISTICA_CRITERIO entCaso = new Ent_PLAN_CASUISTICA_CRITERIO()
                {
                    COD_PCASUISTICA = asCodPCasuistica,
                    COD_PCRITERIO = asCodPCriterio,
                    ASIGNAR = abAsignar,
                    COD_UCUENTA = asCodUCuenta
                };

                _datPlan.GrabarPlanCasuisticaCriterio(entCaso);

                if (abAsignar)
                {
                    result.AddResultado("Criterio asignado correctamente", true);
                }
                else
                {
                    result.AddResultado("Criterio quitado correctamente", true);
                }
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
        #endregion

        #region "PLAN_CASUISTICA_UNIVERSO"
        public List<Dictionary<string, string>> ListarPlanCasuisticaUniverso(string asCodPlan, string asCodPCasuistica)
        {
            return _datPlan.ListarPlanCasuisticaUniverso(new Ent_PLAN_CASUISTICA_UNIVERSO() { COD_PLAN = asCodPlan, COD_PCASUISTICA = asCodPCasuistica });
        }

        public ListResult GrabarPlanCasuisticaUniverso(List<Ent_PLAN_CASUISTICA_UNIVERSO> olUniverso)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.GrabarPlanCasuisticaUniverso(olUniverso);

                result.AddResultado("Datos registrados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult EliminarPlanCasuisticaUniverso(string asCodPCasuistica)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.EliminarPlanCasuisticaUniverso(new Ent_PLAN_CASUISTICA_UNIVERSO() { COD_PCASUISTICA = asCodPCasuistica });

                result.AddResultado("Registros eliminados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult CalcularPlanCasuisticaUniverso(string asCodPCasuistica)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.CalcularPlanCasuisticaUniverso(new Ent_PLAN_CASUISTICA_UNIVERSO() { COD_PCASUISTICA = asCodPCasuistica });

                result.AddResultado("Priorización realizada correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public List<Dictionary<string, string>> ConsolidadoPlanCasuisticaUniverso(string asCodPlan, string asCodOd = "0000000", string asCodEstadoPriorizar = "0000000")
        {
            return _datPlan.ConsolidadoPlanCasuisticaUniverso(new Ent_PLAN_CASUISTICA_UNIVERSO() { COD_PLAN = asCodPlan, COD_OD = asCodOd, COD_ESTADO_PRIORIZAR = asCodEstadoPriorizar });
        }

        public ListResult PriorizarConsolidadoPlanCasuisticaUniverso(List<Ent_PLAN_CASUISTICA_UNIVERSO> olUniverso)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.PriorizarConsolidadoPlanCasuisticaUniverso(olUniverso);

                result.AddResultado("Registros priorizados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult ObservarConsolidadoPlanCasuisticaUniverso(VM_PlanCasuisticaUniverso vm, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.ObservarConsolidadoPlanCasuisticaUniverso(new Ent_PLAN_CASUISTICA_UNIVERSO()
                {
                    COD_PCASUISTICA = vm.hdfCodPCasuistica,
                    COD_PLAN = vm.hdfCodPlan,
                    COD_SECUENCIAL = vm.hdfCodSecuencial,
                    OBSERVACION = vm.txtObservacion,
                    COD_UCUENTA = asCodUCuenta
                });

                result.AddResultado("Observación realizada correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult RevisarConsolidadoPlanCasuisticaUniverso(VM_PlanCasuisticaUniverso vm)
        {
            ListResult result = new ListResult();

            try
            {
                _datPlan.RevisarConsolidadoPlanCasuisticaUniverso(new Ent_PLAN_CASUISTICA_UNIVERSO()
                {
                    COD_PCASUISTICA = vm.hdfCodPCasuistica,
                    COD_PLAN = vm.hdfCodPlan,
                    COD_SECUENCIAL = vm.hdfCodSecuencial,
                    REVISAR = vm.chkRevisar,
                    REVISION = vm.txtRevision
                });

                result.AddResultado("Observación realizada correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public VM_PlanCasuisticaUniverso InitPlanCasuisticaUniverso(string asCodPCasuistica, string asCodPlan, int aiCodSecuencial)
        {
            VM_PlanCasuisticaUniverso vm = new VM_PlanCasuisticaUniverso();
            var entRegistro = _datPlan.ObtenerConsolidadoPlanCasuisticaUniverso(new Ent_PLAN_CASUISTICA_UNIVERSO()
            {
                COD_PCASUISTICA = asCodPCasuistica,
                COD_PLAN = asCodPlan,
                COD_SECUENCIAL = aiCodSecuencial
            });

            if (entRegistro.COD_PCASUISTICA != "")
            {
                vm.chkRevisar = (bool)entRegistro.REVISAR;
                vm.hdfCodPCasuistica = entRegistro.COD_PCASUISTICA;
                vm.hdfCodPlan = entRegistro.COD_PLAN;
                vm.hdfCodSecuencial = entRegistro.COD_SECUENCIAL;
                vm.hdfObservar = (bool)entRegistro.OBSERVAR;
                vm.txtObservacion = entRegistro.OBSERVACION;
                vm.txtRevision = entRegistro.REVISION;
                vm.txtUsuario = entRegistro.UCUENTA;
            }
            else
            {
                throw new Exception("No se encontro el registro");
            }

            return vm;
        }
        #endregion

        #region "PLAN_REPORTE"
        public List<Dictionary<string, string>> ListarReportePlan(string asCodPlan, string asTipoReporte)
        {
            return _datPlan.ListarReportePlan(new Ent_PLAN_REPORTE() { COD_PLAN = asCodPlan, TIPO_REPORTE = asTipoReporte });
        }
        #endregion
    }
}