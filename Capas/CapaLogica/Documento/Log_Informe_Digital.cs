using CapaDatos.DOC;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.DOC
{
    public class Log_Informe_Digital
    {
        public bool Eliminar(string COD_INFORME, string COD_USUARIO_OPERACION, DateTime FECHA_OPERACION)
        {
            return new Dat_Informe_Digital().Eliminar(COD_INFORME, COD_USUARIO_OPERACION, FECHA_OPERACION);
        }
        public bool CambiarEstado(string codInformeDigital, DateTime fechaOperacion, int estado, string codUsuarioOperacion)
        {
            return new Dat_Informe_Digital().CambiarEstado(codInformeDigital, fechaOperacion, estado, codUsuarioOperacion);
        }
        public bool ActualizarDatosSITD(string codInforme, string numInforme, int tramiteId, DateTime fechaRegistroTramite, DateTime fechaOperacion, string codUsuarioOperacion)
        {
            return new Dat_Informe_Digital().ActualizarDatosSITD(codInforme, numInforme, tramiteId, fechaRegistroTramite, fechaOperacion, codUsuarioOperacion);
        }
        public bool NotificarControlCalidad(string codInforme, string numTH, string correo, string persona)
        {
            return new Dat_Informe_Digital().NotificarControlCalidad(codInforme, numTH, correo, persona);
        }
        public void ImportarInformeDigital(VM_INFORME_DIGITAL informeDigital, String opcion = "INSERT")
        {
            Ent_SupervisionTabInformeDigital cabecera = new Ent_SupervisionTabInformeDigital();
            cabecera.pVCodInformeDigital = informeDigital.COD_INFORME_DIGITAL;
            cabecera.pVInformeDigital = informeDigital.INFORME_DIGITAL;
            new Dat_Informe_Digital().ImportarInformeDigital(cabecera, opcion);
        }
        public string RegGrabar(VM_INFORME_DIGITAL informeDigital)
        {
            Ent_SupervisionTabInformeDigital cabecera = new Ent_SupervisionTabInformeDigital();

            cabecera.pVCodInformeDigital = informeDigital.COD_INFORME_DIGITAL;
            cabecera.pVCodInforme = informeDigital.COD_INFORME;
            cabecera.pVNumInformeSITD = informeDigital.NUM_INFORME_SITD;
            cabecera.pNTramiteId = informeDigital.TRAMITE_ID;
            cabecera.pVCodDestinatario = informeDigital.COD_DESTINATARIO;
            cabecera.pDFechaRegistro = informeDigital.FECHA_REGISTRO;
            cabecera.pVRucTitularEstado = informeDigital.RUC_TITULAR_ESTADO;
            cabecera.pVRucTitularCondicion = informeDigital.RUC_TITULAR_CONDICION;
            cabecera.pVRucTitularDireccion = informeDigital.RUC_TITULAR_DIRECCION;
            cabecera.pVNumTelefonoTitular = informeDigital.TELEFONO_TITULAR;
            cabecera.pVAntecedentes = informeDigital.ANTECEDENTES;
            cabecera.pVTipoBosque = informeDigital.TIPO_BOSQUE;
            cabecera.pVDiligenciaCronograma = informeDigital.CRONOGRAMA;
            cabecera.pVMetodologia = informeDigital.METODOLOGIA;
            cabecera.pVAnalisis = informeDigital.ANALISIS;
            cabecera.pVResultados = informeDigital.RESULTADOS;
            cabecera.pVConclusiones = informeDigital.CONCLUSIONES;
            cabecera.pVRecomendaciones = informeDigital.RECOMENDACIONES;
            cabecera.pVCodUsuarioCreacion = informeDigital.COD_USUARIO_OPERACION;
            cabecera.pVCodUsuarioModificacion = informeDigital.COD_USUARIO_OPERACION;
            cabecera.pDFechaCreacion = DateTime.Now;
            cabecera.pDFechaModificacion = DateTime.Now;
            cabecera.pNRegEstado = 1;
            cabecera.pVOUTPUTPARAM01 = "";

            return new Dat_Informe_Digital().RegGrabar(cabecera, informeDigital);
        }
        public VM_INFORME_DIGITAL ObtenerInformeDigital(/*string COD_INFORME_DIGITAL,*/ string COD_INFORME)
        {
            return new Dat_Informe_Digital().ObtenerInformeDigital(COD_INFORME);
        }
        public VM_INFORME_DIGITAL ObtenerInformeDigitalShort(string COD_INFORME)
        {
            return new Dat_Informe_Digital().ObtenerInformeDigitalShort(COD_INFORME);
        }
        public void IDigitalEspecialistaCalidadObtener(string codInforme, out string codEspecialista, out string especialista, out string correo)
        {
            new Dat_Informe_Digital().IDigitalEspecialistaCalidadObtener(codInforme,out codEspecialista,out especialista,out correo);
        }
        private string Texto(string cadena)
        {
            cadena = cadena ?? "";
            if (cadena.Trim() == "")
            {
                return "<mark class=\"marker-yellow\" > ..........</mark>";
            }
            else return cadena.Trim();
        }
        private int AñoFechaInicioFechaFin(DateTime? fechaInicio, DateTime? fechaFin)
        {
            int añoTrasncurrido = 0;
            if (fechaInicio != null && fechaFin != null)
            {
                añoTrasncurrido = fechaFin.Value.Year - fechaInicio.Value.Year;
                añoTrasncurrido = añoTrasncurrido < 0 ? 0 : añoTrasncurrido;


            }

            return añoTrasncurrido;
        }
        public string ObtenerOficinaXModalidad(string COD_MTIPO)
        {
            string result = "";
            switch (COD_MTIPO)
            {
                case "0000002":
                case "0000003":
                case "0000004":
                case "0000001":
                case "0000023":
                case "0000019":
                case "0000006":
                case "0000005":
                case "0000027":
                case "0000022":
                case "0000021":
                case "0000020":
                case "0000014":
                case "0000016":
                case "0000015":
                case "0000028": result = "1070|SDSPAFFS"; break; //Sub Dirección de Supervisión de Permisos y Autorizaciones Forestales y de Fauna Silvestre
                case "0000026":
                case "0000025":
                case "0000007":
                case "0000010":
                case "0000011":
                case "0000012":
                case "0000013":
                case "0000018":
                case "0000008":
                case "0000009":
                case "0000017": result = "1069|SDSCFFS"; break; //Sub Dirección de Supervisión de Concesiones Forestales y de Fauna Silvestre                                                                                                                                                             

            }
            return result;
        }
        private string Tipo_DE_TH(string COD_MTIPO)
        {
            string result = "la autorización/el permiso/el contrato";
            switch (COD_MTIPO)
            {
                case "0000002":
                case "0000003":
                case "0000004":
                case "0000001":
                case "0000023":              
                    result = "la autorización";break;
                case "0000019":
                case "0000006":
                    result = "la autorización";break;
                case "0000005":
                case "0000027":
                case "0000022":
                case "0000021":
                case "0000020":
                case "0000014":
                case "0000016":
                case "0000015":
                case "0000007":
                case "0000010":
                case "0000017":
                case "0000028": result = "el permiso"; break;
                case "0000026":
                case "0000025":  
                case "0000011":
                case "0000012":
                case "0000013":
                case "0000018":
                case "0000008":
                case "0000009":     result = "el contrato"; break;

            }
            return result;
        }
        private string FechaLetras(DateTime? fecha)
        {
            string fechaLetra = "..........";
            if (fecha != null)
            {
                fechaLetra = $"{this.Dia(fecha.Value.Day)} de {this.MesLetra(fecha.Value.Month)} de {fecha.Value.Year}";
            }
            else
            {
                fechaLetra = "<mark class=\"marker-yellow\" > ..........</mark>";
            }
            return fechaLetra;
        }
        private string Dia(int dia)
        {
            string diaTexto = dia.ToString();
            if (diaTexto.Length == 2)
            {
                return diaTexto;
            }
            else
            {
                return $"0{diaTexto}";
            }
        }
        private string MesLetra(int mes)
        {
            string mesLetra = "";
            switch (mes)
            {
                case 1: mesLetra = "enero"; break;
                case 2: mesLetra = "febrero"; break;
                case 3: mesLetra = "marzo"; break;
                case 4: mesLetra = "abril"; break;
                case 5: mesLetra = "mayo"; break;
                case 6: mesLetra = "junio"; break;
                case 7: mesLetra = "julio"; break;
                case 8: mesLetra = "agosto"; break;
                case 9: mesLetra = "septiembre"; break;
                case 10: mesLetra = "octubre"; break;
                case 11: mesLetra = "noviembre"; break;
                case 12: mesLetra = "diciembre"; break;
            }
            return mesLetra;
        }
        public List<THabilitantePOA> getPlanManejoTHabilitanteObservatorio(string COD_THABILITANTE)
        {
            return new Dat_Informe_Digital().getPlanManejoTHabilitanteObservatorio(COD_THABILITANTE);
        }
        public List<Dictionary<string, string>> GeneralListar(string busCriterio, string busValor)
        {
            return new Dat_Informe_Digital().GeneralListar(busCriterio, busValor);
        }


        public int TramiteGrabar(VM_TRAMITE tramite)
        {
            VM_TRAMITE_MOVIMIENTO dt = new VM_TRAMITE_MOVIMIENTO();

            if (tramite.iCodOficina <= 0) throw new Exception("Seleccione oficina a derivar");
            if (tramite.trabajadorId <= 0) throw new Exception("Seleccione trabajador a derivar");
            if (tramite.indicacionId <= 0) throw new Exception("Seleccione indicación o motivo");
            if (string.IsNullOrEmpty(tramite.prioridad)) throw new Exception("Seleccione prioridad");
            if (tramite.perfilId <= 0) throw new Exception("Perfil del trabajador es inválido");
            DateTime fechaActual = DateTime.Now;
            dt.nFlgTipoDoc = "2";
            dt.iCodOficinaOrigen = tramite.iCodOficina;
            dt.iCodOficinaDerivar = tramite.iCodOficina;
            dt.iCodTrabajadorDerivar = tramite.trabajadorId;
            dt.iCodIndicacionDerivar = tramite.indicacionId;
            dt.cPrioridadDerivar = tramite.prioridad;
            dt.cAsuntoDerivar = tramite.cAsunto;
            dt.cObservacionesDerivar = tramite.cObservaciones;
            dt.fFecDerivar = fechaActual;
            dt.fFecMovimiento = fechaActual;
            dt.nEstadoMovimiento = 1;
            dt.cFlgTipoMovimiento = 1;
            dt.cFlgOficina = 1;
            if (tramite.cCodTipoDoc == 2098 || tramite.cCodTipoDoc == 3136 || tramite.cCodTipoDoc == 3137)
            {
                dt.nflgtra = 1;
                dt.nFlgEnvio = 1;
            }
            else
            {
                dt.nflgtra = 0;
                dt.nFlgEnvio = 0;
            }
            dt.nflgpri = 1;
            dt.cCodTipoDocDerivar = tramite.cCodTipoDoc;
            dt.iCodTrabajadorPerfil = tramite.perfilId;


            return new Dat_Informe_Digital().TramiteGrabar(tramite, dt);
        }
        public void TramiteModificar(VM_TRAMITE tramite)
        {
            new Dat_Informe_Digital().TramiteModificar(tramite);
        }
        public void TramiteDigitalGrabar(int tramiteId, string nombreDocumento, string nombreDocumentoNuevo, DateTime fechaOperacion)
        {
            new Dat_Informe_Digital().TramiteDigitalGrabar(tramiteId, nombreDocumento, nombreDocumentoNuevo, fechaOperacion);
        }
        public VM_TRAMITE TramiteGetById(int tramiteId, string cod_THabilitante, string cod_Informe)
        {
            return new Dat_Informe_Digital().TramiteGetById(tramiteId, cod_THabilitante, cod_Informe);
        }
        public List<VM_Cbo> TramiteGeneralListar(string busCriterio, string busValor)
        {
            return new Dat_Informe_Digital().TramiteGeneralListar(busCriterio, busValor);
        }
        public List<Dictionary<string, string>> TramiteGeneralListar_Dictionary(string busCriterio, string busValor)
        {
            return new Dat_Informe_Digital().TramiteGeneralListar_Dictionary(busCriterio, busValor);
        }

        #region "Firma digital"
        public List<VM_SUPERVISOR> SupervisorObtenerPorInformeAll(string codInforme)
        {
            return new Dat_Informe_Digital().SupervisorObtenerPorInformeAll(codInforme);
        }
        public VM_SUPERVISOR SupervisorObtenerPorInforme(string codInforme, string codSupervisor)
        {
            return new Dat_Informe_Digital().SupervisorObtenerPorInforme(codInforme, codSupervisor);
        }
        public bool ActualizarFirmaPorInformeSupervisor(string codInforme, string codSupervisor)
        {
            return new Dat_Informe_Digital().ActualizarFirmaPorInformeSupervisor(codInforme, codSupervisor);
        }
        public bool AnularFirmaPorInforme(string codInforme)
        {
            return new Dat_Informe_Digital().AnularFirmaPorInforme(codInforme);
        }
        #endregion

        #region "Maderable"
        public List<VM_INFORME_DIGITAL_PM> PlanManejoListarMaderable(String codInforme)
        {
            Dat_Informe_Digital dat_Informe_Digital = new Dat_Informe_Digital();

            List<VM_INFORME_DIGITAL_PM> lstPlanManejo = dat_Informe_Digital.PlanManejoListar(codInforme);
         
            foreach (var item in lstPlanManejo)
            {
                if (item.NUM_POA > 0)
                {
                    item.DATOS = dat_Informe_Digital.PlanManejoListarDatos(item.COD_THABILITANTE, item.COD_INFORME, item.NUM_POA);
                    item.DATOS.ListVerticePoaSupervisado = dat_Informe_Digital.ObtenerVerticePlanManejoSupervisado(item.COD_THABILITANTE, codInforme, item.NUM_POA);
                    item.DATOS.ListMaderaTrozas = this.ObtenerVolumenMaderaTrozas(item.COD_INFORME, item.NUM_POA);
                    item.DATOS.ListMaderaAserrada = this.ObtenerVolumenMaderaAserrada(item.COD_INFORME, item.NUM_POA);
                    //item.DATOS = dat_Informe_Digital.PlanManejoListarDatos(item.COD_THABILITANTE, item.COD_INFORME, item.NUM_POA);
                    item.DATOS.ListEspecieAproFaunaConcesion = dat_Informe_Digital.ObtenerEspeciesPlanManejoFaunaConcesiones(item.COD_THABILITANTE, item.NUM_POA);
                }
            }
            return lstPlanManejo;
        }
        private List<VM_VOLUMEN_MADERA_TROZAS> ObtenerVolumenMaderaTrozas(string COD_INFORME, int NUM_POA)
        {
            List<VM_VOLUMEN_MADERA_TROZAS> volumenMaderaTrozas = new List<VM_VOLUMEN_MADERA_TROZAS>();
            List<Ent_INFORME_TROZA_CAMPO> lstMaderaTrozas = new Dat_INFORME().RegMostrarDatosTrozaCampo(COD_INFORME, NUM_POA);
            decimal volumen = 0,factorConverion= Convert.ToDecimal(0.01);
            decimal pi = Convert.ToDecimal(3.1416);
            foreach (var item in lstMaderaTrozas)
            {
                volumen = Math.Round(pi*(((item.DAP1*factorConverion)+(item.DAP2*factorConverion))/8)*item.LC,2);
                volumenMaderaTrozas.Add(new VM_VOLUMEN_MADERA_TROZAS()
                {
                    COD_THABILITANTE = item.COD_THABILITANTE,
                    NUM_POA = item.NUM_POA,
                    COD_ESPECIES = item.COD_ESPECIES,
                    ESPECIES = item.ESPECIES,
                    TROZAS = item.RegEstado,
                    VL= volumen,
                    OBSERVACION=""
                });
            }
            return volumenMaderaTrozas;
        }
        private List<VM_VOLUMEN_MADERA_ASERRADA> ObtenerVolumenMaderaAserrada(string COD_INFORME,int NUM_POA)
        {
            List<VM_VOLUMEN_MADERA_ASERRADA> volumenMaderaAserrada = new List<VM_VOLUMEN_MADERA_ASERRADA>();
            List<Ent_INFORME_MADERA_ASERRADA> lstMaderaAserrada = new Dat_INFORME().RegMostrarDatosMaderaAserrada(COD_INFORME, NUM_POA);
            decimal volumenPT = 0,volumenAS=0, volumenRO=0; 
            foreach(var item in lstMaderaAserrada)
            {
                volumenPT = (item.ESPESOR * item.ANCHO * item.LARGO) / 12;
                volumenAS = volumenPT / 424;
                volumenRO = volumenPT / 220;
                
                volumenMaderaAserrada.Add(new VM_VOLUMEN_MADERA_ASERRADA()
                {
                    COD_THABILITANTE=item.COD_THABILITANTE,
                    NUM_POA=item.NUM_POA,
                    COD_ESPECIES=item.COD_ESPECIES,
                    ESPECIES=item.ESPECIES,
                    PIEZAS=item.PIEZAS,
                    VL_PT=Math.Round(volumenPT,2),
                    VL_ASERRADA=Math.Round(volumenAS,2),
                    VL_ROLLIZO=Math.Round(volumenRO,2),
                    OBSERVACION=""
                });
            }
            return volumenMaderaAserrada;
        }
        public List<VM_INFORME_DIGITAL> ObtenerCabeceraMaderable(string COD_INFORME)
        {
            List<VM_INFORME_DIGITAL> informeCabecera = new Dat_Informe_Digital().ObtenerCabeceraMaderable(COD_INFORME);
            foreach (var item in informeCabecera)
            {
                item.DURACION_PMF = this.AñoFechaInicioFechaFin(item.FECHA_INICIO_VIGENCIA_POA, item.FECHA_FIN_VIGENCIA_POA);
            }

            return informeCabecera;
        }
        public List<VM_INFORME_DIGITAL_VERTICE> ObtenerVerticeTH_PLANMaderable(string COD_THABILITANTE, int NUM_POA)
        {
            return new Dat_Informe_Digital().ObtenerVerticeTH_PLANMaderable(COD_THABILITANTE, NUM_POA);
        }
        public List<VM_EVALUACION_VERTICE> ObtenerEvaluacionVertice(string codInforme)
        {
            return new Dat_Informe_Digital().ObtenerEvaluacionVertice(codInforme);
        }
        public List<VM_INFORME_DIGITAL_ANTECEDENTE> ObtenerAntecedentesMaderable(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            return this.ConstruirAntecedentesMaderable(COD_INFORME, COD_THABILITANTE, COD_MTIPO);
        }
        private List<VM_INFORME_DIGITAL_ANTECEDENTE> ConstruirAntecedentesMaderable(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            List<VM_INFORME_DIGITAL_ANTECEDENTE> listResult = new List<VM_INFORME_DIGITAL_ANTECEDENTE>();
            List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD = new List<VM_CARTA_NOTIFICACION_ANTECEDENTE>();
            List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD = new List<VM_DOCUMENTO_ANTECEDENTE>();
            List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION = new List<VM_INFORME_SUSPENSION>();
            List<VM_INFORME_DIGITAL> antecedentes = new Dat_Informe_Digital().ObtenerAntecedentesMaderable(COD_INFORME, COD_THABILITANTE, ref NOTIFICACIONES_SITD, ref DOCUMENTOS_SITD, ref LIST_INFORME_SUSPENSION);
            int contador = 1, orden = 1;
            string descripcion = "", tipoDoc_NroDoc = "";
            string dependencia = "";

            foreach (var antecedente in antecedentes)
            {
                descripcion = "";
                if (contador == 1)
                {
                    tipoDoc_NroDoc = "";
                    //PARRAFO 1: TITULO HABILITANTE    
                    if (antecedente.TITULAR_TIPO_DOC == "0000001")
                    {
                        tipoDoc_NroDoc = $"DNI N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000002")
                    {
                        tipoDoc_NroDoc = $"pasaporte N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000006")
                    {
                        tipoDoc_NroDoc = $"RUC N° {antecedente.RUC_TITULAR}";
                    }
                    dependencia = antecedente.DEPENDENCIA.Trim();
                    if (!string.IsNullOrEmpty(antecedente.REPRESENTANTE_LEGAL))
                    { 
                        if(COD_MTIPO== "0000017") //Bosques locales
                            descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe el Contrato de Administración - Bosques Locales N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto(dependencia)} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc}, ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";
                        else descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe {this.Tipo_DE_TH(COD_MTIPO)} en un área de {antecedente.AREA_THABILITANTE} hectáreas de  {antecedente.MODALIDAD_TIPO} N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto(dependencia)} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc}, ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";

                    }
                    else
                    {
                        if(COD_MTIPO== "0000017")
                            descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe el Contrato de Administración - Bosques Locales N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto(dependencia)} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc} representado por {antecedente.REPRESENTANTE_LEGAL} ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";
                        else descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe {this.Tipo_DE_TH(COD_MTIPO)} en un área de {antecedente.AREA_THABILITANTE} hectáreas de {antecedente.MODALIDAD_TIPO} N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto(dependencia)} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc} representado por {antecedente.REPRESENTANTE_LEGAL} ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";

                    }
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.CONTRATO_TH_FECHA_INICIO});
                    //PARRAFO 3: ACTA DE RECEPCION
                    /*  descripcion = "Mediante [TIPO_DE_DOCUMENTO], con fecha de recepción [FECHA_RECEPCION] la [REMITENTE], remite al OSINFOR el [TIPO_DOCUMENTO_REMITIDO: según tabla documento previo del SITD] aprobado mediante Resolución N° [NRO_RESOLUCION_APROBACIÓN].";
                      orden = orden + 1;
                      listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden });
                      //PARRAFO 6: RESPUESTA A LA SOLICITUD DE INFORMACION A LA ARFFS
                      descripcion = "Mediante [TIPO_DE_DOCUMENTO], con fecha de recepción [FECHA_RECEPCION] la [REMITENTE], remite al OSINFOR [TIPO_DOCUMENTO_REMITIDO: según tabla documento previo del SITD] aprobado mediante Resolución N° [NRO_RESOLUCION_APROBACIÓN]";
                      orden = orden + 1;
                      listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden });*/
                    //Acta de insfecion ocular
                    if (antecedente.ACTA_SIN_INS_OCULAR != 1)
                    {
                        descripcion = $"Mediante Acta de inspección ocular N° {this.Texto(antecedente.ACTA_IOCULAR_NUM)} de fecha {this.FechaLetras(antecedente.ACTA_IOCULAR_FECHA)}, se suscribió el acta de inspección ocular elaborado por {this.Texto(antecedente.ACTA_PROFESIONAL_IOCULAR_POA)}.";
                        orden = orden + 1;
                        listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ACTA_IOCULAR_FECHA });
                    }                   

                    //PARRAFO 13: INFORME DE INSPECCIÓN OCULAR              
                    descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_IOCULAR_NUM)} presentado el {this.FechaLetras(antecedente.ITECNICO_IOCULAR_FECHA)}, elaborado por {this.Texto(antecedente.PROFESIONAL_IOCULAR_POA)}, se emitió los resultados obtenidos durante la inspección ocular realizada al área del {this.Texto(antecedente.NOMBRE_POA)} del titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_IOCULAR_FECHA});

                }


               
                if (antecedente.COD_TIPO_POA != "REFOR" && antecedente.COD_TIPO_POA != "MS")
                {
                    //PARRAFO 14: INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                    descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_RAPROBACION_NUM)} presentado el {this.FechaLetras(antecedente.ITECNICO_RAPROBACION_FECHA)}, elaborado por {this.Texto(antecedente.ITECNICO_RAPROBACION_PROFESIONAL)}, se recomienda aprobar la solicitud de aprovechamiento del {this.Texto(antecedente.NOMBRE_POA)} solicitado por el titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                    var tempResInfoReco = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                    if (tempResInfoReco == null)
                    {
                        orden = orden + 1;
                        listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_RAPROBACION_FECHA });

                    }
                    //PARRAFO 15: RESOLUCION DE APROBACION DEL PLAN DE MANEJO
                    descripcion = $"Mediante resolución N° {this.Texto(antecedente.RESOLUCION_POA)} de fecha {this.FechaLetras(antecedente.RESOLUCION_POA_FECHA)}, se aprueba el {this.Texto(antecedente.NOMBRE_POA)} a favor de {this.Texto(antecedente.TITULAR_SUPERVISADO)}, TH {this.Texto(antecedente.NUM_THABILITANTE)} vigente por {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_VIGENCIA_POA, antecedente.FECHA_FIN_VIGENCIA_POA)} años, en una superficie total de {antecedente.AREA_POA} ha, las especies y volúmenes se detallan a continuación";
                   
                    var tempResAprob = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                    if(tempResAprob == null)
                    {
                        orden = orden + 1;
                        listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { tipo = "RESOLUCION_APROBACION_PM", codTHabilitante = antecedente.COD_THABILITANTE, numPoa = antecedente.NUM_POA, NOMBRE_POA = antecedente.NOMBRE_POA, descripcion = descripcion, orden = orden, fecha = antecedente.RESOLUCION_POA_FECHA });
                    }                      
                    //PARRAFO 16: INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                    descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.NUMERO_RECOMIENDA_PGMF)} presentado el {this.FechaLetras(antecedente.FECHA_RECOMIENDA_PGMF)}, elaborado por {this.Texto(antecedente.CONSULTOR_PGMF)}, se recomienda aprobar la solicitud de aprovechamiento del {this.Texto(antecedente.NOMBRE_POA)} solicitado por el titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                    var tempInfAprobPGMF = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                    if (tempInfAprobPGMF == null)
                    {
                        orden = orden + 1;
                        listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RECOMIENDA_PGMF });

                    }
                    //PARRAFO 17: RESOLUCION DE APROBACION DEL PGMF
                    descripcion = $"Mediante resolución N° {this.Texto(antecedente.NUMERO_PGMF)} de fecha {this.FechaLetras(antecedente.FECHA_RESOLUCION_PGMF)}, se aprueba el {this.Texto(antecedente.NOMBRE_POA)} a favor de {this.Texto(antecedente.TITULAR_SUPERVISADO)}, TH {this.Texto(antecedente.NUM_THABILITANTE)} vigente por {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_PGMF, antecedente.FECHA_FIN_PGMF)} años, en una superficie total de {antecedente.AREA_PGMF} ha, las especies y volúmenes se detallan a continuación";
                    var tempResfAprobPGMF = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                    if (tempResfAprobPGMF == null)
                    {
                        orden = orden + 1;
                        listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RESOLUCION_PGMF });

                    }

                    contador = contador + 1;
                }
              
            }
            foreach (var notificacion in NOTIFICACIONES_SITD)
            {
                descripcion = "";
                if (notificacion.tabDetalle == "0000003")
                {//Carta de Notificación a Regente
                    descripcion = $"Mediante Carta N° {notificacion.nroCartaNotificacion} de fecha {this.FechaLetras(notificacion.fechaEmision)}, se notifica al REGENTE {this.Texto(notificacion.nombreRegente)}, a efectos de realizar una supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark> al {notificacion.nombrePlanManejo} aprobado mediante Resolución N° {notificacion.resolucionPlanManejo}, documento que fue recepcionado el {this.FechaLetras(notificacion.fechaNotificacion)} por el señor {this.Texto(notificacion.personaNotificacion)} ({notificacion.parentescoPerNotificacion}).";
                }
                else //if(notificacion.tabDetalle== "0000001")
                { //Carta de Supervisión
                    descripcion = $"Mediante Carta N° {notificacion.nroCartaNotificacion} de fecha {this.FechaLetras(notificacion.fechaEmision)}, se notifica al titular, a efectos de realizar una supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark> al {notificacion.nombrePlanManejo} aprobado mediante Resolución N° {notificacion.resolucionPlanManejo}, documento que fue recepcionado el {this.FechaLetras(notificacion.fechaNotificacion)} por el señor {this.Texto(notificacion.personaNotificacion)} ({this.Texto(notificacion.parentescoPerNotificacion)}).";
                }
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = notificacion.fechaEmision});
            }
            foreach (var documento in DOCUMENTOS_SITD)
            {
                descripcion = "";
                descripcion = $"Mediante {documento.tipoDocumento}, con fecha de recepción {this.FechaLetras(documento.fechaRecepcion)}, la {this.Texto(documento.remitente)}, remite al OSINFOR el {this.Texto(documento.tipoDocumentoRemitido)} aprobado mediante Resolución N° {this.Texto(documento.nroResolucionAprobacion)}";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = documento.fechaRecepcion });
            }
            //agregando antecedentes de suspension
            foreach (var suspension in LIST_INFORME_SUSPENSION)
            {
                descripcion = "";
                orden = orden + 1;
                descripcion = $"Con informe de suspensión N° {suspension.nroInforme} de fecha {this.FechaLetras(suspension.fechaCreacionInforme)}, carta N° {suspension.nroCartaNotificacion} de fecha {this.FechaLetras(suspension.fechaCartaNotificacion)}  <mark class=\"marker-yellow\" > ..............</mark>";
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = suspension.fechaCreacionInforme });
            }
           // List<VM_INFORME_DIGITAL_ANTECEDENTE> distinct = removeDuplicates(listResult);
            //ordenando por fecha lista a retornar
            var listResultOrden = listResult.OrderBy(x => x.fecha).ToList();


            return listResultOrden;
        }
        private  List<VM_INFORME_DIGITAL_ANTECEDENTE> removeDuplicates<VM_INFORME_DIGITAL_ANTECEDENTE>(List<VM_INFORME_DIGITAL_ANTECEDENTE> list)
        {
            return new HashSet<VM_INFORME_DIGITAL_ANTECEDENTE>(list).ToList();
        }
        public List<VM_EVALUACION_VERTICE> ObtenerVerticeTHSupervisado(string codInforme)
        {
            return new Dat_Informe_Digital().ObtenerVerticeTHSupervisado(codInforme);
        }
        #endregion

        #region "No maderable (No Maderables Aguaje,No Maderables Castaña, No Maderables Shiringa)"
        /*
             No Maderables Aguaje  - 0000018
             No Maderables Castaña - 0000008
             No Maderables Shiringa - 0000009
         * */

        public List<VM_INFORME_DIGITAL> ObtenerCabeceraNoMaderable(string COD_INFORME)
        {
            List<VM_INFORME_DIGITAL> informeCabecera = new Dat_Informe_Digital().ObtenerCabeceraNoMaderable(COD_INFORME);
            foreach (var item in informeCabecera)
            {
                item.DURACION_PMF = this.AñoFechaInicioFechaFin(item.FECHA_INICIO_VIGENCIA_POA, item.FECHA_FIN_VIGENCIA_POA);
            }

            return informeCabecera;
        }
        public List<VM_INFORME_DIGITAL_ANTECEDENTE> ObtenerAntecedentesNoMaderable(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            return this.ConstruirAntecedentesNoMaderable(COD_INFORME, COD_THABILITANTE, COD_MTIPO);
        }
        private List<VM_INFORME_DIGITAL_ANTECEDENTE> ConstruirAntecedentesNoMaderable(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            List<VM_INFORME_DIGITAL_ANTECEDENTE> listResult = new List<VM_INFORME_DIGITAL_ANTECEDENTE>();
            List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD = new List<VM_CARTA_NOTIFICACION_ANTECEDENTE>();
            List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD = new List<VM_DOCUMENTO_ANTECEDENTE>();
            List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION = new List<VM_INFORME_SUSPENSION>();
            List<VM_INFORME_DIGITAL> antecedentes = new Dat_Informe_Digital().ObtenerAntecedentesNoMaderable(COD_INFORME, COD_THABILITANTE, ref NOTIFICACIONES_SITD, ref DOCUMENTOS_SITD, ref LIST_INFORME_SUSPENSION);
            int contador = 1, orden = 1;
            string descripcion = "", tipoDoc_NroDoc = "";
            string dependencia = "";

            foreach (var antecedente in antecedentes)
            {
                descripcion = "";
                if (contador == 1)
                {
                    tipoDoc_NroDoc = "";
                    //PARRAFO 1: TITULO HABILITANTE    
                    if (antecedente.TITULAR_TIPO_DOC == "0000001")
                    {
                        tipoDoc_NroDoc = $"DNI N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000002")
                    {
                        tipoDoc_NroDoc = $"pasaporte N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000006")
                    {
                        tipoDoc_NroDoc = $"RUC N° {antecedente.RUC_TITULAR}";
                    }
                    dependencia = antecedente.DEPENDENCIA.Trim();
                    if (!string.IsNullOrEmpty(antecedente.REPRESENTANTE_LEGAL))
                    {
                        descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe {this.Tipo_DE_TH(COD_MTIPO)} en un área de {antecedente.AREA_THABILITANTE} hectáreas de  {antecedente.MODALIDAD_TIPO} N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto(dependencia)} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc}, ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";

                    }
                    else
                    {
                        descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe {this.Tipo_DE_TH(COD_MTIPO)} en un área de {antecedente.AREA_THABILITANTE} hectáreas de {antecedente.MODALIDAD_TIPO} N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto(dependencia)} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc} representado por {antecedente.REPRESENTANTE_LEGAL} ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";
                    }
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.CONTRATO_TH_FECHA_INICIO });
                    //PARRAFO 3: ACTA DE RECEPCION
                    /*  descripcion = "Mediante [TIPO_DE_DOCUMENTO], con fecha de recepción [FECHA_RECEPCION] la [REMITENTE], remite al OSINFOR el [TIPO_DOCUMENTO_REMITIDO: según tabla documento previo del SITD] aprobado mediante Resolución N° [NRO_RESOLUCION_APROBACIÓN].";
                      orden = orden + 1;
                      listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden });
                      //PARRAFO 6: RESPUESTA A LA SOLICITUD DE INFORMACION A LA ARFFS
                      descripcion = "Mediante [TIPO_DE_DOCUMENTO], con fecha de recepción [FECHA_RECEPCION] la [REMITENTE], remite al OSINFOR [TIPO_DOCUMENTO_REMITIDO: según tabla documento previo del SITD] aprobado mediante Resolución N° [NRO_RESOLUCION_APROBACIÓN]";
                      orden = orden + 1;
                      listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden });*/
                    //Acta de insfecion ocular
                    if (antecedente.ACTA_SIN_INS_OCULAR != 1)
                    {
                        descripcion = $"Mediante Acta de inspección ocular N° {this.Texto(antecedente.ACTA_IOCULAR_NUM)} de fecha {this.FechaLetras(antecedente.ACTA_IOCULAR_FECHA)}, se suscribió el acta de inspección ocular elaborado por {this.Texto(antecedente.ACTA_PROFESIONAL_IOCULAR_POA)}.";
                        orden = orden + 1;
                        listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ACTA_IOCULAR_FECHA });
                    }

                    //PARRAFO 13: INFORME DE INSPECCIÓN OCULAR              
                    descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_IOCULAR_NUM)} presentado el {this.FechaLetras(antecedente.ITECNICO_IOCULAR_FECHA)}, elaborado por {this.Texto(antecedente.PROFESIONAL_IOCULAR_POA)}, se emitió los resultados obtenidos durante la inspección ocular realizada al área del {this.Texto(antecedente.NOMBRE_POA)} del titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_IOCULAR_FECHA });

                }

                //PARRAFO 14: INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_RAPROBACION_NUM)} presentado el {this.FechaLetras(antecedente.ITECNICO_RAPROBACION_FECHA)}, elaborado por {this.Texto(antecedente.ITECNICO_RAPROBACION_PROFESIONAL)}, se recomienda aprobar la solicitud de aprovechamiento del {this.Texto(antecedente.NOMBRE_POA)} solicitado por el titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                var temInfTec = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                if (temInfTec == null)
                {
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_RAPROBACION_FECHA });

                }
                //PARRAFO 15: RESOLUCION DE APROBACION DEL PLAN DE MANEJO
                descripcion = $"Mediante resolución N° {this.Texto(antecedente.RESOLUCION_POA)} de fecha {this.FechaLetras(antecedente.RESOLUCION_POA_FECHA)}, se aprueba el {this.Texto(antecedente.NOMBRE_POA)} a favor de {this.Texto(antecedente.TITULAR_SUPERVISADO)}, TH {this.Texto(antecedente.NUM_THABILITANTE)} vigente por {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_VIGENCIA_POA, antecedente.FECHA_FIN_VIGENCIA_POA)} años, en una superficie total de {antecedente.AREA_POA} ha, las especies y volúmenes se detallan a continuación";
                var temResPM = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                if (temResPM == null)
                {
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { tipo = "RESOLUCION_APROBACION_PM", codTHabilitante = antecedente.COD_THABILITANTE, numPoa = antecedente.NUM_POA, descripcion = descripcion, orden = orden, fecha = antecedente.RESOLUCION_POA_FECHA });

                }
                //PARRAFO 16: INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.NUMERO_RECOMIENDA_PGMF)} presentado el {this.FechaLetras(antecedente.FECHA_RECOMIENDA_PGMF)}, elaborado por {this.Texto(antecedente.CONSULTOR_PGMF)}, se recomienda aprobar la solicitud de aprovechamiento del {this.Texto(antecedente.NOMBRE_POA)} solicitado por el titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                var temInfTecPGMF = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                if (temInfTecPGMF == null)
                {
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RECOMIENDA_PGMF });

                }
                //PARRAFO 17: RESOLUCION DE APROBACION DEL PGMF
                
                descripcion = $"Mediante resolución N° {this.Texto(antecedente.NUMERO_PGMF)} de fecha {this.FechaLetras(antecedente.FECHA_RESOLUCION_PGMF)}, se aprueba el {this.Texto(antecedente.NOMBRE_POA)} a favor de {this.Texto(antecedente.TITULAR_SUPERVISADO)}, TH {this.Texto(antecedente.NUM_THABILITANTE)} vigente por {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_PGMF, antecedente.FECHA_FIN_PGMF)} años, en una superficie total de {antecedente.AREA_PGMF} ha, las especies y volúmenes se detallan a continuación";
                var temResPM_PGMF = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                if (temResPM_PGMF == null)
                {
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RESOLUCION_PGMF });

                }

                contador = contador + 1;
            }
            foreach (var notificacion in NOTIFICACIONES_SITD)
            {
                descripcion = "";
                if (notificacion.tabDetalle == "0000003")
                {//Carta de Notificación a Regente
                    descripcion = $"Mediante Carta N° {notificacion.nroCartaNotificacion} de fecha {this.FechaLetras(notificacion.fechaEmision)}, se notifica al REGENTE {this.Texto(notificacion.nombreRegente)}, a efectos de realizar una supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark> al {notificacion.nombrePlanManejo} aprobado mediante Resolución N° {notificacion.resolucionPlanManejo}, documento que fue recepcionado el {this.FechaLetras(notificacion.fechaNotificacion)} por el señor {this.Texto(notificacion.personaNotificacion)} ({notificacion.parentescoPerNotificacion}).";
                }
                else //if(notificacion.tabDetalle== "0000001")
                { //Carta de Supervisión
                    descripcion = $"Mediante Carta N° {notificacion.nroCartaNotificacion} de fecha {this.FechaLetras(notificacion.fechaEmision)}, se notifica al titular, a efectos de realizar una supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark> al {notificacion.nombrePlanManejo} aprobado mediante Resolución N° {notificacion.resolucionPlanManejo}, documento que fue recepcionado el {this.FechaLetras(notificacion.fechaNotificacion)} por el señor {this.Texto(notificacion.personaNotificacion)} ({this.Texto(notificacion.parentescoPerNotificacion)}).";
                }
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = notificacion.fechaEmision  });
            }
            foreach (var documento in DOCUMENTOS_SITD)
            {
                descripcion = "";
                descripcion = $"Mediante {documento.tipoDocumento}, con fecha de recepción {this.FechaLetras(documento.fechaRecepcion)}, la {this.Texto(documento.remitente)}, remite al OSINFOR {this.Texto(documento.tipoDocumentoRemitido)} aprobado mediante Resolución N° {this.Texto(documento.nroResolucionAprobacion)}";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = documento.fechaRecepcion });
            }
            //agregando antecedentes de suspension
            foreach (var suspension in LIST_INFORME_SUSPENSION)
            {
                descripcion = "";
                orden = orden + 1;
                descripcion = $"Con informe de suspensión N° {suspension.nroInforme} de fecha {this.FechaLetras(suspension.fechaCreacionInforme)}, carta N° {suspension.nroCartaNotificacion} de fecha {this.FechaLetras(suspension.fechaCartaNotificacion)}  <mark class=\"marker-yellow\" > ..............</mark>";
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = suspension.fechaCreacionInforme  });
            }
            //ordenando por fecha lista a retornar
            var listResultOrden = listResult.OrderBy(x => x.fecha).ToList();


            return listResultOrden;
        }
        #endregion
      
     
        #region "No maderable (Ecoturismo, Conservación)"
        public List<VM_INFORME_DIGITAL> ObtenerCabeceraNoMaderableEC(string COD_INFORME)
        {
            List<VM_INFORME_DIGITAL> informeCabecera = new Dat_Informe_Digital().ObtenerCabeceraNoMaderableEC(COD_INFORME);
            foreach (var item in informeCabecera)
            {
                item.DURACION_PMF = this.AñoFechaInicioFechaFin(item.FECHA_INICIO_VIGENCIA_POA, item.FECHA_FIN_VIGENCIA_POA);
            }

            return informeCabecera;
        }
        public List<VM_INFORME_DIGITAL_ANTECEDENTE> ObtenerAntecedentesNoMaderableEC(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            return this.ConstruirAntecedentesNoMaderableEC(COD_INFORME, COD_THABILITANTE, COD_MTIPO);
        }
        private List<VM_INFORME_DIGITAL_ANTECEDENTE> ConstruirAntecedentesNoMaderableEC(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            List<VM_INFORME_DIGITAL_ANTECEDENTE> listResult = new List<VM_INFORME_DIGITAL_ANTECEDENTE>();
            List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD = new List<VM_CARTA_NOTIFICACION_ANTECEDENTE>();
            List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD = new List<VM_DOCUMENTO_ANTECEDENTE>();
            List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION = new List<VM_INFORME_SUSPENSION>();
            List<VM_INFORME_DIGITAL> antecedentes = new Dat_Informe_Digital().ObtenerAntecedentesNoMaderableEC(COD_INFORME, COD_THABILITANTE, ref NOTIFICACIONES_SITD, ref DOCUMENTOS_SITD, ref LIST_INFORME_SUSPENSION);
            int contador = 1, orden = 1;
            string descripcion = "", tipoDoc_NroDoc = "";


            foreach (var antecedente in antecedentes)
            {
                descripcion = "";
                if (contador == 1)
                {
                    tipoDoc_NroDoc = "";
                    //PARRAFO 1: TITULO HABILITANTE    
                    if (antecedente.TITULAR_TIPO_DOC == "0000001")
                    {
                        tipoDoc_NroDoc = $"DNI N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000002")
                    {
                        tipoDoc_NroDoc = $"pasaporte N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000006")
                    {
                        tipoDoc_NroDoc = $"RUC N° {antecedente.RUC_TITULAR}";
                    }
                    if (!string.IsNullOrEmpty(antecedente.REPRESENTANTE_LEGAL))
                    {
                        descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe {this.Tipo_DE_TH(COD_MTIPO)} en un área de {antecedente.AREA_THABILITANTE} hectáreas de  {antecedente.MODALIDAD_TIPO} N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto("")} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc}, ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";

                    }
                    else
                    {
                        descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe {this.Tipo_DE_TH(COD_MTIPO)} en un área de {antecedente.AREA_THABILITANTE} hectáreas de {antecedente.MODALIDAD_TIPO} N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto("")} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc} representado por {antecedente.REPRESENTANTE_LEGAL} ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";
                    }
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.CONTRATO_TH_FECHA_INICIO });
                    //PARRAFO 3: ACTA DE RECEPCION
                    /*  descripcion = "Mediante [TIPO_DE_DOCUMENTO], con fecha de recepción [FECHA_RECEPCION] la [REMITENTE], remite al OSINFOR el [TIPO_DOCUMENTO_REMITIDO: según tabla documento previo del SITD] aprobado mediante Resolución N° [NRO_RESOLUCION_APROBACIÓN].";
                      orden = orden + 1;
                      listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden });
                      //PARRAFO 6: RESPUESTA A LA SOLICITUD DE INFORMACION A LA ARFFS
                      descripcion = "Mediante [TIPO_DE_DOCUMENTO], con fecha de recepción [FECHA_RECEPCION] la [REMITENTE], remite al OSINFOR [TIPO_DOCUMENTO_REMITIDO: según tabla documento previo del SITD] aprobado mediante Resolución N° [NRO_RESOLUCION_APROBACIÓN]";
                      orden = orden + 1;
                      listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden });*/
                    //PARRAFO 13: INFORME DE INSPECCIÓN OCULAR              
                    descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_IOCULAR_NUM)} presentado el {this.FechaLetras(antecedente.ITECNICO_IOCULAR_FECHA)}, elaborado por {this.Texto(antecedente.PROFESIONAL_IOCULAR_POA)}, se emitió los resultados obtenidos durante la inspección ocular realizada al área del plan de manejo {this.Texto(antecedente.NOMBRE_POA)} del titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_IOCULAR_FECHA  });

                }

                //PARRAFO 14: INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_RAPROBACION_NUM)} presentado el {this.FechaLetras(antecedente.ITECNICO_RAPROBACION_FECHA)}, elaborado por {this.Texto(antecedente.ITECNICO_RAPROBACION_PROFESIONAL)}, se recomienda aprobar la solicitud de aprovechamiento del plan de manejo{this.Texto(antecedente.NOMBRE_POA)} solicitado por el titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                var temInfTect = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                if (temInfTect == null)
                {
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_RAPROBACION_FECHA });

                }
                //PARRAFO 15: RESOLUCION DE APROBACION DEL PLAN DE MANEJO

                descripcion = $"Mediante resolución N° {this.Texto(antecedente.RESOLUCION_POA)} de fecha {this.FechaLetras(antecedente.RESOLUCION_POA_FECHA)}, se aprueba el plan de manejo {this.Texto(antecedente.NOMBRE_POA)} a favor de {this.Texto(antecedente.TITULAR_SUPERVISADO)}, TH {this.Texto(antecedente.NUM_THABILITANTE)} vigente por {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_VIGENCIA_POA, antecedente.FECHA_FIN_VIGENCIA_POA)} años, en una superficie total de {this.Texto((antecedente.AREA_POA.ToString()))} ha, las especies y volúmenes se detallan a continuación";
                var temResInf = listResult.Where(x => x.descripcion == descripcion).FirstOrDefault();
                if (temResInf == null)
                {
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { tipo = "RESOLUCION_APROBACION_PM", codTHabilitante = antecedente.COD_THABILITANTE, numPoa = antecedente.NUM_POA, descripcion = descripcion, orden = orden, fecha = antecedente.RESOLUCION_POA_FECHA });

                }
                //PARRAFO 16: INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                /*
                 descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.NUMERO_RECOMIENDA_PGMF)} presentado el {this.FechaLetras(antecedente.FECHA_RECOMIENDA_PGMF)}, elaborado por {this.Texto(antecedente.CONSULTOR_PGMF)}, se recomienda aprobar la solicitud de aprovechamiento del {this.Texto(antecedente.NOMBRE_POA)} solicitado por el titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                 orden = orden + 1;
                 listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RECOMIENDA_PGMF ?? DateTime.Now });
                 */
                //PARRAFO 17: RESOLUCION DE APROBACION DEL PGMF
                /*
                descripcion = $"Mediante resolución N° {this.Texto(antecedente.NUMERO_PGMF)} de fecha {this.FechaLetras(antecedente.FECHA_RESOLUCION_PGMF)}, se aprueba el {this.Texto(antecedente.NOMBRE_POA)} a favor de {this.Texto(antecedente.TITULAR_SUPERVISADO)}, TH {this.Texto(antecedente.NUM_THABILITANTE)} vigente por {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_PGMF, antecedente.FECHA_FIN_PGMF)} años, en una superficie total de {antecedente.AREA_PGMF} ha, las especies y volúmenes se detallan a continuación";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RESOLUCION_PGMF ?? DateTime.Now });
                */
                contador = contador + 1;
            }
            foreach (var notificacion in NOTIFICACIONES_SITD)
            {
                descripcion = "";
                if (notificacion.tabDetalle == "0000003")
                {//Carta de Notificación a Regente
                    descripcion = $"Mediante Carta N° {notificacion.nroCartaNotificacion} de fecha {this.FechaLetras(notificacion.fechaEmision)}, se notifica al REGENTE {this.Texto(notificacion.nombreRegente)}, a efectos de realizar una supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark> al {notificacion.nombrePlanManejo} aprobado mediante Resolución N° {notificacion.resolucionPlanManejo}, documento que fue recepcionado el {this.FechaLetras(notificacion.fechaNotificacion)} por el señor {this.Texto(notificacion.personaNotificacion)} ({notificacion.parentescoPerNotificacion}).";
                }
                else //if(notificacion.tabDetalle== "0000001")
                { //Carta de Supervisión
                    descripcion = $"Mediante Carta N° {notificacion.nroCartaNotificacion} de fecha {this.FechaLetras(notificacion.fechaEmision)}, se notifica al titular, a efectos de realizar una supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark> al {notificacion.nombrePlanManejo} aprobado mediante Resolución N° {notificacion.resolucionPlanManejo}, documento que fue recepcionado el {this.FechaLetras(notificacion.fechaNotificacion)} por el señor {this.Texto(notificacion.personaNotificacion)} ({this.Texto(notificacion.parentescoPerNotificacion)}).";
                }
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = notificacion.fechaEmision });
            }
            foreach (var documento in DOCUMENTOS_SITD)
            {
                descripcion = "";
                descripcion = $"Mediante {documento.tipoDocumento}, con fecha de recepción {this.FechaLetras(documento.fechaRecepcion)}, la {this.Texto(documento.remitente)}, remite al OSINFOR {this.Texto(documento.tipoDocumentoRemitido)} aprobado mediante Resolución N° {this.Texto(documento.nroResolucionAprobacion)}";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = documento.fechaRecepcion });
            }
            //agregando antecedentes de suspension
            foreach (var suspension in LIST_INFORME_SUSPENSION)
            {
                descripcion = "";
                orden = orden + 1;
                descripcion = $"Con informe de suspensión N° {suspension.nroInforme} de fecha {this.FechaLetras(suspension.fechaCreacionInforme)}, carta N° {suspension.nroCartaNotificacion} de fecha {this.FechaLetras(suspension.fechaCartaNotificacion)}  <mark class=\"marker-yellow\" > ..............</mark>";
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = suspension.fechaCreacionInforme });
            }
            //ordenando por fecha lista a retornar
            var listResultOrden = listResult.OrderBy(x => x.fecha).ToList();


            return listResultOrden;
        }
        #endregion
        #region "Fauna"
        public List<VM_INFORME_DIGITAL> ObtenerCabeceraFauna(string COD_INFORME)
        {
            List<VM_INFORME_DIGITAL> informeCabecera = new Dat_Informe_Digital().ObtenerCabeceraFauna(COD_INFORME);
            foreach (var item in informeCabecera)
            {
                item.DURACION_PMF = this.AñoFechaInicioFechaFin(item.FECHA_INICIO_VIGENCIA_POA, item.FECHA_FIN_VIGENCIA_POA);
            }

            return informeCabecera;
        }
        public List<VM_INFORME_DIGITAL_ANTECEDENTE> ObtenerAntecedentesFauna(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            return this.ConstruirAntecedentesFauna(COD_INFORME, COD_THABILITANTE, COD_MTIPO);
        }
        private List<VM_INFORME_DIGITAL_ANTECEDENTE> ConstruirAntecedentesFauna(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            List<VM_INFORME_DIGITAL_ANTECEDENTE> listResult = new List<VM_INFORME_DIGITAL_ANTECEDENTE>();
            List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD = new List<VM_CARTA_NOTIFICACION_ANTECEDENTE>();
            List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD = new List<VM_DOCUMENTO_ANTECEDENTE>();
            List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION = new List<VM_INFORME_SUSPENSION>();
            List<VM_INFORME_DIGITAL> antecedentes = new Dat_Informe_Digital().ObtenerAntecedentesFauna(COD_INFORME, COD_THABILITANTE, ref NOTIFICACIONES_SITD, ref DOCUMENTOS_SITD, ref LIST_INFORME_SUSPENSION);
            int contador = 1, orden = 1;
            string descripcion = ""; //tipoDoc_NroDoc = "";
            string titularSupervisado = "",numTH="",modalidadTipo="";

            foreach (var antecedente in antecedentes)
            {
                descripcion = "";
                if (contador == 1)
                {  /*
                    tipoDoc_NroDoc = "";
                    //PARRAFO 1: TITULO HABILITANTE    
                    if (antecedente.TITULAR_TIPO_DOC == "0000001")
                    {
                        tipoDoc_NroDoc = $"DNI N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000002")
                    {
                        tipoDoc_NroDoc = $"pasaporte N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000006")
                    {
                        tipoDoc_NroDoc = $"RUC N° {antecedente.RUC_TITULAR}";
                    }
                    if (!string.IsNullOrEmpty(antecedente.REPRESENTANTE_LEGAL))
                    {
                        descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe {this.Tipo_DE_TH(COD_MTIPO)} en un área de {antecedente.AREA_THABILITANTE} hectáreas de  {antecedente.MODALIDAD_TIPO} N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto("")} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc}, ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";

                    }
                    else
                    {
                        descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} se suscribe {this.Tipo_DE_TH(COD_MTIPO)} en un área de {antecedente.AREA_THABILITANTE} hectáreas de {antecedente.MODALIDAD_TIPO} N° {antecedente.NUM_THABILITANTE} celebrado entre {this.Texto("")} y de la otra parte el titular {antecedente.TITULAR_SUPERVISADO}, identificado con {tipoDoc_NroDoc} representado por {antecedente.REPRESENTANTE_LEGAL} ubicado en {antecedente.UBIGEO_THABILITANTE} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años del {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)} al {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_FIN)}";
                    }
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.CONTRATO_TH_FECHA_INICIO });
                    */
                    titularSupervisado = antecedente.TITULAR_SUPERVISADO;
                    numTH = antecedente.NUM_THABILITANTE;
                    modalidadTipo = antecedente.MODALIDAD_TIPO;
                    //Resolución que aprueba el proyecto - Obtenido de TH
                    descripcion = $"Mediante Resolución {this.Texto(antecedente.R_PROYECTO_APRUEBA)}, de fecha {this.FechaLetras(antecedente.R_PROYECTO_APRUEBA_FECHA)}, se aprobó el proyecto de {this.Texto(antecedente.MODALIDAD_TIPO)} {this.Texto(antecedente.NUM_THABILITANTE)}, ubicado en el sector {this.Texto(antecedente.SECTOR)}, {this.Texto(antecedente.UBIGEO_THABILITANTE)}, a favor del titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.R_PROYECTO_APRUEBA_FECHA });

                    //Resolución que autoriza el proyecto - Obtenido de TH
                    descripcion = $"Mediante Resolución {this.Texto(antecedente.R_PROYECTO_AUTORIZA)}, de fecha {this.FechaLetras(antecedente.R_PROYECTO_AUTORIZA_FECHA)}, se autorizó el funcionamiento de {this.Texto(antecedente.MODALIDAD_TIPO)} {this.Texto(antecedente.NUM_THABILITANTE)}, ubicado en el sector {this.Texto(antecedente.SECTOR)}, {this.Texto(antecedente.UBIGEO_THABILITANTE)}, a favor del titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.R_PROYECTO_AUTORIZA_FECHA });


                    /*
                    //PARRAFO 13: INFORME DE INSPECCIÓN OCULAR              
                    descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_IOCULAR_NUM)} presentado el {this.FechaLetras(antecedente.ITECNICO_IOCULAR_FECHA)}, elaborado por {this.Texto(antecedente.PROFESIONAL_IOCULAR_POA)}, se emitió los resultados obtenidos durante la inspección ocular realizada al área del plan de manejo {this.Texto(antecedente.NOMBRE_POA)} del titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_IOCULAR_FECHA  });
                    */
                    //PARRAFO 14: INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                    descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_RAPROBACION_NUM)} presentado el {this.FechaLetras(antecedente.ITECNICO_RAPROBACION_FECHA)}, elaborado por {this.Texto(antecedente.ITECNICO_RAPROBACION_PROFESIONAL)}, se recomendó aprobar el proyecto de {this.Texto(antecedente.MODALIDAD_TIPO)} {this.Texto(antecedente.NUM_THABILITANTE)}, de titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_RAPROBACION_FECHA });

                    /*
                    descripcion = $"Mediante Oficio N° {this.Texto("")} de fecha {this.FechaLetras(null)}, la DSFFS del OSINFOR solicitó al {this.Texto("")}, la remisión de los documentos de gestión de {this.Texto(antecedente.MODALIDAD_TIPO)} {this.Texto(antecedente.NUM_THABILITANTE)}";
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = DateTime.Now });

                    descripcion = $"Mediante Oficio N° {this.Texto("")} de fecha {this.FechaLetras(null)}, el {this.Texto("")}, remitió al OSINFOR, la documentación solicitada con el  Oficio N° {this.Texto("")}";
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = DateTime.Now });
                    */
                }

                //PARRAFO 15: RESOLUCION DE APROBACION DEL PLAN DE MANEJO

                //descripcion = $"Mediante resolución N° {this.Texto(antecedente.RESOLUCION_POA)} de fecha {this.FechaLetras(antecedente.RESOLUCION_POA_FECHA)}, se aprueba el plan de manejo {this.Texto(antecedente.NOMBRE_POA)} a favor de {this.Texto(antecedente.TITULAR_SUPERVISADO)}, TH {this.Texto(antecedente.NUM_THABILITANTE)} vigente por {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_VIGENCIA_POA, antecedente.FECHA_FIN_VIGENCIA_POA)} años, en una superficie total de {this.Texto((antecedente.AREA_POA.ToString()))} ha, las especies y volúmenes se detallan a continuación";
                //orden = orden + 1;
                //listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { tipo = "RESOLUCION_APROBACION_PM", codTHabilitante = antecedente.COD_THABILITANTE, numPoa = antecedente.NUM_POA, descripcion = descripcion, orden = orden, fecha = antecedente.RESOLUCION_POA_FECHA  });
                //PARRAFO 16: INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                /*
                 descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.NUMERO_RECOMIENDA_PGMF)} presentado el {this.FechaLetras(antecedente.FECHA_RECOMIENDA_PGMF)}, elaborado por {this.Texto(antecedente.CONSULTOR_PGMF)}, se recomienda aprobar la solicitud de aprovechamiento del {this.Texto(antecedente.NOMBRE_POA)} solicitado por el titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                 orden = orden + 1;
                 listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RECOMIENDA_PGMF ?? DateTime.Now });
                 */
                //PARRAFO 17: RESOLUCION DE APROBACION DEL PGMF
                /*
                descripcion = $"Mediante resolución N° {this.Texto(antecedente.NUMERO_PGMF)} de fecha {this.FechaLetras(antecedente.FECHA_RESOLUCION_PGMF)}, se aprueba el {this.Texto(antecedente.NOMBRE_POA)} a favor de {this.Texto(antecedente.TITULAR_SUPERVISADO)}, TH {this.Texto(antecedente.NUM_THABILITANTE)} vigente por {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_PGMF, antecedente.FECHA_FIN_PGMF)} años, en una superficie total de {antecedente.AREA_PGMF} ha, las especies y volúmenes se detallan a continuación";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RESOLUCION_PGMF ?? DateTime.Now });
                */
                contador = contador + 1;
            }
         
            foreach (var notificacion in NOTIFICACIONES_SITD)
            {
                descripcion = "";
                if (notificacion.tabDetalle == "0000003")
                {//Carta de Notificación a Regente
                    descripcion = $"Mediante Carta N° {notificacion.nroCartaNotificacion} de fecha {this.FechaLetras(notificacion.fechaEmision)}, se notifica al REGENTE {this.Texto(notificacion.nombreRegente)}, a efectos de realizar una supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark> al título {this.Texto(numTH)} aprobado mediante Resolución N° {notificacion.resolucionPlanManejo}, documento que fue recepcionado el {this.FechaLetras(notificacion.fechaNotificacion)} por el señor {this.Texto(notificacion.personaNotificacion)} ({notificacion.parentescoPerNotificacion}).";
                }
                else //if(notificacion.tabDetalle== "0000001")
                { //Carta de Supervisión
                    descripcion = $"Mediante Carta N° {notificacion.nroCartaNotificacion} de fecha {this.FechaLetras(notificacion.fechaEmision)}, notificada el día  {this.FechaLetras(notificacion.fechaNotificacion)}, se comunicó al titular {this.Texto(titularSupervisado)}, titular de {this.Texto(modalidadTipo)} {this.Texto(numTH)}, la realización de la supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark>, a realizarse el día {this.Texto("")}";
                }
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = notificacion.fechaEmision });
            }
            foreach (var documento in DOCUMENTOS_SITD)
            {
                descripcion = "";
                descripcion = $"Mediante {documento.tipoDocumento}, con fecha de recepción {this.FechaLetras(documento.fechaRecepcion)}, la {this.Texto(documento.remitente)}, remite al OSINFOR {this.Texto(documento.tipoDocumentoRemitido)} aprobado mediante Resolución N° {this.Texto(documento.nroResolucionAprobacion)}";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = documento.fechaRecepcion  });
            }
            //agregando antecedentes de suspension
            foreach (var suspension in LIST_INFORME_SUSPENSION)
            {
                descripcion = "";
                orden = orden + 1;
                descripcion = $"Con informe de suspensión N° {suspension.nroInforme} de fecha {this.FechaLetras(suspension.fechaCreacionInforme)}, carta N° {suspension.nroCartaNotificacion} de fecha {this.FechaLetras(suspension.fechaCartaNotificacion)}  <mark class=\"marker-yellow\" > ..............</mark>";
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = suspension.fechaCreacionInforme  });
            }
            descripcion = $"Mediante Acta de Supervisión de fecha {this.Texto("")}, el OSINFOR, representado por {this.Texto("")}, registra la realización de la supervisión al {this.Texto(modalidadTipo)} {this.Texto(numTH)}, con la presencia de {this.Texto("")}";
            orden = orden + 1;
            listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = DateTime.Now });

            //ordenando por fecha lista a retornar
            var listResultOrden = listResult.OrderBy(x => x.orden).ToList();

            return listResultOrden;
        }
        public List<VM_INFORME_DIGITAL_VERTICE> ObtenerVerticeTH_Fauna(string COD_THABILITANTE)
        {
            return new Dat_Informe_Digital().ObtenerVerticeTH_Fauna(COD_THABILITANTE);
        }
        public List<VM_INFORME_DIGITAL> ObtenerCabeceraFaunaConcesiones(string COD_INFORME)
        {
            List<VM_INFORME_DIGITAL> informeCabecera = new Dat_Informe_Digital().ObtenerCabeceraFaunaConcesiones(COD_INFORME);
            foreach (var item in informeCabecera)
            {
                item.DURACION_PMF = this.AñoFechaInicioFechaFin(item.FECHA_INICIO_VIGENCIA_POA, item.FECHA_FIN_VIGENCIA_POA);
            }

            return informeCabecera;
        }
        public List<VM_INFORME_DIGITAL_ANTECEDENTE> ObtenerAntecedentesFaunaConcesiones(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            return this.ConstruirAntecedentesFaunaConcesiones(COD_INFORME, COD_THABILITANTE, COD_MTIPO);
        }
        private List<VM_INFORME_DIGITAL_ANTECEDENTE> ConstruirAntecedentesFaunaConcesiones(string COD_INFORME, string COD_THABILITANTE, string COD_MTIPO)
        {
            List<VM_INFORME_DIGITAL_ANTECEDENTE> listResult = new List<VM_INFORME_DIGITAL_ANTECEDENTE>();
            List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD = new List<VM_CARTA_NOTIFICACION_ANTECEDENTE>();
            List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD = new List<VM_DOCUMENTO_ANTECEDENTE>();
            List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION = new List<VM_INFORME_SUSPENSION>();
            List<VM_INFORME_DIGITAL> antecedentes = new Dat_Informe_Digital().ObtenerAntecedentesFaunaConcesiones(COD_INFORME, COD_THABILITANTE, ref NOTIFICACIONES_SITD, ref DOCUMENTOS_SITD, ref LIST_INFORME_SUSPENSION);
            int contador = 1, orden = 1;
            string descripcion = "", tipoDoc_NroDoc = "";


            foreach (var antecedente in antecedentes)
            {
                descripcion = "";
                if (contador == 1)
                {
                    tipoDoc_NroDoc = "";
                    //PARRAFO 1: TITULO HABILITANTE    
                    if (antecedente.TITULAR_TIPO_DOC == "0000001")
                    {
                        tipoDoc_NroDoc = $"DNI N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000002")
                    {
                        tipoDoc_NroDoc = $"pasaporte N° {antecedente.DOCUMENTO_TITULAR}";
                    }
                    else if (antecedente.TITULAR_TIPO_DOC == "0000006")
                    {
                        tipoDoc_NroDoc = $"RUC N° {antecedente.RUC_TITULAR}";
                    }
                    descripcion = $"Con fecha {this.FechaLetras(antecedente.CONTRATO_TH_FECHA_INICIO)}, el Estado Peruano actuando a través de <mark class=\"marker-yellow\" > ..........</mark> y {antecedente.TITULAR_SUPERVISADO}. Suscriben el contrato de concesión para manejo de fauna silvestre N° {antecedente.NUM_THABILITANTE} en un área de {antecedente.AREA_THABILITANTE} hectáreas por un periodo de {this.AñoFechaInicioFechaFin(antecedente.CONTRATO_TH_FECHA_INICIO, antecedente.CONTRATO_TH_FECHA_FIN)} años";
                  
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.CONTRATO_TH_FECHA_INICIO });
                    //PARRAFO 3: ACTA DE RECEPCION
                    /*  descripcion = "Mediante [TIPO_DE_DOCUMENTO], con fecha de recepción [FECHA_RECEPCION] la [REMITENTE], remite al OSINFOR el [TIPO_DOCUMENTO_REMITIDO: según tabla documento previo del SITD] aprobado mediante Resolución N° [NRO_RESOLUCION_APROBACIÓN].";
                      orden = orden + 1;
                      listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden });
                      //PARRAFO 6: RESPUESTA A LA SOLICITUD DE INFORMACION A LA ARFFS
                      descripcion = "Mediante [TIPO_DE_DOCUMENTO], con fecha de recepción [FECHA_RECEPCION] la [REMITENTE], remite al OSINFOR [TIPO_DOCUMENTO_REMITIDO: según tabla documento previo del SITD] aprobado mediante Resolución N° [NRO_RESOLUCION_APROBACIÓN]";
                      orden = orden + 1;
                      listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden });*/
                    //PARRAFO 13: INFORME DE INSPECCIÓN OCULAR              
                    descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_IOCULAR_NUM)} con fecha {this.FechaLetras(antecedente.ITECNICO_IOCULAR_FECHA)}, la ARFFS <mark class=\"marker-yellow\" > ..........</mark> detalla los resultados obtenidos durante la inspección ocular al área del plan de manejo presentado por el titular {antecedente.TITULAR_SUPERVISADO}.";
                                       
                    orden = orden + 1;
                    listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_IOCULAR_FECHA });

                }

                //PARRAFO 14: INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.ITECNICO_RAPROBACION_NUM)} con fecha {this.FechaLetras(antecedente.ITECNICO_RAPROBACION_FECHA)}, la ARFFS <mark class=\"marker-yellow\" > ..........</mark> evalúa el plan de manejo de fauna silvestre y recomienda su aprobación";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.ITECNICO_RAPROBACION_FECHA });
                //PARRAFO 15: RESOLUCION DE APROBACION DEL PLAN DE MANEJO

                descripcion = $"Mediante resolución N° {this.Texto(antecedente.RESOLUCION_POA)} con fecha {this.FechaLetras(antecedente.RESOLUCION_POA_FECHA)}, la ARFFS <mark class=\"marker-yellow\" > ..........</mark> aprueba el plan de manejo {this.Texto(antecedente.NOMBRE_POA)} en una superficie de {this.Texto((antecedente.AREA_POA.ToString()))} por un periodo de {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_VIGENCIA_POA, antecedente.FECHA_FIN_VIGENCIA_POA)} correspondiente al contrato de concesión de fauna silvestre N° {this.Texto(antecedente.NUM_THABILITANTE)}, las especies y cantidades se detallan a continuación:";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { tipo = "RESOLUCION_APROBACION_PM", codTHabilitante = antecedente.COD_THABILITANTE, numPoa = antecedente.NUM_POA, descripcion = descripcion, orden = orden, fecha = antecedente.RESOLUCION_POA_FECHA });
                //PARRAFO 16: INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                /*
                 descripcion = $"Mediante INFORME TÉCNICO N° {this.Texto(antecedente.NUMERO_RECOMIENDA_PGMF)} presentado el {this.FechaLetras(antecedente.FECHA_RECOMIENDA_PGMF)}, elaborado por {this.Texto(antecedente.CONSULTOR_PGMF)}, se recomienda aprobar la solicitud de aprovechamiento del {this.Texto(antecedente.NOMBRE_POA)} solicitado por el titular {this.Texto(antecedente.TITULAR_SUPERVISADO)}.";
                 orden = orden + 1;
                 listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RECOMIENDA_PGMF ?? DateTime.Now });
                 */
                //PARRAFO 17: RESOLUCION DE APROBACION DEL PGMF
                /*
                descripcion = $"Mediante resolución N° {this.Texto(antecedente.NUMERO_PGMF)} de fecha {this.FechaLetras(antecedente.FECHA_RESOLUCION_PGMF)}, se aprueba el {this.Texto(antecedente.NOMBRE_POA)} a favor de {this.Texto(antecedente.TITULAR_SUPERVISADO)}, TH {this.Texto(antecedente.NUM_THABILITANTE)} vigente por {this.AñoFechaInicioFechaFin(antecedente.FECHA_INICIO_PGMF, antecedente.FECHA_FIN_PGMF)} años, en una superficie total de {antecedente.AREA_PGMF} ha, las especies y volúmenes se detallan a continuación";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = antecedente.FECHA_RESOLUCION_PGMF ?? DateTime.Now });
                */
                contador = contador + 1;
            }
            foreach (var notificacion in NOTIFICACIONES_SITD)
            {
                descripcion = "";
                if (notificacion.tabDetalle == "0000003")
                {//Carta de Notificación a Regente
                    descripcion = $"Mediante Carta N° {this.Texto(notificacion.nroCartaNotificacion)} de fecha {this.FechaLetras(notificacion.fechaEmision)}, se notifica al REGENTE {this.Texto(notificacion.nombreRegente)}, a efectos de realizar una supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark> al {this.Texto(notificacion.nombrePlanManejo)} aprobado mediante Resolución N° {this.Texto(notificacion.resolucionPlanManejo)}, documento que fue recepcionado el {this.FechaLetras(notificacion.fechaNotificacion)} por el señor {this.Texto(notificacion.personaNotificacion)} ({this.Texto(notificacion.parentescoPerNotificacion)}).";
                }
                else //if(notificacion.tabDetalle== "0000001")
                { //Carta de Supervisión
                    descripcion = $"Mediante Carta N° {this.Texto(notificacion.nroCartaNotificacion)} de fecha {this.FechaLetras(notificacion.fechaEmision)}, se notifica al titular, a efectos de realizar una supervisión <mark class=\"marker-yellow\">[ORDINARIA/EXTRAORDINARIA]</mark> al {this.Texto(notificacion.nombrePlanManejo)} aprobado mediante Resolución N° {this.Texto(notificacion.resolucionPlanManejo)}, documento que fue recepcionado el {this.FechaLetras(notificacion.fechaNotificacion)} por el señor {this.Texto(notificacion.personaNotificacion)} ({this.Texto(notificacion.parentescoPerNotificacion)}).";
                }
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = notificacion.fechaEmision });
            }
            foreach (var documento in DOCUMENTOS_SITD)
            {
                descripcion = "";
                descripcion = $"Mediante {this.Texto(documento.tipoDocumento)}, con fecha de recepción {this.FechaLetras(documento.fechaRecepcion)}, la {this.Texto(documento.remitente)}, remite al OSINFOR {this.Texto(documento.tipoDocumentoRemitido)} aprobado mediante Resolución N° {this.Texto(documento.nroResolucionAprobacion)}";
                orden = orden + 1;
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = documento.fechaRecepcion });
            }
            //agregando antecedentes de suspension
            foreach (var suspension in LIST_INFORME_SUSPENSION)
            {
                descripcion = "";
                orden = orden + 1;
                descripcion = $"Con informe de suspensión N° {suspension.nroInforme} de fecha {this.FechaLetras(suspension.fechaCreacionInforme)}, carta N° {suspension.nroCartaNotificacion} de fecha {this.FechaLetras(suspension.fechaCartaNotificacion)}  <mark class=\"marker-yellow\" > ..............</mark>";
                listResult.Add(new VM_INFORME_DIGITAL_ANTECEDENTE() { descripcion = descripcion, orden = orden, fecha = suspension.fechaCreacionInforme });
            }
            //ordenando por fecha lista a retornar
            var listResultOrden = listResult.OrderBy(x => x.fecha).ToList();


            return listResultOrden;
        }
        public List<VM_INFORME_DIGITAL_PM> PlanManejoListarMaderableFaunaConcesiones(String codInforme)
        {
            Dat_Informe_Digital dat_Informe_Digital = new Dat_Informe_Digital();

            List<VM_INFORME_DIGITAL_PM> lstPlanManejo = dat_Informe_Digital.PlanManejoListar(codInforme);

            foreach (var item in lstPlanManejo)
            {
                if (item.NUM_POA > 0)
                {
                    item.DATOS.ListEspecieApro = dat_Informe_Digital.ObtenerEspeciesPlanManejoFaunaConcesiones(item.COD_THABILITANTE, item.NUM_POA);
                     
                }
            }
            return lstPlanManejo;
        }
        #endregion
    }
}
