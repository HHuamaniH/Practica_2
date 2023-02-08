using CapaDatos.Documento;
using CapaEntidad.DOC;
using CapaEntidad.Documento;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using CEntBusq = CapaEntidad.DOC.Ent_BUSQUEDA;
using CLogBusq = CapaLogica.DOC.Log_BUSQUEDA;
namespace CapaLogica.Documento
{
    public class Log_Focalizacion
    {
        private Dat_Focalizacion _dat;
        #region "Priorizacion paspeq"
        public List<VM_Focalizacion_Priorizacion> PaspeqPriorizacionListar(string periodo, string codOdAmbito, string numTH)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PaspeqPriorizacionListar(periodo, codOdAmbito, numTH);
        }
        public VM_Focalizacion_Priorizacion PaspeqPriorizacionGetById(string codPlan, int codSecuencial)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PaspeqPriorizacionGetById(codPlan, codSecuencial);
        }
        public bool PaspeqPriorizacionInsertarEliminar(List<VM_Focalizacion_Priorizacion_> items, string usuarioCreacion)
        {
            _dat = new Dat_Focalizacion();
            List<ENT_Focalizacion_Priorizacion> list = new List<ENT_Focalizacion_Priorizacion>();
            foreach (var item in items)
            {
                list.Add(new ENT_Focalizacion_Priorizacion
                {
                    COD_PLAN = item.codPlan,
                    COD_SECUENCIAL = item.codSecuencial,
                    COD_UCUENTA_CREACION = usuarioCreacion,
                    A1 = item.a1,
                    A2 = item.a2,
                    A3 = item.a3,
                    A4 = item.a4,
                    A5 = item.a5,
                    A6 = item.a6,
                    A7 = item.a7,
                    A8 = item.a8,
                    B1 = item.b1,
                    B2 = item.b2,
                    B3 = item.b3,
                    B4 = item.b4,
                    B5 = item.b5,
                    B6 = item.b6
                });
            }
            return _dat.PaspeqPriorizacionInsertarEliminar(list, usuarioCreacion);
        }
        #endregion

        #region "Focalización - Plan de trabajo"
        public List<VM_Focalizacion_PlanTrabajo_List> PlanTrabajoListar(string od, string periodo, int mes, string id, int currentpage, int pagesize, string sort, ref int rowcount)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoListar(od, periodo, mes, id, currentpage, pagesize, sort, ref rowcount);
        }
        public VM_Focalizacion_PlanTrabajo PlanTrabajoGetById(string id, string codCuenta, string VALIAS_ROL = null)
        {
            CEntBusq objBusqueda = new CEntBusq() { BusFormulario = "GENERAL", BusValor = VALIAS_ROL, COD_UCUENTA = codCuenta };
            CLogBusq oCLogicaBusqueda = new CLogBusq();
            objBusqueda = oCLogicaBusqueda.RegMostCombo(objBusqueda);
            List<VM_Cbo> listIndicador = objBusqueda.ListIndicador.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();

            _dat = new Dat_Focalizacion();
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
            VM_Focalizacion_PlanTrabajo vm = _dat.PlanTrabajoGetById(id); ;
                     

            vm.ddlIOD = exeBus.RegMostComboIndividual("FOCALIZACION_OD", "");
            vm.ddlPeriodo = exeBus.RegMostComboIndividual("FOCALIZACION_PERIODO_PLAN_TRABAJO_ADD", "");
            vm.ddlMes = new List<VM_Cbo>() { new VM_Cbo() { Text = "Enero", Value = "1" },
                                                                    new VM_Cbo() { Text = "Febrero", Value = "2" },
                                                                    new VM_Cbo() { Text = "Marzo", Value = "3" },
                                                                    new VM_Cbo() { Text = "Abril", Value = "4" },
                                                                    new VM_Cbo() { Text = "Mayo", Value = "5" },
                                                                    new VM_Cbo() { Text = "Junio", Value = "6" },
                                                                    new VM_Cbo() { Text = "Julio", Value = "7" },
                                                                    new VM_Cbo() { Text = "Agosto", Value = "8" },
                                                                    new VM_Cbo() { Text = "Setiembre", Value = "9" },
                                                                    new VM_Cbo() { Text = "Octubre", Value = "10" },
                                                                    new VM_Cbo() { Text = "Noviembre", Value = "11" },
                                                                    new VM_Cbo() { Text = "Diciembre", Value = "12" } };
            //calidad
            //Observaciones de control de calidad

            bool enableIndicador = true;
            string itemSelectIndicador = vm.ddlItemIndicadorId;
            Log_Helper.controla_estado_calidad(vm.ddlItemIndicadorId, ref listIndicador, ref enableIndicador, ref itemSelectIndicador);
            vm.ddlItemIndicador = listIndicador;
            vm.ddlItemIndicadorId = itemSelectIndicador;
            vm.ddlItemIndicadorEnable = enableIndicador;
            return vm;
        }
        public string PlanTrabajoCreate(string od, string periodo, Int16 mes, string codUsuario)
        {
            _dat = new Dat_Focalizacion();
            Ent_Focalizacion_PlanTrabajo ent = new Ent_Focalizacion_PlanTrabajo();
            ent.COD_PLAN_TRABAJO_SUPERVISION = "0000000";
            ent.COD_OD = od;
            ent.PERIODO = periodo;
            ent.MES_FOCALIZACION = mes;
            ent.COD_ESTADO_DOC = "0000001";
            ent.COD_UCUENTA_CREACION = codUsuario;
            return _dat.PlanTrabajoCreate(ent);
        }
        public bool PlanTrabajoDetCreate(List<VM_Focalizacion_PlanTrabajoDet> vm, string codUsuario)
        {
            _dat = new Dat_Focalizacion();
            List<Ent_Focalizacion_PlanTrabajo_Detalle> lstDet = new List<Ent_Focalizacion_PlanTrabajo_Detalle>();
            if (vm != null)
            {
                if (vm.Count > 0)
                {
                    foreach (var item in vm)
                    {
                        lstDet.Add(new Ent_Focalizacion_PlanTrabajo_Detalle() {
                            COD_PLAN_TRABAJO_SUPERVISION=item.idPlanTrajo,
                            COD_PLAN=item.codPlan,
                            COD_SECUENCIAL=item.codSecuencial,
                            TIPO_SUPERVISION=item.tipoSupId,
                            OPORTUNIDAD_SUPERVISION=item.oportunidadSupId==0?(int?)null: item.oportunidadSupId,
                            COD_UCUENTA_CREACION= codUsuario
                        });
                    }
                }
                else
                {
                    throw new Exception("0|No existe items a registrar");
                }
            }
            else
            {
                throw new Exception("0|No existe items a registrar");
            }
            return _dat.PlanTrabajoDetCreate(lstDet);
        }
        public bool PlanTrabajoDetDelete(VM_Focalizacion_PlanTrabajoDet vm, string codUsuario)
        {
            Ent_Focalizacion_PlanTrabajo_Detalle ent = new Ent_Focalizacion_PlanTrabajo_Detalle
            {
                COD_PLAN_TRABAJO_SUPERVISION_DETALLE = vm.idPlanTrajoDet,
                COD_PLAN_TRABAJO_SUPERVISION = vm.idPlanTrajo,
                COD_UCUENTA_CREACION = codUsuario
            };
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetDelete(ent);
        }
        public bool PlanTrabajoDelete(VM_Focalizacion_PlanTrabajo vm, string codUsuario)
        {
            Ent_Focalizacion_PlanTrabajo ent = new Ent_Focalizacion_PlanTrabajo
            {
                COD_PLAN_TRABAJO_SUPERVISION = vm.idPlanTrajo,
                COD_UCUENTA_CREACION = codUsuario
            };
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDelete(ent);
        }
        public string PlanTrabajoCreate(VM_Focalizacion_PlanTrabajo vm)
        {
            _dat = new Dat_Focalizacion();
            Ent_Focalizacion_PlanTrabajo ent = new Ent_Focalizacion_PlanTrabajo();
            ent.COD_PLAN_TRABAJO_SUPERVISION = vm.idPlanTrajo;
            ent.COD_OD = vm.ddlIODId;
            ent.PERIODO = vm.ddlPeriodoId;
            ent.MES_FOCALIZACION = vm.ddlMesId;

            ent.COD_UCUENTA_CREACION = vm.codUsuarioCreacion;
            ent.COD_JEFE = vm.funcionarioResponsableId;
            //control de calidad
            ent.COD_ESTADO_DOC = vm.ddlItemIndicadorId;
            ent.OBSERVACIONES_CONTROL = vm.observacionControl;
            ent.OBSERV_SUBSANAR = vm.observacionSubsanar;
            return _dat.PlanTrabajoCreate(ent);
        }

        public List<VM_PlanManejoCalificacion> PlanManejoCalificadoGetAll(string codPlanTrabajo, int tipoSupervision = 4)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanManejoCalificadoGetAll(codPlanTrabajo, tipoSupervision);
        }
        public List<VM_Focalizacion_PlanTrabajoDet_List> PlanTrabajoDetGetByPadreId(string id)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetGetByPadreId(id);
        }
        public VM_Focalizacion_PlanTrabajoDet_List PlanTrabajoDetGetById(long id)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetGetById(id);
        }
        #endregion

        #region "Muestra"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codTH"></param>
        /// <param name="numPoa"></param>
        /// <param name="codPlanSupervisionDetalle"></param>
        /// <param name="codUsuario"></param>
        /// <param name="tipoPManejo">cuando es tipo DEMA, las especies aprovechables y semilleros se evalu al 100%</param>
        /// <returns></returns>
        public bool GenerarCalificacionMuestra(string codTH, int numPoa, long codPlanSupervisionDetalle, string codUsuario, string tipoPManejo)
        {
            //obteniendo especies desde del SIGOsfc
            List<VM_PlanTrabajoDetalleEspecie> lstPoaEspecieAprobada = this.ObtenerAndCalificarEspecieMuestra(codTH, numPoa);
            if (lstPoaEspecieAprobada == null) throw new Exception("0|No existe especies a calificar");
            if (lstPoaEspecieAprobada.Count() <= 0) throw new Exception("0|No existe especies a calificar");
            //Creando entidad a registrar
            List<Ent_Plan_T_Detalle_Especie> lstEnt = new List<Ent_Plan_T_Detalle_Especie>();
            foreach (var item in lstPoaEspecieAprobada)
            {
                lstEnt.Add(new Ent_Plan_T_Detalle_Especie
                {
                    COD_PLAN_TRABAJO_SUPERVISION_DETALLE= codPlanSupervisionDetalle,
                    COD_ESPECIES=item.codEspecie,
                    N_APROVECHABLES=item.numAprov,
                    N_SEMILLEROS=item.numSemilleros,
                    N_TOTAL_INDIVIDUOS=item.totalIndividuos,
                    V_AUTORIZADO=item.volAutorizado,
                    V_MOVILIZADO=item.volMovilizado,
                    PUNTAJE_FINAL=item.puntajeTotalCalificacion,
                    PUNTAJE_FINAL_PORCENTAJE=item.puntajeTotalPorcentaje,
                    COD_UCUENTA_CREACION=codUsuario,
                    CAL_ABUNDANCIA=item.abundanciaCalificacion,
                    PUNTAJE_ABUNDANCIA=item.abundanciaPuntaje,
                    CAL_V_APROBADO=item.volAprobadoCalificacion,
                    PUNTAJE_V_APROBADO=item.volAprobadoPuntaje,
                    CAL_V_MOVILIZADO=item.volMovilizadoCalificacion,
                    PUNTAJE_V_MOVILIZADO=item.volMovilizadoPuntaje,
                    AGRADO_CITE=item.AGRADO_CITE,
                    TIENE_AGRADO_CITE=item.TIENE_AGRADO_CITE,
                    TIPOPMANEJO = tipoPManejo,
                    CAL_CAT_ESPECIE_AMENAZADA= item.IdPuntajeEspeciesAmenazadas,
                    PUNTAJE_CAT_ESPECIE_AMENAZADA=item.puntajeEspeciesAmenazadas,
                    CAL_CAT_ESPECIE_MADERABLE=item.IdPuntajeCategoriaMad,
                    PUNTAJE_CAT_ESPECIE_MADERABLE=item.puntajeCategoriaMad,
                    PCA = item.PCA
                });
            }
            //registrando
            _dat = new Dat_Focalizacion();
            _dat.GenerarCalificacionMuestra(lstEnt);
            return true;
        }
        private List<VM_PlanTrabajoDetalleEspecie> ObtenerAndCalificarEspecieMuestra(string codTH, int numPoa)
        {
            _dat = new Dat_Focalizacion();
            //obteniendo especies con datos basicos del poa
            List<VM_PlanTrabajoDetalleEspecie> lstPoaEspecieAprobada = _dat.PlanTrabajoDetGetEspecie(codTH, numPoa);


            decimal totalIndividuos = 0, totalVolAutorizado = 0, puntajeTotal = 0;

            if (lstPoaEspecieAprobada.Count > 0)
            {
                //List<VM_PlanTrabajoDetalleEspecie> lstPoaEspecieAprobadaNoCites = (from item in lstPoaEspecieAprobada
                //                                                                   where !item.TIENE_AGRADO_CITE
                //                                                                   select item).ToList();
                //List<VM_PlanTrabajoDetalleEspecie> lstPoaEspecieAprobadaCites = (from item in lstPoaEspecieAprobada
                //                                                                   where item.TIENE_AGRADO_CITE
                //                                                                   select item).ToList();

                totalIndividuos = (from x in lstPoaEspecieAprobada
                                   where !x.TIENE_AGRADO_CITE
                                   select x.totalIndividuos).Sum();
                //totalIndividuos = lstPoaEspecieAprobada.Select(x => x.totalIndividuos).Sum();
                //totalVolAutorizado = lstPoaEspecieAprobada.Select(x => x.volAutorizado).Sum();
                totalVolAutorizado = (from z in lstPoaEspecieAprobada
                                      where !z.TIENE_AGRADO_CITE
                                      select z.volAutorizado).Sum();

                foreach (var item in lstPoaEspecieAprobada)
                {
                    //abundancia
                    item.abundanciaCalificacion = totalIndividuos <= 0 ? 0 : Math.Round((item.totalIndividuos * 100) / totalIndividuos, 3);
                    item.abundanciaPuntaje = this.ObtenerPuntajexAbundancia(item.abundanciaCalificacion);

                    //vol aprobado
                    item.volAprobadoCalificacion = item.totalIndividuos <= 0 ? 0 : (totalVolAutorizado <= 0 ? 0 : Math.Round((item.volAutorizado * 100) / totalVolAutorizado, 3));
                    item.volAprobadoPuntaje = this.ObtenerPuntajexVolAprobado(item.volAprobadoCalificacion);

                    //vol movilizado
                    item.volMovilizadoCalificacion = item.totalIndividuos <= 0 ? 0 : (item.volAutorizado <= 0 ? 0 : Math.Round((item.volMovilizado * 100) / item.volAutorizado, 3));
                    item.volMovilizadoPuntaje = this.ObtenerPuntajexVolMovilizado(item.volMovilizadoCalificacion);

                    //especies amenazadas
                    // item.puntajeEspeciesAmenazadas = 0; valor biene de la base de datos
                    //categoria de madera
                    // item.puntajeCategoriaMad = 0;valor biene de la base de datos
                    //puntaje total
                    item.puntajeTotalCalificacion = item.abundanciaPuntaje + item.volAprobadoPuntaje + item.volMovilizadoPuntaje + item.puntajeEspeciesAmenazadas + item.puntajeCategoriaMad;

                }
                //calculando porcentaje puntaje total final
                // puntajeTotal= lstPoaEspecieAprobada.Select(x => x.puntajeTotalCalificacion).Sum();
                puntajeTotal = (from y in lstPoaEspecieAprobada
                                where !y.TIENE_AGRADO_CITE
                                select y.puntajeTotalCalificacion).Sum();
                foreach (var item in lstPoaEspecieAprobada)
                {
                    item.puntajeTotalPorcentaje = puntajeTotal <= 0 ? 0 : Math.Round((item.puntajeTotalCalificacion * 100) / puntajeTotal, 2);

                }
            }
            return lstPoaEspecieAprobada;
        }
        private List<VM_PlanTrabajoDetalleEspecie> RecalcularCalificacionEspecieMuestra(List<VM_PlanTrabajoDetalleEspecie> lstPoaEspecieAprobada)
        {

            decimal puntajeTotal = 0;

            if (lstPoaEspecieAprobada.Count > 0)
            {
                foreach (var item in lstPoaEspecieAprobada)
                {
                    //especies amenazadas

                    //categoria de madera

                    //puntaje total
                    if (item.totalIndividuos > 0)
                        item.puntajeTotalCalificacion = item.abundanciaPuntaje + item.volAprobadoPuntaje + item.volMovilizadoPuntaje + item.puntajeEspeciesAmenazadas + item.puntajeCategoriaMad;

                }
                //calculando porcentaje puntaje total final
                puntajeTotal = lstPoaEspecieAprobada.Select(x => x.puntajeTotalCalificacion).Sum();
                foreach (var item in lstPoaEspecieAprobada)
                {
                    item.puntajeTotalPorcentaje = item.totalIndividuos <= 0 ? 0 : Math.Round((item.puntajeTotalCalificacion * 100) / puntajeTotal, 2);

                }
            }
            return lstPoaEspecieAprobada;
        }
        public List<VM_PlanTrabajoDetalleEspecie> PlanTrabajoDetGetEspecieCalificacionNoCites(long codPlanTrabajoSupervisionDetalle)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetGetEspecieCalificacionNoCites(codPlanTrabajoSupervisionDetalle);
        }
        public List<VM_PlanTrabajoDetalleEspecie> PlanTrabajoDetGetEspecieCalificacionCites(long codPlanTrabajoSupervisionDetalle)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetGetEspecieCalificacionCites(codPlanTrabajoSupervisionDetalle);
        }
        public bool PlanTrabajoDetEspecieDelete(long codPlanTrabajoSupervisionDetalle, string codUsuario)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetEspecieDelete(codPlanTrabajoSupervisionDetalle, codUsuario);
        }

        //permite actualizar la calificación de especies mientras que no este con control de calidad conforme
        public bool ActualizarPTSDetalleCalificacion(VM_PlanTrabajoDetalleEspecie item, string codUsuario)
        {
            List<VM_PlanTrabajoDetalleEspecie> lstEspecieRegistrada = this.PlanTrabajoDetGetEspecieCalificacionNoCites(item.idCabecera);
            foreach (var i in lstEspecieRegistrada)
            {
                if (i.id == item.id)
                {
                    i.IdPuntajeEspeciesAmenazadas = item.IdPuntajeEspeciesAmenazadas;
                    i.puntajeEspeciesAmenazadas = item.puntajeEspeciesAmenazadas;
                    i.IdPuntajeCategoriaMad = item.IdPuntajeCategoriaMad;
                    i.puntajeCategoriaMad = item.puntajeCategoriaMad;
                }
            }
            List<VM_PlanTrabajoDetalleEspecie> listaEspecieActualizar = this.RecalcularCalificacionEspecieMuestra(lstEspecieRegistrada);
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetalleEspecie_Update(listaEspecieActualizar, codUsuario);
        }
        public bool GenerarMuestraMinima(long codPlanTrabajoSupervisionDetalle, string codUsuario)
        {
            int numeroMinimoEspecieEvaluar = 0;
            //obteniendo especies calificadas ordenadas de puntaje mayor a menor
            List<VM_PlanTrabajoDetalleEspecie> lstEspecieRegistrada = this.PlanTrabajoDetGetEspecieCalificacionNoCites(codPlanTrabajoSupervisionDetalle);
            //List<VM_PlanTrabajoDetalleEspecie> lstEspecieRegistradaCites = this.PlanTrabajoDetGetEspecieCalificacionCites(codPlanTrabajoSupervisionDetalle);
            if (lstEspecieRegistrada.Count <= 0)
            {
                throw new Exception("0|No se puede generar la muestra. Primero realice la calificación de las especies o verifique en el sigo si el registro tiene censo");
            }
            //obteniendo especies de la muestra minima segun directiva
            List<VM_PlanTrabajoDetalleEspecie> lstEspecieMinima = new List<VM_PlanTrabajoDetalleEspecie>();
            decimal n = 0;
            if (lstEspecieRegistrada.Count > 0)
            {
                numeroMinimoEspecieEvaluar = this.ObtenerNumeroMinimoEspecieEvaluar(lstEspecieRegistrada.Count());

                if (lstEspecieRegistrada.Count() > numeroMinimoEspecieEvaluar)
                {
                    for (int i = 0; i < numeroMinimoEspecieEvaluar; i++)
                    {
                        lstEspecieMinima.Add(lstEspecieRegistrada[i]);
                    }
                    VM_PlanTrabajoDetalleEspecie ultimoSeleccionado = lstEspecieMinima[lstEspecieMinima.Count() - 1];
                    //buscando si existe items con igual puntaje al ultimo elemento seleccionado
                    for (int j = numeroMinimoEspecieEvaluar; j < lstEspecieRegistrada.Count(); j++)
                    {
                        if (ultimoSeleccionado.puntajeTotalPorcentaje == lstEspecieRegistrada[j].puntajeTotalPorcentaje)
                        {
                            lstEspecieMinima.Add(lstEspecieRegistrada[j]);
                        }
                    }
                }
                else
                {// para los casos cuando la cantidad de especies son menores que 5
                    for (int i = 0; i < lstEspecieRegistrada.Count(); i++)
                    {
                        lstEspecieMinima.Add(lstEspecieRegistrada[i]);
                    }
                }


                /*determinando número de individuos por especie a evaluar segun formula n=((Z*Z)* (p*q*N))/N*(E*E)+(Z*Z)*p*q
                n: tamaño mínimo de la muestra.
                Z: valor tabular de la distribución de “t” nc: 95 % (1, 960).
                p: variabilidad positiva(0,50).
                q: variabilidad negativa(0.50).
                N: tamaño de la población de especies seleccionadas.
                E: precisión o el error(como máximo 10 %).*/
                decimal Z = (decimal)1.96, p = (decimal)0.5, q = (decimal)0.5, E = (decimal)0.1;
                int N = 0;
                N = lstEspecieMinima.Select(x => x.totalIndividuos).Sum();
                if (N <= 0)
                {
                    throw new Exception("0|El plan de manejo no tiene cantidad de individuos por especie ingresada. No se puede continuar con la operación");
                }
                n = Math.Round(((Z * Z) * p * q * N) / ((N * (E * E)) + ((Z * Z) * p * q)), 2);
                Int32 cantMuestraSem = 0;
                //calculando otros datos               
                foreach (var item in lstEspecieMinima)
                {
                    item.factorAprov = (Convert.ToDecimal(item.numAprov) / Convert.ToDecimal(N));
                    item.factorSem = (Convert.ToDecimal(item.numSemilleros) / Convert.ToDecimal(N));
                    item.muestraAprov = Convert.ToInt32(Math.Ceiling(item.factorAprov.Value * n));// Convert.ToInt32(Math.Round(item.factorAprov.Value * n,0));
                    /*
                      En el caso de semilleros, por lo menos se debe evaluar 3 individuos 
                      por cada especie seleccionada, si la especie cuenta con menos de 3 individuos semilleros, evaluar al 100%
                    */
                    if (item.numSemilleros <= 3)
                    {
                        item.muestraSem = item.numSemilleros;
                    }
                    else
                    {
                        cantMuestraSem = Convert.ToInt32(Math.Ceiling(item.factorSem.Value * n));
                        if (cantMuestraSem < 3)
                        {
                            item.muestraSem = 3;
                        }
                        else
                        {
                            item.muestraSem = cantMuestraSem;
                        }
                    }

                }

            }


            //registrando muestra minima
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetalleMuestraMinima_Create(lstEspecieMinima, n, codPlanTrabajoSupervisionDetalle, codUsuario);
        }
        public List<VM_PlanTrabajoDetalleEspecie> PlanTrabajoDetGetMuestraMinima_GetByPTSD(long codPlanTrabajoSupervisionDetalle)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetGetMuestraMinima_GetByPTSD(codPlanTrabajoSupervisionDetalle);
        }
        public decimal PlanTrabajoDetGetCantidadEspeciesCites_GetByPTSD(long codPlanTrabajoSupervisionDetalle)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetGetCantidadEspeciesCites_GetByPTSD(codPlanTrabajoSupervisionDetalle);
        }
        public List<VM_PlanTrabajoDetalleEspecie> PlanTrabajoDetGetConsolidado_GetByPTSD(long codPlanTrabajoSupervisionDetalle)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetGetConsolidado_GetByPTSD(codPlanTrabajoSupervisionDetalle);
        }
        public bool PlanTrabajoDetalleAdicionalOrigen_Delete(long id, long codPlanTrabajoSupervisionDetalle, string codUsuario)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetalleAdicionalOrigen_Delete(id, codPlanTrabajoSupervisionDetalle, codUsuario);
        }
        public bool PlanTrabajoDetalleMuestraMinima_Delete(long codPlanTrabajoSupervisionDetalle, string codUsuario)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetalleMuestraMinima_Delete(codPlanTrabajoSupervisionDetalle, codUsuario);
        }
        public bool PlanTrabajoDetalleAdicionalOrigen_Create(VM_PlanTrabajoDetalleEspecie especieAdicional, string codUsuario)
        {
            _dat = new Dat_Focalizacion();
            return _dat.PlanTrabajoDetalleAdicionalOrigen_Create(especieAdicional, codUsuario);
        }
        public bool ModificarCantidadConsolidado(VM_PlanTrabajoDetalleEspecie especieConsolidado, string codUsuario)
        {
            _dat = new Dat_Focalizacion();
            return _dat.ModificarCantidadConsolidado(especieConsolidado, codUsuario);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cantidadEspecie">Cantidad de especies calificadas de la resolución</param>
        /// <returns></returns>
        private Int32 ObtenerNumeroMinimoEspecieEvaluar(int cantidadEspecie)
        {
            if (cantidadEspecie <= 0) return 0;
            if (cantidadEspecie <= 10) return 5;
            else if (cantidadEspecie <= 15) return 6;
            else if (cantidadEspecie <= 20) return 7;
            else if (cantidadEspecie <= 25) return 8;
            else if (cantidadEspecie <= 30) return 9;
            else if (cantidadEspecie > 30) return 10;
            return 0;

        }
        private Int32 ObtenerPuntajexAbundancia(decimal porcentaje)
        {
            if (porcentaje < 0) return 0;
            if (porcentaje < 3) return 2;
            else if (porcentaje < (decimal)5.99) return 4;
            else if (porcentaje < (decimal)8.99) return 6;
            else if (porcentaje > 9) return 8;
            return 0;
        }
        private Int32 ObtenerPuntajexVolAprobado(decimal porcentaje)
        {
            if (porcentaje < 0) return 0;
            if (porcentaje < 3) return 2;
            else if (porcentaje < (decimal)5.99) return 4;
            else if (porcentaje < (decimal)8.99) return 6;
            else if (porcentaje > 9) return 8;
            return 0;
        }
        private Int32 ObtenerPuntajexVolMovilizado(decimal porcentaje)
        {
            if (porcentaje < 0) return 0;
            if (porcentaje < 25) return 4;
            else if (porcentaje < (decimal)49.99) return 8;
            else if (porcentaje < (decimal)74.99) return 12;
            else if (porcentaje > 75) return 16;
            return 0;
        }
        #endregion

        #region "Planes de Manejo Extra-Ordinario"
        public bool GenerarUniversoExtraOrdinario(string codPlan, string codTH, string codPManejo, int numPoa, string idPlanTrajo, int oportunidadSupId, string codUsuario)
        {
            _dat = new Dat_Focalizacion();
            return _dat.GenerarUniversoExtraOrdinario(codPlan, codTH, codPManejo, numPoa, idPlanTrajo, oportunidadSupId, codUsuario);
        }
        #endregion
    }
}
