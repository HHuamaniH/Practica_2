using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_Veeduria
    {
        [Description("NV_TIPO")]
        public string NV_TIPO { get; set; }
        [Description("NV_CATALOGO")]
        public string NV_CATALOGO { get; set; }
        [Description("NV_DESCRIPCION")]
        public string NV_DESCRIPCION { get; set; }

        //Equipo
        [Description("NV_EQUIPO_INTEGRANTE_ORGANIZACION")]
        public string NV_EQUIPO_INTEGRANTE_ORGANIZACION { get; set; }
        [Description("NV_EQUIPO")]
        public string NV_EQUIPO { get; set; }
        [Description("NV_COMUNIDAD")]
        public string NV_COMUNIDAD { get; set; }
        [Description("NV_ORGANIZACION")]
        public string NV_ORGANIZACION { get; set; }
        [Description("NV_ORGINTERNA")]
        public string NV_ORGINTERNA { get; set; }
        [Description("NV_ORGREGIONAL")]
        public string NV_ORGREGIONAL { get; set; }
        [Description("NV_UBIGEO")]
        public string NV_UBIGEO { get; set; }
        [Description("NV_LUGAR")]
        public string NV_LUGAR { get; set; }
        [Description("NU_ESTADO")]
        public Int32 NU_ESTADO { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("NU_CRITERIO")]
        public Int32 NU_CRITERIO { get; set; }
        [Description("NV_VALOR")]
        public String NV_VALOR { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("UBIGEO")]
        public String UBIGEO { get; set; }

        //Integrante
        [Description("NV_INTEGRANTE")]
        public string NV_INTEGRANTE { get; set; }
        [Description("COD_PERSONA")]
        public string COD_PERSONA { get; set; }
        [Description("NV_COD_DIDENTIDAD")]
        public string NV_COD_DIDENTIDAD { get; set; }
        [Description("TIPO_DOCUMENTO")]
        public string TIPO_DOCUMENTO { get; set; }
        [Description("NV_NUMERO")]
        public string NV_NUMERO { get; set; }
        [Description("INTEGRANTE")]
        public string INTEGRANTE { get; set; }
        [Description("NV_APE_PATERNO")]
        public string NV_APE_PATERNO { get; set; }
        [Description("NV_APE_MATERNO")]
        public string NV_APE_MATERNO { get; set; }
        [Description("NV_NOMBRES")]
        public string NV_NOMBRES { get; set; }
        [Description("NV_CARGO")]
        public string NV_CARGO { get; set; }
        [Description("FE_INICIO")]
        public string FE_INICIO { get; set; }
        [Description("FE_TERMINO")]
        public string FE_TERMINO { get; set; }

        //RptHallazgo
        [Description("NV_REPORTEHALLAZGO")]
        public string NV_REPORTEHALLAZGO { get; set; }
        [Description("FE_EMISION")]
        public string FE_EMISION { get; set; }
        [Description("NV_SECTOR")]
        public string NV_SECTOR { get; set; }
        [Description("NU_COORDENADA_ESTE")]
        public Int32 NU_COORDENADA_ESTE { get; set; }
        [Description("NU_COORDENADA_NORTE")]
        public Int32 NU_COORDENADA_NORTE { get; set; }
        [Description("NV_ZONA")]
        public string NV_ZONA { get; set; }
        [Description("NV_VIA")]
        public string NV_VIA { get; set; }
        [Description("NV_VEHICULO")]
        public string NV_VEHICULO { get; set; }
        [Description("NV_FRECUENCIA")]
        public string NV_FRECUENCIA { get; set; }
        [Description("NV_ACTIVIDAD")]
        public string NV_ACTIVIDAD { get; set; }
        [Description("NU_SUPERFICIE")]
        public Decimal NU_SUPERFICIE { get; set; }
        [Description("NV_HECHO")]
        public string NV_HECHO { get; set; }
        [Description("NV_RESPONSABLE")]
        public string NV_RESPONSABLE { get; set; }
        [Description("NV_NOMBRE_EMPRESA")]
        public string NV_NOMBRE_EMPRESA { get; set; }
        [Description("NV_NOMBRE_EMPRESA_VALIDADO")]
        public string NV_NOMBRE_EMPRESA_VALIDADO { get; set; }
        [Description("NV_THABILITANTE")]
        public string NV_THABILITANTE { get; set; }
        [Description("NV_THABILITANTE_VALIDADO")]
        public string NV_THABILITANTE_VALIDADO { get; set; }
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NV_TITULAR")]
        public string NV_TITULAR { get; set; }
        [Description("NV_TITULAR_VALIDADO")]
        public string NV_TITULAR_VALIDADO { get; set; }
        [Description("COD_TITULAR")]
        public string COD_TITULAR { get; set; }
        [Description("NV_OBSERVACION")]
        public string NV_OBSERVACION { get; set; }
        [Description("NV_OBSERVACION_VALIDADO")]
        public string NV_OBSERVACION_VALIDADO { get; set; }
        [Description("NV_SINCRONIZA")]
        public string NV_SINCRONIZA { get; set; }
        [Description("NV_INTEGRANTE_SINCRONIZA")]
        public string NV_INTEGRANTE_SINCRONIZA { get; set; }
        [Description("FE_CREACION")]
        public string FE_CREACION { get; set; }
        [Description("FE_MODIFICAR")]
        public string FE_MODIFICAR { get; set; }
        [Description("COD_UCUENTA_PROCESA")]
        public string COD_UCUENTA_PROCESA { get; set; }
        [Description("FE_PROCESA")]
        public string FE_PROCESA { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public string APELLIDOS_NOMBRES { get; set; }

        //DetRptHallazgo
        [Description("NV_DETREPORTEHALLAZGO")]
        public string NV_DETREPORTEHALLAZGO { get; set; }
        [Description("NV_ESPECIES")]
        public string NV_ESPECIES { get; set; }
        [Description("NV_ESPECIES_VALIDADO")]
        public string NV_ESPECIES_VALIDADO { get; set; }
        [Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("NU_DIAMAYOR_ESPESOR")]
        public Decimal NU_DIAMAYOR_ESPESOR { get; set; }
        [Description("NU_DIAMENOR_ANCHO")]
        public Decimal NU_DIAMENOR_ANCHO { get; set; }
        [Description("NU_LONGITUD")]
        public Decimal NU_LONGITUD { get; set; }
        [Description("NU_VOLUMEN")]
        public Decimal NU_VOLUMEN { get; set; }
        [Description("USUARIO_VALIDA")]
        public string USUARIO_VALIDA { get; set; }
        [Description("ESTADO")]
        public string ESTADO { get; set; }

        //Título Habilitante
        [Description("NV_TH")]
        public string NV_TH { get; set; }
        [Description("MODALIDAD")]
        public string MODALIDAD { get; set; }
        [Description("THABILITANTE")]
        public string THABILITANTE { get; set; }
        [Description("TITULAR")]
        public string TITULAR { get; set; }
        [Description("RLEGAL")]
        public string RLEGAL { get; set; }
        [Description("REGION")]
        public string REGION { get; set; }
        [Description("FECHA_REGISTRO")]
        public string FECHA_REGISTRO { get; set; }
        [Description("COD_SECUENCIA")]
        public Int32 COD_SECUENCIA { get; set; }
        [Description("BUS_CRITERIO")]
        public string BUS_CRITERIO { get; set; }
        [Description("BUS_VALOR")]
        public string BUS_VALOR { get; set; }

        //Archivo
        [Description("CODIGO_RELACIONADO")]
        public string CODIGO_RELACIONADO { get; set; }
        [Description("NV_NOMBRE")]
        public string NV_NOMBRE { get; set; }
        [Description("RUTA")]
        public string RUTA { get; set; }
        [Description("TRAMA")]
        public string TRAMA { get; set; }
        [Description("SRC")]
        public string SRC { get; set; }

        //Correo
        [Description("CORREO")]
        public string CORREO { get; set; }
        [Description("OFICINA")]
        public string OFICINA { get; set; }
        [Description("NV_ENVIO")]
        public string NV_ENVIO { get; set; }
        [Description("NV_PARA")]
        public string NV_PARA { get; set; }
        [Description("NV_CC")]
        public string NV_CC { get; set; }
        [Description("NV_CUERPO")]
        public string NV_CUERPO { get; set; }

        //Listas
        [Category("LIST"), Description("ListTipo")]
        public List<Ent_Veeduria> ListTipo { get; set; }
        [Category("LIST"), Description("ListIntegrante")]
        public List<Ent_Veeduria> ListIntegrante { get; set; }
        [Category("LIST"), Description("ListDetHallazgo")]
        public List<Ent_Veeduria> ListDetHallazgo { get; set; }
        [Category("LIST"), Description("ListTHabilitante")]
        public List<Ent_Veeduria> ListTHabilitante { get; set; }
        [Category("LIST"), Description("ListElimTHabilitante")]
        public List<Ent_Veeduria> ListElimTHabilitante { get; set; }
        [Category("LIST"), Description("ListArchivo")]
        public List<Ent_Veeduria> ListArchivo { get; set; }
        [Category("LIST"), Description("ListEnviado")]
        public List<Ent_Veeduria> ListEnviado { get; set; }
        [Category("LIST"), Description("ListCorreo")]
        public List<Ent_Veeduria> ListCorreo { get; set; }

        public Ent_Veeduria()
        {
            NU_ESTADO = -1;
            RegEstado = -1;
            NU_COORDENADA_ESTE = -1;
            NU_COORDENADA_NORTE = -1;
            NU_SUPERFICIE = -1;
            NU_DIAMAYOR_ESPESOR = -1;
            NU_DIAMENOR_ANCHO = -1;
            NU_LONGITUD = -1;
            NU_VOLUMEN = -1;
            COD_SECUENCIA = -1;
            NU_CRITERIO = -1;
        }
    }
}