using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_REPORTE_ISUPERVISION
    {
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("ISUP")]
        public Int32 ISUP { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("VALOR")]
        public Int32 VALOR { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }
        [Description("CONSULTOR")]
        public String CONSULTOR { get; set; }
        [Description("VOL_AUTORIZADO")]
        public Decimal VOL_AUTORIZADO { get; set; }        //
        [Description("VOL_MOVILIZADO")]
        public Decimal VOL_MOVILIZADO { get; set; }        //
        [Description("BusModalidad")]
        public String BusModalidad { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusRegion")]
        public String BusRegion { get; set; }
        [Description("Busanio")]
        public String Busanio { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }


        /// <summary>
        /// para los usuarios 
        /// </summary>
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_UGRUPO")]
        public String COD_UGRUPO { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }

        [Description("I")]
        public Decimal I { get; set; }
        [Description("W")]
        public Decimal W { get; set; }
        [Description("K")]
        public Decimal K { get; set; }
        [Category("LIST"), Description("ListISupervision_Modalidad")]
        public List<Ent_REPORTE_ISUPERVISION> ListISupervision_Modalidad { get; set; }
        [Category("LIST"), Description("ListRegion")]
        public List<Ent_REPORTE_ISUPERVISION> ListRegion { get; set; }
        [Category("LIST"), Description("ListArticulo")]
        public List<Ent_REPORTE_ISUPERVISION> ListISupervision_Articulo { get; set; }

        [Category("LIST"), Description("ListRankingEspecies")]
        public List<Ent_REPORTE_ISUPERVISION> ListRankingEspecies { get; set; }
        [Category("LIST"), Description("ListRankingDepartamento")]
        public List<Ent_REPORTE_ISUPERVISION> ListRankingDepartamento { get; set; }

        //05/10/2017 - Atributos adicionales para el reporte "Supervisiones Según Oportunidad"
        [Description("TIPO_REPORTE")]
        public String TIPO_REPORTE { get; set; }
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }
        [Description("POA")]
        public String POA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("ANIO")]
        public Int32 ANIO { get; set; }
        [Description("COD_MES")]
        public String COD_MES { get; set; }
        [Description("MES")]
        public String MES { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("DLINEA")]
        public String DLINEA { get; set; }
        [Description("MTIPO")]
        public String MTIPO { get; set; }
        [Description("OD")]
        public String OD { get; set; }
        [Description("MAE_EST_APROVECHA")]
        public String MAE_EST_APROVECHA { get; set; }
        [Description("EST_APROVECHA")]
        public String EST_APROVECHA { get; set; }
        [Description("BusDLinea")]
        public String BusDLinea { get; set; }
        [Description("BusOD")]
        public String BusOD { get; set; }
        [Description("NPLANSUPERVISADO_ANTES")]
        public Int32 NPLANSUPERVISADO_ANTES { get; set; }
        [Description("NPLANSUPERVISADO_DURANTE")]
        public Int32 NPLANSUPERVISADO_DURANTE { get; set; }
        [Description("NPLANSUPERVISADO_DESPUES")]
        public Int32 NPLANSUPERVISADO_DESPUES { get; set; }
        [Description("NPLANSUPERVISADO")]
        public Int32 NPLANSUPERVISADO { get; set; }
        [Description("NISUPERVISION")]
        public Int32 NISUPERVISION { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("FECHA_APRUEBA_POA")]
        public String FECHA_APRUEBA_POA { get; set; }
        [Description("INICIO_VIGENCIA")]
        public String INICIO_VIGENCIA { get; set; }
        [Description("FIN_VIGENCIA")]
        public String FIN_VIGENCIA { get; set; }

        public Ent_REPORTE_ISUPERVISION()
        {
            ISUP = -1;
            NUM_POA = -1;
            VOL_AUTORIZADO = -1;
            VOL_MOVILIZADO = -1;
            I = -1;
            W = -1;
            K = -1;
            VALOR = -1;
            ANIO = -1;
            NPLANSUPERVISADO = -1;
            NPLANSUPERVISADO_ANTES = -1;
            NPLANSUPERVISADO_DESPUES = -1;
            NPLANSUPERVISADO_DURANTE = -1;
            NISUPERVISION = -1;
        }
    }
}
