using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_CSUPERVISION
    {
        [Description("COD_CSUPERVISION")]
        public String COD_CSUPERVISION { get; set; }
        [Description("NUM_CSUPERVISION")]
        public String NUM_CSUPERVISION { get; set; }
        [Description("ANIO")]
        public Int32 ANIO { get; set; }
        [Description("MES")]
        public String MES { get; set; }
        [Category("FECHA"), Description("FECHA_CREACION")]
        public Object FECHA_CREACION { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("COD_PMANEJO")]
        public String COD_PMANEJO { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("COD_DLINEA")]
        public String COD_DLINEA { get; set; }

        [Category("LIST"), Description("ListTHPoaPm")]
        public List<Ent_CSUPERVISION> ListTHPoaPm { get; set; }
        [Category("LIST"), Description("ListCSupervisionTH")]
        public List<Ent_CSUPERVISION> ListCSupervisionTH { get; set; }
        [Category("LIST"), Description("ListCSupervTHSupervisor")]
        public List<Ent_CSUPERVISION> ListCSupervTHSupervisor { get; set; }
        [Category("LIST"), Description("ListCSupervTHDiaAct")]
        public List<Ent_CSUPERVISION> ListCSupervTHDiaAct { get; set; }

        //Combo
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Category("LIST"), Description("ListMComboOD")]
        public List<Ent_CSUPERVISION> ListMComboOD { get; set; }
        [Category("LIST"), Description("ListMComboTipoActividad")]
        public List<Ent_CSUPERVISION> ListMComboTipoActividad { get; set; }
        //Buscar
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        //Usuario
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        //Supervisor
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        //Actividades por día
        [Description("DIA")]
        public Int32 DIA { get; set; }
        [Description("MAE_TIP_ACTIVIDAD")]
        public String MAE_TIP_ACTIVIDAD { get; set; }
        //Titulo Habilitante
        [Description("NUM_DIA_SUPERV")]
        public Int32 NUM_DIA_SUPERV { get; set; }
        [Description("TRANSPORTE")]
        public String TRANSPORTE { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        //TemEliminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_CSUPERVISION> ListEliTABLA { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }

        //Varibles para pasar valores a la grilla que contiene los días del mes
        [Description("zActDia1")]
        public String zActDia1 { get; set; }
        [Description("zActDia2")]
        public String zActDia2 { get; set; }
        [Description("zActDia3")]
        public String zActDia3 { get; set; }
        [Description("zActDia4")]
        public String zActDia4 { get; set; }
        [Description("zActDi5")]
        public String zActDia5 { get; set; }
        [Description("zActDia6")]
        public String zActDia6 { get; set; }
        [Description("zActDia7")]
        public String zActDia7 { get; set; }
        [Description("zActDia8")]
        public String zActDia8 { get; set; }
        [Description("zActDia9")]
        public String zActDia9 { get; set; }
        [Description("zActDia10")]
        public String zActDia10 { get; set; }
        [Description("zActDia11")]
        public String zActDia11 { get; set; }
        [Description("zActDia12")]
        public String zActDia12 { get; set; }
        [Description("zActDia13")]
        public String zActDia13 { get; set; }
        [Description("zActDia14")]
        public String zActDia14 { get; set; }
        [Description("zActDia15")]
        public String zActDia15 { get; set; }
        [Description("zActDia16")]
        public String zActDia16 { get; set; }
        [Description("zActDia17")]
        public String zActDia17 { get; set; }
        [Description("zActDia18")]
        public String zActDia18 { get; set; }
        [Description("zActDia19")]
        public String zActDia19 { get; set; }
        [Description("zActDia20")]
        public String zActDia20 { get; set; }
        [Description("zActDia21")]
        public String zActDia21 { get; set; }
        [Description("zActDia22")]
        public String zActDia22 { get; set; }
        [Description("zActDia23")]
        public String zActDia23 { get; set; }
        [Description("zActDia24")]
        public String zActDia24 { get; set; }
        [Description("zActDia25")]
        public String zActDia25 { get; set; }
        [Description("zActDia26")]
        public String zActDia26 { get; set; }
        [Description("zActDia27")]
        public String zActDia27 { get; set; }
        [Description("zActDia28")]
        public String zActDia28 { get; set; }
        [Description("zActDia29")]
        public String zActDia29 { get; set; }
        [Description("zActDia30")]
        public String zActDia30 { get; set; }
        [Description("zActDia31")]
        public String zActDia31 { get; set; }

        public Ent_CSUPERVISION()
        {
            NUM_POA = -1;
            EliVALOR02 = -1;
            ANIO = -1;
            RegEstado = -1;
            DIA = -1;
            NUM_DIA_SUPERV = -1;
        }
    }
}
