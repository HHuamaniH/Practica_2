using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_InformeLegal
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public string hdfCodInfLegal { get; set; }
        public string hdfCodTipoIlegal { get; set; }
        public string txtNumIlegal { get; set; }
        public string txtTipoInfLegal { get; set; }
        public string txtProfesional { get; set; }
        public string hdfCodProfesional { get; set; }
        public string txtFechaLegal { get; set; }
        public bool txtPresentoProyecto { get; set; }
        public bool txtInfDirectoral { get; set; }
        public bool txtInfSubDirectoral { get; set; }
        public string txtObservaciones { get; set; }
        public string txtTituloModal { get; set; }
        //para el tipo de de recomendacion
        public string txtIdRecomendacion { get; set; }
        //variables para los articulos
        public string txtIdArticulo { get; set; }
        public string txtIdEspecie { get; set; }

        public string txtDescripcionArticulo { get; set; }

        //informacion falsa SELECT * FROM DOC_osinfor_erp_migracion.ILEGAL_EVA_INF_SUP agregar columnas y selecteds pendientes
        public bool chkInexEspecie { get; set; }
        public bool chkDifEspecie { get; set; }
        public bool chkSobreEstimacion { get; set; }

        //checked de archivo
        public bool chkNuevaSupervision { get; set; }
        public bool chkEvidencia { get; set; }
        public bool chkSinIndicios { get; set; }
        public bool chkDeficienciaNot { get; set; }
        public bool chkDeficienciaTec { get; set; }
        public bool chkFallecimientoTitular { get; set; }
        public string txtOtros { get; set; }
        public bool chkMedidasCorrectivas { get; set; }
        public string txtDescMedidadCorrectivas { get; set; }
        //para la implementacion de medidad correctivas
        public string txtImplMCDias { get; set; }
        public string txtImplMCMeses { get; set; }
        public string txtImplMCAnio { get; set; }
        public string txtInfMCDia { get; set; }
        public string txtInfMCMeses { get; set; }
        public string txtInfMCAnio { get; set; }

        //para tipo otros
        public string txtMotivoOtros { get; set; }
        public string txtRecomendacionOtros { get; set; }

        //Aplicacion de medidas cautelares antes del PAU
        public bool chkGTF { get; set; }
        public bool chkLTrozas { get; set; }
        public bool chkPlanManejo { get; set; }
        public bool chkPOA { get; set; }
        public bool chkPorEspecie { get; set; }
        public string txtDescMedidasCautelaresAP { get; set; }
        public string txtRecomendacionesAP { get; set; }
        public string cod_IAlerta { get; set; }
        public List<Ent_ILEGAL> listaEspeciesAP { get; set; }


        public bool chkMandato { get; set; }
        public string txtDescMandato { get; set; }


        //Evaluacion del recurso de reconsideracion
        public bool chkMedCautelarRR { get; set; }
        public bool chkFinPauRR { get; set; }
        public bool chkImprocedenteRR { get; set; }
        public bool chkFueraPlazoRR { get; set; }
        public bool chkFaltaPruebasRR { get; set; }
        public bool chkProcedenteRR { get; set; }
        public bool chkFundadoRR { get; set; }
        public bool chkFundadoParteRR { get; set; }
        public bool chkInfundadoRR { get; set; }
        public string txtInfundadoObsRR { get; set; }
        public string txtPruebasPresentadasRR { get; set; }
        public List<Ent_ILEGAL> listaInfraccionesRR { get; set; }

        //Final de instruccion
        public bool chkInspeccionOcularFI { get; set; }
        public bool chkEmitirRDFI { get; set; }
        public bool chkSancionFI { get; set; }
        public bool chkMedidaCorrectivaRDFI { get; set; }
        public bool chkAmonestacionesFI { get; set; }
        public bool chkArchivoFI { get; set; }
        public bool chkCaducidadRDFI { get; set; }
        public bool chkMedidasProvisoriasFI { get; set; }
        public string txtMedidasProvisoriasFI { get; set; }
        public bool chkAmpliacionFI { get; set; }
        public bool chkAcumulacionFI { get; set; }
        public bool chkNuevaSupervisionFI { get; set; }
        public bool chkNuevaNotificacionFI { get; set; }
        public bool chkRectificacionFI { get; set; }
        public string txtVariarFI { get; set; }
        public string txtOtrosFI { get; set; }
        public string txtVariarMedCaut { get; set; }
        public bool chkConforme { get; set; }
        public string txt_Observaciones { get; set; }


        public int RegEstado { get; set; }
        public bool chkPublicar { get; set; }
        public string hdfCodigoIlegalAlerta { get; set; }

        //COD_ILEGAL_IALERTA_DETALLE
        public List<Ent_INFORME_CONSULTA_LEGAL> tbInforme { get; set; }
        public List<Ent_RESODIREC_CONSULTA> tbExpediente { get; set; }
        public List<Ent_SBusqueda> sBusqueda { get; set; }
        public List<Ent_SBusqueda> sRecomendaciones { get; set; }
        public List<Ent_SBusqueda> listaArticulos { get; set; }
        public List<Ent_SBusqueda> listaIncisos { get; set; }
        //para la lista de las infracciones
        public List<Ent_ILEGAL> listaInfracciones { get; set; }
        //para la lista de especies
        public List<Ent_SBusqueda> listaEspeciesCombo { get; set; }
        public List<Ent_ILEGAL> listaEspeciesMC { get; set; }
        public List<Ent_ILEGAL> tbEliTABLA { get; set; }

        ///listas temporales de eliminar
        public List<Ent_ILEGAL> tbEliTABLAEnciso { get; set; }
        public List<Ent_ILEGAL> tbEliTABLAEspecie { get; set; }
        public List<Ent_ILEGAL> tbEliTABLAEspecieAP { get; set; }

        //Incorporación de lista de allanamiento y subsanación para informe final de instrucción 20/09/2022 TGS
        public List<Ent_ILEGAL> ListSTD01 { get; set; }
        public List<Ent_ILEGAL> ListSTD02 { get; set; }
        public List<Ent_ILEGAL> ListSTD03 { get; set; }
        public List<Ent_ILEGAL> ListEliTSTD01 { get; set; }
        public bool chkTerceroSolidario { get; set; }
        public string hdfCodTerceroSolidario { get; set; }
        public string txtTerceroSolidario { get; set; }
        public string ddlArticuloSubsanableId { get; set; }
        public string txtArticuloSubsanable { get; set; }
        public List<Ent_SBusqueda> listaArticulosSubsanables { get; set; }
        public List<Ent_SBusqueda> listaIncisosSubsanados { get; set; }
        public List<Ent_ILEGAL> listaInfraccionesSubsanadas { get; set; }
        public List<Ent_ILEGAL> tbEliTABLAEncisoSubsanado { get; set; }
    }
}
