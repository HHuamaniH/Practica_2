using CapaDatos.DOC;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;

namespace CapaLogica.DOC
{
    public class Log_PAU_RD_Digital
    {
        Dat_PAU_RD_Digital oDat_PAU_RD_Digital;

        public Log_PAU_RD_Digital()
        {
            oDat_PAU_RD_Digital = new Dat_PAU_RD_Digital();
        }

        public string RegRDGrabar(VM_PAU_RD_DIGITAL informeDigital)
        {
            Ent_ResDirTabInforme cabecera = new Ent_ResDirTabInforme();

            cabecera.pVCodInformeDigital = informeDigital.COD_INFORME_DIGITAL;
            cabecera.pVCodResolucion = informeDigital.COD_RESOLUCION;
            cabecera.pNTramiteID = informeDigital.TRAMITE_ID;
            cabecera.pVNumInformeSITD = informeDigital.NUM_INFORME_SITD;
            cabecera.pVCodProcedencia = informeDigital.COD_PROCEDENCIA;
            cabecera.pVCodTipoInforme = informeDigital.COD_TIPO_INFORME;
            cabecera.pVCodMateria = informeDigital.COD_MATERIA;
            cabecera.pVCodModalidad = informeDigital.COD_MODALIDAD;
            cabecera.pVCodTHabilitante = informeDigital.COD_THABILITANTE;
            cabecera.pVRucTitularCondicion = informeDigital.TITULAR_CONDICION_RUC;
            cabecera.pVRucTitularEstado = informeDigital.TITULAR_ESTADO_RUC;
            
            cabecera.pNFlagResponsableSolidario = Convert.ToInt16(informeDigital.FLG_RESPOSABLE_SOLIDARIO);
            cabecera.pNFlagGravedadOcasionada = Convert.ToInt16(informeDigital.FLG_GRAVEDAD_OCASIONADA);
            cabecera.pNFlagAcreditacionImputaciones = Convert.ToInt16(informeDigital.FLG_ACREDITACION_IMPUTACIONES);
            cabecera.pNFlagSancion = Convert.ToInt16(informeDigital.FLG_SANCION);
            cabecera.pNSancionUIT = informeDigital.SANCION_UIT ?? 0;
            cabecera.pvSancionCodCalculo = informeDigital.SANCION_COD_CALCULO;
            cabecera.pNFlagMedidasComplementarias = Convert.ToInt16(informeDigital.FLG_MEDIDAS_COMPLEMENTARIAS);
            cabecera.pNFlagMedidasCorrectivas = Convert.ToInt16(informeDigital.FLG_MEDIDAS_CORRECTIVAS);
            cabecera.pNFlagComunicacionEntidades = Convert.ToInt16(informeDigital.FLG_COMUNICACION_ENTIDADES);

            cabecera.pVRutaArchivoRevision = informeDigital.RUTA_ARCHIVO_REVISION;
            cabecera.pVCodUsuarioCreacion = informeDigital.COD_USUARIO_OPERACION;
            cabecera.pVCodUsuarioModificacion = informeDigital.COD_USUARIO_OPERACION;
            cabecera.pDFechaCreacion = DateTime.Now;
            cabecera.pDFechaModificacion = DateTime.Now;
            cabecera.pNEstado = informeDigital.ESTADO;
            cabecera.pVOUTPUTPARAM01 = "";

            return oDat_PAU_RD_Digital.RegRDGrabar(cabecera, informeDigital);
        }

        public VM_PAU_RD_DIGITAL ObtenerRD(string COD_RESOLUCION)
        {
            return oDat_PAU_RD_Digital.ObtenerRD(COD_RESOLUCION);
        }

        public List<VM_PAU_RD_DIGITAL_ANTECEDENTE> ObtenerAntecedentes(string COD_RESOLUCION)
        {
            return oDat_PAU_RD_Digital.ObtenerAntecedentes(COD_RESOLUCION);
        }

        public bool ParticipanteActualizar(VM_PAU_RD_DIGITAL_PARTICIPANTE item)
        {
            return oDat_PAU_RD_Digital.ParticipanteActualizar(item);
        }

        public List<VM_PAU_RD_DIGITAL_INFRACCION> ListarInfracciones()
        {
            return oDat_PAU_RD_Digital.ListarInfracciones();
        }

        public string Notificar(VM_PAU_DIGITAL_ALERTA notificacion)
        {
            return oDat_PAU_RD_Digital.Notificar(notificacion);
        }

        public void ModificarNumeroInforme(string codInforme, string numeroInforme, DateTime fechaOperacion)
        {
            oDat_PAU_RD_Digital.ModificarNumeroInforme(codInforme, numeroInforme, fechaOperacion);
        }

        public bool CambiarEstado(string codInformeDigital, DateTime fechaOperacion, int estado, string codUsuarioOperacion)
        {
            return oDat_PAU_RD_Digital.CambiarEstado(codInformeDigital, fechaOperacion, estado, codUsuarioOperacion);
        }

        public bool AnularFirmaPorInforme(string codInforme)
        {
            return oDat_PAU_RD_Digital.AnularFirmaPorInforme(codInforme);
        }

        public VM_PAU_RD_INFORME_LEGAL_RESUMEN ObtenerResumenInformeLegal(string COD_ILEGAL)
        {
            return oDat_PAU_RD_Digital.ObtenerResumenInformeLegal(COD_ILEGAL);
        }
    }
}
