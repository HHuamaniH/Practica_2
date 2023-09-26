using CapaDatos.DOC;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;

namespace CapaLogica.DOC
{
    public class Log_PAU_Digital
    {
        Dat_PAU_Digital oDat_PAU_Digital;

        public Log_PAU_Digital()
        {
            oDat_PAU_Digital = new Dat_PAU_Digital();
        }

        public string RegRSDGrabar(VM_RSD_DIGITAL informeDigital)
        {
            Ent_ResSubDirTabInforme cabecera = new Ent_ResSubDirTabInforme();

            cabecera.pVCodInformeDigital = informeDigital.COD_INFORME_DIGITAL;
            cabecera.pVCodResSub = informeDigital.COD_RES_SUB;
            cabecera.pVNumInformeSITD = informeDigital.NUM_INFORME_SITD;
            cabecera.pNTramiteID = informeDigital.TRAMITE_ID;
            cabecera.pVCodProcedencia = informeDigital.COD_PROCEDENCIA;
            cabecera.pVCodMateria = informeDigital.COD_MATERIA;
            cabecera.pVCodModalidad = informeDigital.COD_MODALIDAD;
            cabecera.pVNroReferencia = informeDigital.NRO_REFERENCIA;
            cabecera.pNNumPOA = informeDigital.NUM_POA;
            cabecera.pVCodTHabilitante = informeDigital.COD_THABILITANTE;
            cabecera.pVRucTitularEstado = informeDigital.TITULAR_ESTADO_RUC;
            cabecera.pVRucTitularCondicion = informeDigital.TITULAR_CONDICION_RUC;
            cabecera.pNAnioResolucion = informeDigital.RES_DIRECTORAL_ANIO;
            cabecera.pVCodUndOrganica = informeDigital.RES_DIRECTORAL_UND_ORGANICA;
            cabecera.pDFechaResolucion = informeDigital.RES_DIRECTORAL_FECHA;
            cabecera.pNFlagCaducidadExtraccion = Convert.ToInt16(informeDigital.FLG_CADUCIDAD_EXTRACCION);
            cabecera.pNFlagComunicacion = Convert.ToInt16(informeDigital.FLG_COMUNICACION);
            cabecera.pNFlagHerramientasSubsanar = Convert.ToInt16(informeDigital.FLG_HERRAMIENTAS_SUBSANAR);
            cabecera.pNFlagImputacionCargos = Convert.ToInt16(informeDigital.FLG_IMPUTACION_CARGOS);
            cabecera.pNFlagMedidasCautelares = Convert.ToInt16(informeDigital.FLG_MEDIDAS_CAUTELARES);
            cabecera.pVRutaArchivoRevision = informeDigital.RUTA_ARCHIVO_REVISION;
            cabecera.pVCodUsuarioCreacion = informeDigital.COD_USUARIO_OPERACION;
            cabecera.pVCodUsuarioModificacion = informeDigital.COD_USUARIO_OPERACION;
            cabecera.pDFechaCreacion = DateTime.Now;
            cabecera.pDFechaModificacion = DateTime.Now;
            cabecera.pNEstado = informeDigital.ESTADO;
            cabecera.pVOUTPUTPARAM01 = "";

            return oDat_PAU_Digital.RegRSDGrabar(cabecera, informeDigital);
        }

        public VM_RSD_DIGITAL ObtenerRSD(string COD_RESOLUCION)
        {
            return oDat_PAU_Digital.ObtenerRSD(COD_RESOLUCION);
        }

        public bool RSDFirmaActualizar(VM_RSD_DIGITAL_FIRMA item)
        {
            return oDat_PAU_Digital.RSDFirmaActualizar(item);
        }

        public List<VM_RSD_DIGITAL_INFRACCIONES> ListarInfracciones()
        {
            return oDat_PAU_Digital.ListarInfracciones();
        }

        public List<VM_RSD_DIGITAL_CAUSALES_CADUCIDAD> ListarCausalesCaducidad()
        {
            return oDat_PAU_Digital.ListarCausalesCaducidad();
        }

        public List<VM_RSD_PLAN_MANEJO> ListarPlanesManejo(string COD_INFORME, string COD_THABILITANTE, int? NUM_POA, string V_OPCION)
        {
            return oDat_PAU_Digital.ListarPlanesManejo(COD_INFORME, COD_THABILITANTE, NUM_POA, V_OPCION);
        }

        public string NotificarRSD(RSD_Notificacion notificacion)
        {
            return oDat_PAU_Digital.NotificarRSD(notificacion);
        }

        public void ModificarNumeroInforme(string codInforme, string numeroInforme, DateTime fechaOperacion)
        {
            oDat_PAU_Digital.ModificarNumeroInforme(codInforme, numeroInforme, fechaOperacion);
        }

        public List<VM_Informe_Supervision> ObtenerRSDCabeceraByReferencia(string NUM_REFERENCIA, int TIPO = 1)
        {
            return oDat_PAU_Digital.ObtenerRSDCabeceraByReferencia(NUM_REFERENCIA, TIPO);
        }

        public bool CambiarEstado(string codInformeDigital, DateTime fechaOperacion, int estado, string codUsuarioOperacion)
        {
            return oDat_PAU_Digital.CambiarEstado(codInformeDigital, fechaOperacion, estado, codUsuarioOperacion);
        }

        public bool AnularFirmaPorInforme(string codInforme)
        {
            return oDat_PAU_Digital.AnularFirmaPorInforme(codInforme);
        }
    }
}
