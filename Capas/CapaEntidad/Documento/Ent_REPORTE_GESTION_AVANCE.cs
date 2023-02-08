using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_REPORTE_GESTION_AVANCE
    {
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }

        [Description("ANIO_EJECUCION")]
        public String ANIO_EJECUCION { get; set; }
        [Description("DIRECCION")]
        public String DIRECCION { get; set; }

        [Description("META_ANUAL")]
        public Int32 META_ANUAL { get; set; }

        [Description("MES_ENERO")]
        public Int32 MES_ENERO { get; set; }
        [Description("EJEC_ENE")]
        public Int32 EJEC_ENE { get; set; }
        [Description("AVANCE_ENE")]
        public Decimal AVANCE_ENE { get; set; }

        [Description("MES_FEBRERO")]
        public Int32 MES_FEBRERO { get; set; }
        [Description("EJEC_FEB")]
        public Int32 EJEC_FEB { get; set; }

        [Description("AVANCE_FEB")]
        public Decimal AVANCE_FEB { get; set; }

        [Description("MES_MARZO")]
        public Int32 MES_MARZO { get; set; }
        [Description("EJEC_MAR")]
        public Int32 EJEC_MAR { get; set; }
        [Description("AVANCE_MAR")]
        public Decimal AVANCE_MAR { get; set; }

        [Description("MES_ABRIL")]
        public Int32 MES_ABRIL { get; set; }
        [Description("EJEC_ABR")]
        public Int32 EJEC_ABR { get; set; }
        [Description("AVANCE_ABR")]
        public Decimal AVANCE_ABR { get; set; }

        [Description("EJEC_MAY")]
        public Int32 EJEC_MAY { get; set; }
        [Description("MES_MAYO")]
        public Int32 MES_MAYO { get; set; }
        [Description("AVANCE_MAY")]
        public Decimal AVANCE_MAY { get; set; }

        [Description("EJEC_JUN")]
        public Int32 EJEC_JUN { get; set; }
        [Description("PROG_JUN")]
        public Int32 MES_JUNIO { get; set; }
        [Description("AVANCE_JUN")]
        public Decimal AVANCE_JUN { get; set; }

        [Description("PROG_JUL")]
        public Int32 MES_JULIO { get; set; }
        [Description("EJEC_JUL")]
        public Int32 EJEC_JUL { get; set; }
        [Description("AVANCE_JUL")]
        public Decimal AVANCE_JUL { get; set; }

        [Description("MES_AGO")]
        public Int32 MES_AGOSTO { get; set; }
        [Description("EJEC_AGO")]
        public Int32 EJEC_AGO { get; set; }
        [Description("AVANCE_AGO")]
        public Decimal AVANCE_AGO { get; set; }

        [Description("EJEC_SET")]
        public Int32 EJEC_SET { get; set; }
        [Description("PROG_SET")]
        public Int32 MES_SETIEMBRE { get; set; }
        [Description("AVANCE_SET")]
        public Decimal AVANCE_SET { get; set; }

        [Description("EJEC_OCT")]
        public Int32 EJEC_OCT { get; set; }
        [Description("PROG_OCT")]
        public Int32 MES_OCTUBRE { get; set; }
        [Description("AVANCE_OCT")]
        public Decimal AVANCE_OCT { get; set; }

        [Description("EJEC_NOV")]
        public Int32 EJEC_NOV { get; set; }
        [Description("PROG_NOV")]
        public Int32 MES_NOVIEMBRE { get; set; }
        [Description("AVANCE_NOV")]
        public Decimal AVANCE_NOV { get; set; }

        [Description("PROG_DIC")]
        public Int32 MES_DICIEMBRE { get; set; }
        [Description("EJEC_DIC")]
        public Int32 EJEC_DIC { get; set; }
        [Description("TOTAL_EJEC")]
        public Int32 TOTAL_EJEC { get; set; }
        [Description("AVANCE_DIC")]
        public Decimal AVANCE_DIC { get; set; }

        //Tipos de Busqueda segun
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }

        [Description("BusValor")]
        public String BusValor { get; set; }

        //MENU
        [Description("MENU")]
        public String MENU { get; set; }

        [Description("CATEGORIA")]
        public Int32 CATEGORIA { get; set; }

        //Entidad para el Reporte Supervicion
        [Description("TOTAL_Programado")]
        public Double TOTAL_Programado { get; set; }

        [Description("TOTAL_EjectCC")]
        public Int32 TOTAL_EjectCC { get; set; }

        [Description("TOTAL_ProgramadoD")]
        public Int32 TOTAL_ProgramadoD { get; set; }

        [Description("nombre")]
        public String nombre { get; set; }

        [Description("COD_LINEA")]
        public String COD_LINEA { get; set; }

        [Description("T1Program")]
        public Double T1Program { get; set; }
        [Description("T2Program")]
        public Double T2Program { get; set; }
        [Description("T3Program")]
        public Double T3Program { get; set; }
        [Description("T4Program")]
        public Double T4Program { get; set; }

        [Description("T1Ejecutado")]
        public Int32 T1Ejecutado { get; set; }
        [Description("T2Ejecutado")]
        public Int32 T2Ejecutado { get; set; }
        [Description("T3Ejecutado")]
        public Int32 T3Ejecutado { get; set; }
        [Description("T4Ejecutado")]
        public Int32 T4Ejecutado { get; set; }

        [Description("T1EjecutadoCC")]
        public Int32 T1EjecutadoCC { get; set; }
        [Description("T2EjecutadoCC")]
        public Int32 T2EjecutadoCC { get; set; }
        [Description("T3EjecutadoCC")]
        public Int32 T3EjecutadoCC { get; set; }
        [Description("T4EjecutadoCC")]
        public Int32 T4EjecutadoCC { get; set; }

        [Description("AvanceT1")]
        public Decimal AvanceT1 { get; set; }
        [Description("AvanceT2")]
        public Decimal AvanceT2 { get; set; }
        [Description("AvanceT3")]
        public Decimal AvanceT3 { get; set; }
        [Description("AvanceT4")]
        public Decimal AvanceT4 { get; set; }


        [Description("EneroEjecCC")]
        public Int32 EneroEjecCC { get; set; }
        [Description("FebEjecCC")]
        public Int32 FebEjecCC { get; set; }
        [Description("MarzEjecCC")]
        public Int32 MarzEjecCC { get; set; }
        [Description("AbrilEjecCC")]
        public Int32 AbrilEjecCC { get; set; }
        [Description("MayEjecCC")]
        public Int32 MayEjecCC { get; set; }
        [Description("JunEjecCC")]
        public Int32 JunEjecCC { get; set; }
        [Description("JulEjecCC")]
        public Int32 JulEjecCC { get; set; }
        [Description("AgostEjecCC")]
        public Int32 AgostEjecCC { get; set; }
        [Description("SeptEjecCC")]
        public Int32 SeptEjecCC { get; set; }
        [Description("OctEjecCC")]
        public Int32 OctEjecCC { get; set; }
        [Description("NovEjecCC")]
        public Int32 NovEjecCC { get; set; }
        [Description("DicEjecCC")]
        public Int32 DicEjecCC { get; set; }

        //Reporte_Estado_Cuenta

        //LISTAS
        [Category("LIST"), Description("ListMenuGestion_Avance")]
        public List<Ent_REPORTE_GESTION_AVANCE> ListMenuGestion_Avance { get; set; }


        public Ent_REPORTE_GESTION_AVANCE()
        {
            AVANCE_ENE = -1;
            AVANCE_FEB = -1;
            AVANCE_MAR = -1;
            AVANCE_ABR = -1;
            AVANCE_MAY = -1;
            AVANCE_JUN = -1;
            AVANCE_JUL = -1;
            AVANCE_AGO = -1;
            AVANCE_SET = -1;
            AVANCE_OCT = -1;
            AVANCE_NOV = -1;
            AVANCE_DIC = -1;
            CATEGORIA = -1;
            META_ANUAL = -1;
            MES_ENERO = -1;
            EJEC_ENE = -1;
            MES_FEBRERO = -1;
            EJEC_FEB = -1;
            MES_MARZO = -1;
            EJEC_MAR = -1;
            MES_ABRIL = -1;
            EJEC_ABR = -1;
            MES_MAYO = -1;
            EJEC_MAY = -1;
            MES_JUNIO = -1;
            EJEC_JUN = -1;
            MES_JULIO = -1;
            EJEC_JUL = -1;
            MES_AGOSTO = -1;
            EJEC_AGO = -1;
            MES_SETIEMBRE = -1;
            EJEC_SET = -1;
            MES_OCTUBRE = -1;
            EJEC_OCT = -1;
            MES_NOVIEMBRE = -1;
            EJEC_NOV = -1;
            MES_DICIEMBRE = -1;
            EJEC_DIC = -1;
            TOTAL_EJEC = -1;
            ////para supervision
            TOTAL_Programado = -1;
            AvanceT1 = -1;
            T1Ejecutado = -1;
            T1Program = -1;

            AvanceT2 = -1;
            T2Ejecutado = -1;
            T2Program = -1;

            AvanceT3 = -1;
            T3Ejecutado = -1;
            T3Program = -1;

            AvanceT4 = -1;
            T4Ejecutado = -1;
            T4Program = -1;

            TOTAL_ProgramadoD = -1;

            TOTAL_EjectCC = -1;
            T1EjecutadoCC = -1;
            T2EjecutadoCC = -1;
            T3EjecutadoCC = -1;
            T4EjecutadoCC = -1;

            EneroEjecCC = -1;
            FebEjecCC = -1;
            MarzEjecCC = -1;
            AbrilEjecCC = -1;
            MayEjecCC = -1;
            JunEjecCC = -1;
            JulEjecCC = -1;
            AgostEjecCC = -1;
            SeptEjecCC = -1;
            OctEjecCC = -1;
            NovEjecCC = -1;
            DicEjecCC = -1;
        }
    }
}
