using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel.DOC
{
   public class VM_CONSTANCIA
    {
        public string NV_CONSTANCIA { get; set; }
        public string COD_INFORME { get; set; }
        public string COD_THABILITANTE { get; set; }
        public string COD_TITULAR { get; set; }
        public string NUMERO { get; set; }
        public string NUMERO_INFORME { get; set; }
        public string NUMERO_TH { get; set; }
        public string APELLIDOS_NOMBRES { get; set; }
        public DateTime FECHA_SUPERVISION_INICIO { get; set; }
        public DateTime FECHA_SUPERVISION_FIN { get; set; }
        public DateTime? FECHA_INFORME { get; set; }
        public string TIPO_PLAN { get; set; }
        public string NUM_POA { get; set; }
        public string PARCELA { get; set; }
        public DateTime? FECHA_EMISION { get; set; }
        public string ESTADO_DOCUMENTO { get; set; }
        public string COD_UCUENTA_GENERA { get; set; }
        public string COD_UCUENTA_EMITE { get; set; }
        public DateTime FE_CREACION { get; set; }
        public DateTime? FE_MODIFICAR { get; set; }
        public int NU_ESTADO { get; set; }
        public int TRAMITE_ID { get; set; }
        public string ARCHIVO { get; set; }
        public string PASSWORD { get; set; }

        public string PERSONA_FIRMA { get; set; }
        public string OFICINA { get; set; }
        public string ARCHIVO_TEMP { get; set; }
    }
    public class VM_CONSTANCIA_TRAMITE
    {
        public int tramiteId { get; set; }
        public int codTipoDoc { get; set; }
        public int codOficina { get; set; }
        public string asunto { get; set; }
        public string observacion { get; set; }
        public string numFolio { get; set; }
        public int trabajadorLoginId { get; set; }
        public DateTime fechaEmision { get; set; }
        public string codificacion { get; set; }
        public string codificacionINF { get; set; }
        public string password { get; set; }
        public string descripcionTipoDoc { get; set; }
        public int? remitenteId { get; set; }
        public string apellidosNombresRemitente { get; set; }
        public string persona { get; set; }
        public string direccion { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public VM_CONSTANCIA_TRAMITE()
        {
            this.tramiteId = 0;
            this.fechaEmision = DateTime.Now;
        }
    }
    public class VM_CONSTANCIA_REMITENTE
    {
        public int remitenteId { get; set; }
        public string tipoPersona { get; set; }
        public string tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string persona { get; set; }
        public string direccion { get; set; }
        public string codDepartamento { get; set; }
        public string codProvincia { get; set; }
        public string codDistrito { get; set; }
        public int cFlag { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public VM_CONSTANCIA_REMITENTE()
        {
            this.remitenteId = 0;
            this.cFlag = 1;
        }
    }

    public class VM_CONSTANCIA_V2
    {
        public string NV_CONSTANCIA { get; set; }
        public string VAR_NUM_CONSTANCIA { get; set; }
        public string VAR_TITULAR { get; set; }
        public string VAR_TIPO_DOC { get; set; }
        public string VAR_NUMERO_DOC { get; set; }
        public string VAR_TITULO { get; set; }
        public string VAR_PLANES { get; set; }
        public string VAR_LIC_REGENTE { get; set; }
        public string VAR_RESOLUCION_APLAN { get; set; }
        public string VAR_REGENTE { get; set; }
        public string VAR_FECHA_SUP { get; set; }
        public string VAR_INFORME { get; set; }
        public DateTime? VAR_FECHA_INFORME { get; set; }
        public string VAR_POA_CONST { get; set; }
        public DateTime? VAR_INICIO_POA { get; set; }
        public DateTime? VAR_FIN_SUP { get; set; }
        public DateTime? VAR_FECHA_EMC { get; set; }
        public string VAR_JEFE { get; set; }
        public string VAR_OFICINA { get; set; }

        public string ARCHIVO { get; set; }
        public string ESTADO_DOCUMENTO { get; set; }

        public int TRAMITE_ID { get; set; }
        public string NUMERO_INFORME { get; set; }

        public string PASSWORD { get; set; }

        public string PERSONA_FIRMA { get; set; }
        public string OFICINA { get; set; }

        public DateTime? FECHA_EMISION { get; set; }
        public string NUMERO { get; set; }

        public string ARCHIVO_TEMP { get; set; }

        public string APELLIDOS_NOMBRES { get; set; }
        public string COD_TITULAR { get; set; }
        public int NU_ESTADO { get; set; }
        public string COD_INFORME { get; set; }
        public string COD_THABILITANTE { get; set; }
    }
}
