using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace CapaEntidad.DOC
{
    public class Ent_REPORTE_TRAFICO_TALA_ILEGAL
    {

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("ANIO")]
        public Int32 ANIO { get; set; }
        [Description("TITULO HABILITANTE")]
        public String TITULO_HABILITANTE { get; set; }
        [Description("NUMERO_RESOLUCION")]
        public String NUMERO_RESOLUCION { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("SUPERVISOR")]
        public String SUPERVISOR { get; set; }
        [Description("CONSULTOR")]
        public String CONSULTOR { get; set; }
        [Description("FALSEDADINFORMACION")]
        public Int32 FALSEDADINFORMACION { get; set; }
        [Description("POAREALIZADO")]
        public Int32 POAREALIZADO { get; set; }
        [Description("MENU")]
        public String MENU { get; set; }
        [Description("CATEGORIA")]
        public Int32 CATEGORIA { get; set; }
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("VOLUMEN AUTORIZADO")]
        public Decimal VOL_AUTORIZADO { get; set; }
        [Description("VOLUMEN MOVILIZADO BALANCE")]
        public Decimal VOL_MOVILIZADOB { get; set; }
        [Description("VOLUMEN EXTRAIDO")]
        public Decimal VOL_EXTRAIDO { get; set; }
        [Description("VOLUMEN MOVILIZADO")]
        public Decimal VOL_MOVILIZADO { get; set; }
        //Opciones de Busqueda

        [Description("BusModalidad")]
        public String BusModalidad { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusRegion")]
        public String BusRegion { get; set; }
        [Description("BusAnio")]
        public String BusAnio { get; set; }

        //Manejo de Listas

        [Description("ListISupervision_General")]
        public List<Ent_REPORTE_TRAFICO_TALA_ILEGAL> ListISupervision_General { get; set; }

        [Description("ListHistorico")]
        public List<Ent_REPORTE_TRAFICO_TALA_ILEGAL> ListHistorico { get; set; }

        [Description("ListPoaFalsedad")]
        public List<Ent_REPORTE_TRAFICO_TALA_ILEGAL> ListPoaFalsedad { get; set; }

        [Description("ListISupervision_Modalidades")]
        public List<Ent_REPORTE_TRAFICO_TALA_ILEGAL> ListISupervision_Modalidades { get; set; }

        [Description("ListRegiones")]
        public List<Ent_REPORTE_TRAFICO_TALA_ILEGAL> ListRegiones { get; set; }


        //Reporte_Especies_Mayor_Informalidad
        [Description("AÑO SUPERVISION")]
        public String ANIO_SUPER { get; set; }
        [Description("MUESTRA DEL 2010")]
        public Int32 MUESTRA2010 { get; set; }
        [Description("MUESTRA DEL 2009")]
        public Int32 MUESTRA2009 { get; set; }
        [Description("MUESTRA DEL 2011")]
        public Int32 MUESTRA2011 { get; set; }
        [Description("MUESTRA DE 2012")]
        public Int32 MUESTRA2012 { get; set; }
        [Description("MUESTRA DE 2013")]
        public Int32 MUESTRA2013 { get; set; }
        [Description("MUESTRA DE 2014")]
        public Int32 MUESTRA2014 { get; set; }
        [Description("INEXISTENTE DEL 2010")]
        public Int32 INEX2010 { get; set; }
        [Description("INEXISTENTE DEL 2009")]
        public Int32 INEX2009 { get; set; }
        [Description("INEXISTENTE DEL 2011")]
        public Int32 INEX2011 { get; set; }
        [Description("INEXISTENTE DE 2012")]
        public Int32 INEX2012 { get; set; }
        [Description("INEXISTENTE DE 2013")]
        public Int32 INEX2013 { get; set; }
        [Description("INEXISTENTE DE 2014")]
        public Int32 INEX2014 { get; set; }
        [Description("TOTAL")]
        public Int32 TOTAL { get; set; }
        //CUADRO GENERAL
        [Description("N° Arboles")]
        public Int32 NUM_ARBOLES { get; set; }
        [Description("DEPARTAMENTO")]
        public string DEPARTAMENTO { get; set; }
        [Description("MUESTRA")]
        public Int32 MUESTRA { get; set; }
        [Description("INEXISTENCIA")]
        public Int32 INEXISTENCIA { get; set; }
        [Description("% INEXISTENCIA")]
        public decimal PORCENTAJE { get; set; }
        //CRITERIO DOE BUSQUEDA

        //LISTAS
        [Category("LIST"), Description("ListGeneralAnio")]
        public List<Ent_REPORTE_TRAFICO_TALA_ILEGAL> ListGeneralAnio { get; set; }
        [Category("LIST"), Description("ListEspecieAnio")]
        public List<Ent_REPORTE_TRAFICO_TALA_ILEGAL> ListEspecieAnio { get; set; }

        //Reporte_Especies_Mayor_Informalidad


        public Ent_REPORTE_TRAFICO_TALA_ILEGAL()
        {
            ANIO = -1;
            NUM_POA = -1;
            CATEGORIA = -1;
            VOL_AUTORIZADO = -1;
            VOL_MOVILIZADOB = -1;
            VOL_EXTRAIDO = -1;
            VOL_MOVILIZADO = -1;
            FALSEDADINFORMACION = -1;
            POAREALIZADO = -1;


            MUESTRA2009 = -1;
            MUESTRA2010 = -1;
            MUESTRA2011 = -1;
            MUESTRA2012 = -1;
            MUESTRA2013 = -1;
            MUESTRA2014 = -1;
            INEX2009 = -1;
            INEX2010 = -1;
            INEX2011 = -1;
            INEX2012 = -1;
            INEX2013 = -1;
            INEX2014 = -1;
            NUM_ARBOLES = -1;
            MUESTRA = -1;
            INEXISTENCIA = -1;
            PORCENTAJE = -1;
            TOTAL = -1;

        }


    }
}
