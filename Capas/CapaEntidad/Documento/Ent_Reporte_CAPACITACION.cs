using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_CAPACITACION
    {
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusAnios")]
        public String BusAnios { get; set; }
        [Description("BusODs")]
        public String BusODs { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("ANIO")]
        public String ANIO { get; set; }
        [Description("NUM_CAPACITACIONES")]
        public Int32 NUM_CAPACITACIONES { get; set; }
        [Description("NUM_PARTICIPANTES")]
        public Int32 NUM_PARTICIPANTES { get; set; }
        [Description("NUM_HOMBRES")]
        public Int32 NUM_HOMBRES { get; set; }
        [Description("NUM_MUJERES")]
        public Int32 NUM_MUJERES { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("DOSMILNUEVE")]
        public Int32 DOSMILNUEVE { get; set; }
        [Description("DOSMILDIEZ")]
        public Int32 DOSMILDIEZ { get; set; }
        [Description("DOSMILONCE")]
        public Int32 DOSMILONCE { get; set; }
        [Description("DOSMILDOCE")]
        public Int32 DOSMILDOCE { get; set; }
        [Description("DOSMILTRECE")]
        public Int32 DOSMILTRECE { get; set; }
        [Description("DOSMILCATORCE")]
        public Int32 DOSMILCATORCE { get; set; }
        [Description("DOSMILQUINCE")]
        public Int32 DOSMILQUINCE { get; set; }
        [Description("DOSMILDIECISEIS")]
        public Int32 DOSMILDIECISEIS { get; set; }
        [Description("DOSMILDIECISIETE")]
        public Int32 DOSMILDIECISIETE { get; set; }
        [Description("DOSMILDIECIOCHO")]
        public Int32 DOSMILDIECIOCHO { get; set; }
        [Description("REGION")]
        public String REGION { get; set; }
        [Description("TOTAL")]
        public Int32 TOTAL { get; set; }
        [Description("NOM_TALLER")]
        public String NOM_TALLER { get; set; }
        [Description("TIPO_TALLER")]
        public String TIPO_TALLER { get; set; }
        [Category("FECHA"), Description("FECHA")]
        public Object FECHA { get; set; }
        [Description("UBICACION")]
        public String UBICACION { get; set; }
        [Description("PUBLICO_OBJETIVO")]
        public String PUBLICO_OBJETIVO { get; set; }
        [Description("OD")]
        public String OD { get; set; }

        [Category("LIST"), Description("List_Reporte_CAPACITACION")]
        public List<Ent_Reporte_CAPACITACION> List_Reporte_CAPACITACION { get; set; }

        public Ent_Reporte_CAPACITACION()
        {
            NUM_CAPACITACIONES = -1;
            NUM_PARTICIPANTES = -1;
            NUM_HOMBRES = -1;
            NUM_MUJERES = -1;
            DOSMILNUEVE = -1;
            DOSMILDIEZ = -1;
            DOSMILONCE = -1;
            DOSMILDOCE = -1;
            DOSMILTRECE = -1;
            DOSMILCATORCE = -1;
            DOSMILQUINCE = -1;
            DOSMILDIECISEIS = -1;
            DOSMILDIECISIETE = -1;
            DOSMILDIECIOCHO = -1;
            TOTAL = -1;
        }
    }
}
