using CapaDatos.DOC;
using CapaDatos.Documento;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            cabecera.pVNroReferencia = informeDigital.NRO_REFERENCIA;
            cabecera.pVCodTitular = informeDigital.COD_TITULAR;
            cabecera.pVRucTitularEstado = informeDigital.TITULAR_ESTADO_RUC;
            cabecera.pVRucTitularCondicion = informeDigital.TITULAR_CONDICION_RUC;
            cabecera.pNAnioResolucion = informeDigital.RES_DIRECTORAL_ANIO;
            cabecera.pVCodUndOrganica = informeDigital.RES_DIRECTORAL_UND_ORGANICA;
            cabecera.pDFechaResolucion = informeDigital.RES_DIRECTORAL_FECHA;
            cabecera.pVVistos = informeDigital.VISTOS;
            cabecera.pVAntecedentes = informeDigital.ANTECEDENTES;
            cabecera.pVCompetencia = informeDigital.COMPETENCIA;
            cabecera.pVAnalisis = informeDigital.ANALISIS;
            cabecera.pVImputacion = informeDigital.IMPUTACION;
            cabecera.pVComunicacionExterna = informeDigital.COMUNICACION_EXTERNA;
            cabecera.pVParrafosCliche = informeDigital.PARRAFOS_CLICHE;
            cabecera.pVPiePagina = informeDigital.PIE_PAGINA;
            cabecera.pVResolucion = informeDigital.RESOLUCION;
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

        public string NotificarRSD(RSD_Notificacion notificacion)
        {
            return oDat_PAU_Digital.NotificarRSD(notificacion);
        }

        public void ModificarNumeroInforme(string codInforme, string numeroInforme, DateTime fechaOperacion)
        {
            oDat_PAU_Digital.ModificarNumeroInforme(codInforme, numeroInforme, fechaOperacion);
        }

        /*public VM_RSD_CABECERA ObtenerRSDCabecera(string COD_RESOLUCION)
        {
            return oDat_PAU_Digital.ObtenerRSDCabecera(COD_RESOLUCION);
        }*/

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
