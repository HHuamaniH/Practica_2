using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_PROGRAMA_CAPACITACION
    {
        //Capacitacion
        [Description("COD_PCAPACITACION")]
        public String COD_PCAPACITACION { get; set; }
        [Description("NOMBRE")]
        public String NOMBRE { get; set; }
        [Description("COD_CAPATIPO")]
        public String COD_CAPATIPO { get; set; }
        [Description("COD_OD")]
        public String COD_OD { get; set; }
        [Description("OD")]
        public String OD { get; set; }
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("UBIGEO_DESCRIPCION")]
        public String UBIGEO_DESCRIPCION { get; set; }
        [Description("LUGAR")]
        public String LUGAR { get; set; }
        [Category("FECHA"), Description("FECHA_INICIO")]
        public Object FECHA_INICIO { get; set; }
        [Description("DIRIGIDO")]
        public String DIRIGIDO { get; set; }

        [Description("MAE_ENT_FINANCIA")]
        public String MAE_ENT_FINANCIA { get; set; }
        [Description("FUENTE_COOPERANTE")]
        public String FUENTE_COOPERANTE { get; set; }
        [Description("SUMA_POI")]
        public object SUMA_POI { get; set; }
        [Description("MARCO_CONVENIO")]
        public object MARCO_CONVENIO { get; set; }
        [Description("COD_MARCO_CONVENIO")]
        public String COD_MARCO_CONVENIO { get; set; }
        [Description("MAE_GRUPO_CONVENIO")]
        public String MAE_GRUPO_CONVENIO { get; set; }

        [Category("LIST"), Description("ListCapacitacionConvenios")]
        public List<Ent_PROGRAMA_CAPACITACION> ListCapacitacionConvenios { get; set; }
        [Category("LIST"), Description("ListMComboConveniosAFF")]
        public List<Ent_PROGRAMA_CAPACITACION> ListMComboConveniosAFF { get; set; }
        [Category("LIST"), Description("ListMComboConveniosOI")]
        public List<Ent_PROGRAMA_CAPACITACION> ListMComboConveniosOI { get; set; }
        [Category("LIST"), Description("ListMComboConveniosOIA")]
        public List<Ent_PROGRAMA_CAPACITACION> ListMComboConveniosOIA { get; set; }
        [Category("LIST"), Description("ListMComboConvenios")]
        public List<Ent_PROGRAMA_CAPACITACION> ListMComboConvenios { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("GRUPO")]
        public String GRUPO { get; set; }

        [Category("LIST"), Description("ListMComboOD")]
        public List<Ent_PROGRAMA_CAPACITACION> ListMComboOD { get; set; }
        [Category("LIST"), Description("ListMComboTipoCapacitacion")]
        public List<Ent_PROGRAMA_CAPACITACION> ListMComboTipoCapacitacion { get; set; }

        [Category("LIST"), Description("ListMComboEntidadFinancia")]
        public List<Ent_PROGRAMA_CAPACITACION> ListMComboEntidadFinancia { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("TIPO_REPORTE")]
        public string TIPO_REPORTE { get; set; }
        [Description("ANIO")]
        public Int32 ANIO { get; set; }
        [Description("MES")]
        public Int32 MES { get; set; }

        //Campos adicionales para REPORTE
        [Description("TP0000001")]
        public Int32 TP0000001 { get; set; }
        [Description("TE0000001")]
        public Int32 TE0000001 { get; set; }
        [Description("TP0000002")]
        public Int32 TP0000002 { get; set; }
        [Description("TE0000002")]
        public Int32 TE0000002 { get; set; }
        [Description("TP0000003")]
        public Int32 TP0000003 { get; set; }
        [Description("TE0000003")]
        public Int32 TE0000003 { get; set; }
        [Description("TP0000004")]
        public Int32 TP0000004 { get; set; }
        [Description("TE0000004")]
        public Int32 TE0000004 { get; set; }
        [Description("TPTOTAL")]
        public Int32 TPTOTAL { get; set; }
        [Description("TETOTAL")]
        public Int32 TETOTAL { get; set; }
        [Description("TIPO_TALLER")]
        public string TIPO_TALLER { get; set; }
        [Description("NOMBRE_MES")]
        public string NOMBRE_MES { get; set; }
        [Description("DEPARTAMENTO")]
        public string DEPARTAMENTO { get; set; }
        [Description("EJECUTADO")]
        public string EJECUTADO { get; set; }
        [Description("N_PARTICIPANTES")]
        public Int32 N_PARTICIPANTES { get; set; }

        public Ent_PROGRAMA_CAPACITACION()
        {
            RegEstado = -1;
            TP0000001 = -1;
            TE0000001 = -1;
            TP0000002 = -1;
            TE0000002 = -1;
            TP0000003 = -1;
            TE0000003 = -1;
            TP0000004 = -1;
            TE0000004 = -1;
            N_PARTICIPANTES = -1;
            ANIO = -1;
            MES = -1;
            TPTOTAL = -1;
            TETOTAL = -1;
        }
    }
}
