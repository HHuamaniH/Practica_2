using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_DigitadoresOD
    {
        [Description("DIGITADOR")]
        public String DIGITADOR { get; set; }

        [Description("NOTIFICADOR")]
        public String NOTIFICADOR { get; set; }

        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        [Description("CARGO")]
        public String CARGO { get; set; }

        [Description("UBIGEO")]
        public String UBIGEO { get; set; }

        [Description("FECHA")]
        public String FECHA { get; set; }

        [Description("FECHAFIN")]
        public String FECHAFIN { get; set; }

        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("RESOLUCION")]
        public String RESOLUCION { get; set; }
        [Description("TH")]
        public String TH { get; set; }

        [Description("SUPERVISOR")]
        public String SUPERVISOR { get; set; }

        [Description("AVANCE")]
        public Decimal AVANCE { get; set; }

        //REGISTRO POA 
        [Description("POA")]
        public Int32 POA { get; set; }

        [Description("PL")]
        public Int32 PL { get; set; }

        //REGISTRO THHT 
        [Description("TITULO_HABILITANTE")]
        public Int32 TITULO_HABILITANTE { get; set; }

        [Description("PNOTIFICACION")]
        public Int32 PNOTIFICACION { get; set; }

        [Description("PSUPERVISION")]
        public Int32 PSUPERVISION { get; set; }

        [Description("SEMANA1")]
        public Int32 SEMANA1 { get; set; }

        [Description("SEMANA2")]
        public Int32 SEMANA2 { get; set; }

        [Description("SEMANA3")]
        public Int32 SEMANA3 { get; set; }

        [Description("SEMANA4")]
        public Int32 SEMANA4 { get; set; }

        [Description("SEMANA5")]
        public Int32 SEMANA5 { get; set; }

        [Description("TOTAL")]
        public Int32 TOTAL { get; set; }

        [Description("MESES")]
        public String MESES { get; set; }


        //REGISTRO CARTA NOTIFICACION
        [Description("NUM_NOTIFICACION")]
        public Int32 NUM_NOTIFICACION { get; set; }

        //REGISTRO DE SUPERVISION
        [Description("NUM_SUPERVISION")]
        public Int32 NUM_SUPERVISION { get; set; }

        //VARIABLES GENERALES
        [Description("REGISTROS")]
        public Int32 REGISTROS { get; set; }

        [Description("OD")]
        public String OD { get; set; }

        [Description("BusAnio")]
        public String BusAnio { get; set; }

        [Description("BusMes")]
        public String BusMes { get; set; }

        [Description("BusOD")]
        public String BusOD { get; set; }

        [Description("BusCriterio")]
        public String BusCriterio { get; set; }

        [Description("NOM_FORMULARIO")]
        public String NOM_FORMULARIO { get; set; }
        //Etapa control Calidad
        [Description("PR")]
        public Int32 PR { get; set; }//Proceso registro
        [Description("RC")]
        public Int32 RC { get; set; }//Registro concluido
        [Description("CO")]
        public Int32 CO { get; set; }//Control calidad con observaciones
        [Description("CC")]
        public Int32 CC { get; set; }//Control calidad conforme

        //RESOLUCION, ILEGAL, INFTTIT, INFTEC
        [Description("Item1")]
        public Int32 Item1 { get; set; }
        [Description("Item2")]
        public Int32 Item2 { get; set; }
        [Description("Item3")]
        public Int32 Item3 { get; set; }
        [Description("Item4")]
        public Int32 Item4 { get; set; }
        [Description("Item5")]
        public Int32 Item5 { get; set; }
        [Description("Item6")]
        public Int32 Item6 { get; set; }
        [Description("Item7")]
        public Int32 Item7 { get; set; }
        [Description("Item8")]
        public Int32 Item8 { get; set; }
        [Description("Item9")]
        public Int32 Item9 { get; set; }
        [Description("Item10")]
        public Int32 Item10 { get; set; }

        [Category("LIST"), Description("ListDigitadores")]
        public List<Ent_Reporte_DigitadoresOD> ListDigitadores { get; set; }

        [Category("LIST"), Description("ListNotificadores")]
        public List<Ent_Reporte_DigitadoresOD> ListNotificadores { get; set; }

        [Category("LIST"), Description("ListSupervisores")]
        public List<Ent_Reporte_DigitadoresOD> ListSupervisores { get; set; }

        [Category("LIST"), Description("ListOD")]
        public List<Ent_Reporte_DigitadoresOD> ListOD { get; set; }

        [Category("LIST"), Description("ListResoluciones")]
        public List<Ent_Reporte_DigitadoresOD> ListResoluciones { get; set; }

        [Category("LIST"), Description("ListInformeLegales")]
        public List<Ent_Reporte_DigitadoresOD> ListInformeLegales { get; set; }

        [Category("LIST"), Description("ListInformeTecnicos")]
        public List<Ent_Reporte_DigitadoresOD> ListInformeTecnicos { get; set; }

        [Category("LIST"), Description("ListInformacionTitular")]
        public List<Ent_Reporte_DigitadoresOD> ListInformacionTitular { get; set; }

        [Category("LIST"), Description("ListControlCalidad")]
        public List<Ent_ControlCalidad> ListControlCalidad { get; set; }


        public Ent_Reporte_DigitadoresOD()
        {
            TITULO_HABILITANTE = -1;
            PSUPERVISION = -1;
            PNOTIFICACION = -1;
            POA = -1;
            NUM_NOTIFICACION = -1;
            NUM_SUPERVISION = -1;
            PL = -1;
            REGISTROS = -1;
            SEMANA1 = -1;
            SEMANA2 = -1;
            SEMANA3 = -1;
            SEMANA4 = -1;
            SEMANA5 = -1;
            TOTAL = -1;
            AVANCE = -1;
            Item1 = -1;
            Item2 = -1;
            Item3 = -1;
            Item4 = -1;
            Item5 = -1;
            Item6 = -1;
            Item7 = -1;
            Item8 = -1;
            Item9 = -1;
            Item10 = -1;
            CC = -1;
            CO = -1;
            PR = -1;
            RC = -1;
        }
    }
}
