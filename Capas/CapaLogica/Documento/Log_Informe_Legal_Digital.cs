using CapaDatos.DOC;
using CapaDatos.Documento;
using CapaEntidad.DOC;
using CapaEntidad.Documento;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;

namespace CapaLogica.Documento
{
    public class Log_Informe_Legal_Digital
    {
        Dat_Informe_Legal_Digital oDat_Informe_Legal_Digital;

        public Log_Informe_Legal_Digital()
        {
            oDat_Informe_Legal_Digital = new Dat_Informe_Legal_Digital();
        }

        public string RegInformeGrabar(VM_INFORME_LEGAL_DIGITAL informeDigital)
        {
            Ent_InformeLegalPAUDigital cabecera = new Ent_InformeLegalPAUDigital();
            cabecera.pVCodInformeDigital = informeDigital.COD_INFORME_DIGITAL;
            cabecera.pVCodInforme = informeDigital.COD_INFORME;
            cabecera.pNTramiteID = informeDigital.TRAMITE_ID;
            cabecera.pVNumInformeSITD = informeDigital.NUM_INFORME_SITD;
            cabecera.pVCodProcedencia = informeDigital.COD_PROCEDENCIA;
            cabecera.pVCodTipoInforme = informeDigital.COD_TIPO_INFORME;
            cabecera.pVCodMateria = informeDigital.COD_MATERIA;
            cabecera.pVCodModalidad = informeDigital.COD_MODALIDAD;
            cabecera.pVCodTHabilitante = informeDigital.COD_THABILITANTE;
            cabecera.pVRucTitularCondicion = informeDigital.TITULAR_CONDICION_RUC;
            cabecera.pVRucTitularEstado = informeDigital.TITULAR_ESTADO_RUC;
            cabecera.pNFlagCuestionPrevia = Convert.ToInt16(informeDigital.FLG_CUESTION_PREVIA);
            cabecera.pNFlagRecResponsabilidad = Convert.ToInt16(informeDigital.FLG_REC_RESPONSABILIDAD);
            cabecera.pNFlagGravedadRiesgo = Convert.ToInt16(informeDigital.FLG_GRAVEDAD_RIESGO);
            cabecera.pNFlagSancion = Convert.ToInt16(informeDigital.FLG_SANCION);
            cabecera.pNSancionUIT = informeDigital.SANCION_UIT ?? 0;
            cabecera.pvSancionCodCalculo = informeDigital.SANCION_COD_CALCULO;
            cabecera.pNFlagReincidencia = Convert.ToInt16(informeDigital.FLG_REINCIDENCIA);
            cabecera.pNFlagMedidaCorrectiva = Convert.ToInt16(informeDigital.FLG_MEDIDA_CORRECTIVA);
            cabecera.pNFlagMedidaComplementaria = Convert.ToInt16(informeDigital.FLG_MEDIDA_COMPLEMENTARIA);
            cabecera.pNFlagResponsableSolidario = Convert.ToInt16(informeDigital.FLG_RESPONSABLE_SOLIDARIO);
            cabecera.pNFlagComunicacionGORE = Convert.ToInt16(informeDigital.FLG_COMUNICACION_GORE);
            cabecera.pVRutaArchivoRevision = informeDigital.RUTA_ARCHIVO_REVISION;
            cabecera.pVCodUsuarioCreacion = informeDigital.COD_USUARIO_OPERACION;
            cabecera.pVCodUsuarioModificacion = informeDigital.COD_USUARIO_OPERACION;
            cabecera.pDFechaCreacion = DateTime.Now;
            cabecera.pDFechaModificacion = DateTime.Now;
            cabecera.pNEstado = informeDigital.ESTADO;
            cabecera.pVOUTPUTPARAM01 = "";

            return oDat_Informe_Legal_Digital.RegInformeGrabar(cabecera, informeDigital);
        }

        public VM_INFORME_LEGAL_DIGITAL ObtenerInforme(string COD_RESOLUCION)
        {
            return oDat_Informe_Legal_Digital.ObtenerInforme(COD_RESOLUCION);
        }

        public VM_Fiscalizacion_ISupervision InformeSupervisionResumen(string COD_INFORME_SUPERVISION)
        {
            return oDat_Informe_Legal_Digital.InformeSupervisionResumen(COD_INFORME_SUPERVISION);
        }

        public List<VM_INFORME_LEGAL_DIGITAL_ANTECEDENTE> ObtenerAntecedentesRSD(string COD_RESOLUCION, string COD_THABILITANTE)
        {
            return oDat_Informe_Legal_Digital.ObtenerAntecedentesRSD(COD_RESOLUCION, COD_THABILITANTE);
        }

        public VM_TRA_M_TRAMITE_SITD ObtenerExpedienteSITD(string NRO_DOCUMENTO)
        {
            return oDat_Informe_Legal_Digital.ObtenerExpedienteSITD(NRO_DOCUMENTO);
        }

        public void ModificarNumeroInforme(string codInforme, string numeroInforme, DateTime fechaOperacion)
        {
            oDat_Informe_Legal_Digital.ModificarNumeroInforme(codInforme, numeroInforme, fechaOperacion);
        }

        public string Notificar(Informe_Notificacion notificacion)
        {
            return oDat_Informe_Legal_Digital.Notificar(notificacion);
        }

        public bool ParticipanteActualizar(VM_INFORME_LEGAL_DIGITAL_PARTICIPANTE item)
        {
            return oDat_Informe_Legal_Digital.ParticipanteActualizar(item);
        }

        public bool CambiarEstado(string codInformeDigital, DateTime fechaOperacion, int estado, string codUsuarioOperacion)
        {
            return oDat_Informe_Legal_Digital.CambiarEstado(codInformeDigital, fechaOperacion, estado, codUsuarioOperacion);
        }

        public bool AnularFirmaPorInforme(string codInforme)
        {
            return oDat_Informe_Legal_Digital.AnularFirmaPorInforme(codInforme);
        }        
    }
}
