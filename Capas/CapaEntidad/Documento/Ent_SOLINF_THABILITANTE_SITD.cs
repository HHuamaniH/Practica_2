using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_SOLINF_THABILITANTE_SITD
    {
        [Description("COD_TRAMITE_SITD")]
        public Int32 COD_TRAMITE_SITD { get; set; }
        [Description("NUM_DREFERENCIA")]
        public String NUM_DREFERENCIA { get; set; }
        [Description("NUM_DRESPUESTA")]
        public String NUM_DRESPUESTA { get; set; }
        [Category("FECHA"), Description("FECHA_SITD")]
        public Object FECHA_SITD { get; set; }
        [Description("COD_ENTIDAD")]
        public Int32 COD_ENTIDAD { get; set; }
        [Description("ENTIDAD")]
        public String ENTIDAD { get; set; }
        [Description("ASUNTO")]
        public String ASUNTO { get; set; }
        [Description("ESTADO_DREFERENCIA")]
        public String ESTADO_DREFERENCIA { get; set; }
        [Description("OBSERVACION_TRANSFERENCIA")]
        public String OBSERVACION_TRANSFERENCIA { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
        [Description("RESOLUCION_POA")]
        public String RESOLUCION_POA { get; set; }
        [Description("ESTADO_SUPERVISION")]
        public String ESTADO_SUPERVISION { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("REGISTRO_SIGO")]
        public String REGISTRO_SIGO { get; set; }
        [Description("PDF_TRAMITE_SITD")]
        public String PDF_TRAMITE_SITD { get; set; }

        [Description("N_THABILITANTE")]
        public Int32 N_THABILITANTE { get; set; }
        [Description("N_PMANEJO")]
        public Int32 N_PMANEJO { get; set; }
        [Description("N_SI_SUPERVISADO")]
        public Int32 N_SI_SUPERVISADO { get; set; }
        [Description("N_NO_SUPERVISADO")]
        public Int32 N_NO_SUPERVISADO { get; set; }
        [Description("N_NO_SUPERVERVISABLE")]
        public Int32 N_NO_SUPERVERVISABLE { get; set; }

        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("OD")]
        public String OD { get; set; }
        [Description("FUENTE")]
        public String FUENTE { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION")]
        public Object FECHA_RECEPCION { get; set; }
        [Description("ESTADO_CALIDAD")]
        public String ESTADO_CALIDAD { get; set; }
        [Description("NUM_CENSO")]
        public Int32 NUM_CENSO { get; set; }

        [Category("LIST"), Description("ListTHabilitante")]
        public List<Ent_SOLINF_THABILITANTE_SITD> ListTHabilitante { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_SOLINF_THABILITANTE_SITD> ListEliTABLA { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("BusAnio")]
        public String BusAnio { get; set; }
        [Description("BusRegion")]
        public String BusRegion { get; set; }
        [Description("BusOD")]
        public String BusOD { get; set; }

        public Ent_SOLINF_THABILITANTE_SITD()
        {
            COD_TRAMITE_SITD = -1;
            RegEstado = -1;
            NUM_POA = -1;
            COD_SECUENCIAL = -1;
            EliVALOR02 = -1;
            COD_ENTIDAD = -1;

            N_THABILITANTE = -1;
            N_PMANEJO = -1;
            N_SI_SUPERVISADO = -1;
            N_NO_SUPERVISADO = -1;
            N_NO_SUPERVERVISABLE = -1;
            NUM_CENSO = -1;
        }
    }
}
