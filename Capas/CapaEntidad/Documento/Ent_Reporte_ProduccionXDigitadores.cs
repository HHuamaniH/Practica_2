using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_ProduccionXDigitadores
    {

        #region entidades y propiedades
        [Description("CodUsuario")]
        public String CodUsuario { get; set; }
        [Description("BusAnio")]
        public String BusAnio { get; set; }
        [Description("BusMes")]
        public String BusMes { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("BusDLinea")]
        public String BusDLinea { get; set; }
        [Description("Anio")]
        public Int32 Anio { get; set; }
        [Description("MesNombre")]
        public String MesNombre { get; set; }
        [Description("MesNum")]
        public Int32 MesNum { get; set; }
        [Description("TH")]
        public Int32 TH { get; set; }
        [Description("POA")]
        public Int32 POA { get; set; }
        [Description("PM")]
        public Int32 PM { get; set; }
        [Description("CN")]
        public Int32 CN { get; set; }
        [Description("CN_NTF")]
        public Int32 CN_NTF { get; set; }
        [Description("INF")]
        public Int32 INF { get; set; }
        [Description("RD")]
        public Int32 RD { get; set; }
        [Description("ILEG")]
        public Int32 ILEG { get; set; }
        [Description("INTEC")]
        public Int32 INTEC { get; set; }
        [Description("INTIT")]
        public Int32 INTIT { get; set; }
        [Description("TOTAL")]
        public Int32 TOTAL { get; set; }
        [Description("FECHA")]
        public String FECHA { get; set; }
        [Description("TOTALGENERAL")]
        public Int32 TOTALGENERAL { get; set; }
        [Description("PMTC")]
        public Int32 PMTC { get; set; }
        [Description("PMTI")]
        public Int32 PMTI { get; set; }
        [Description("ISUPM")]
        public Int32 ISUPM { get; set; }
        [Description("ISUPNM")]
        public Int32 ISUPNM { get; set; }
        [Description("POAM")]
        public Int32 POAM { get; set; }
        [Description("POANMAD")]
        public Int32 POANMAD { get; set; }
        [Description("THV")]
        public Int32 THV { get; set; }
        [Description("CAP")]
        public Int32 CAP { get; set; }
        [Description("CAPPART")]
        public Int32 CAPPART { get; set; }
        [Description("CAPENC")]
        public Int32 CAPENC { get; set; }
        [Description("NOT_FISC")]
        public Int32 NOT_FISC { get; set; }
        [Description("NOT_FISC_NTF")]
        public Int32 NOT_FISC_NTF { get; set; }

        //Nuevas columnas 11/01/2017
        [Description("ISUP")]
        public Int32 ISUP { get; set; }
        [Description("GTF")]
        public Int32 GTF { get; set; }
        [Description("IFUN")]
        public Int32 IFUN { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("NUM_POA")]
        public String NUM_POA { get; set; }
        [Description("NUM_RESOLUCION")]
        public String NUM_RESOLUCION { get; set; }
        [Description("NOM_CAPACITACION")]
        public String NOM_CAPACITACION { get; set; }
        [Description("NOM_OD")]
        public String NOM_OD { get; set; }
        [Description("FECHA_INICIO")]
        public string FECHA_INICIO { get; set; }
        [Description("FECHA_TERMINO")]
        public string FECHA_TERMINO { get; set; }
        [Description("FECHA_NOTIFICACION")]
        public string FECHA_NOTIFICACION { get; set; }
        [Description("FECHA_CREACION")]
        public string FECHA_CREACION { get; set; }
        [Description("NUM_CNOTIFICACION")]
        public String NUM_CNOTIFICACION { get; set; }
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }
        [Description("NUM_GUIA")]
        public String NUM_GUIA { get; set; }
        [Description("NOM_GUIA")]
        public String NOM_GUIA { get; set; }
        [Description("FECHA_EMISION")]
        public string FECHA_EMISION { get; set; }
        [Description("TIPO_DOCUMENTO")]
        public string TIPO_DOCUMENTO { get; set; }

        //para el detalle de produccion de archivos
        [Description("NOMBRES")]
        public String NOMBRES { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("ESTADO_ORIGEN")]
        public String ESTADO_ORIGEN { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("SEMANAUNO")]
        public Int32 SEMANAUNO { get; set; }
        [Description("SEMANADOS")]
        public Int32 SEMANADOS { get; set; }
        [Description("SEMANATRES")]
        public Int32 SEMANATRES { get; set; }
        [Description("SEMANACUATRO")]
        public Int32 SEMANACUATRO { get; set; }
        [Description("SEMANACINCO")]
        public Int32 SEMANACINCO { get; set; }

        //para los usuarios 

        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("COD_UGRUPO")]
        public String COD_UGRUPO { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }

        //lista de Anios
        [Category("LIST"), Description("LISTpRODUCTO")]
        public List<Ent_Reporte_ProduccionXDigitadores> listAnio { get; set; }

        //para el reporte de registro de informacion SIGO de las OD
        [Description("Modalidad")]
        public String Modalidad { get; set; }
        [Description("enero")]
        public Int32 enero { get; set; }
        [Description("febrero")]
        public Int32 febrero { get; set; }
        [Description("marzo")]
        public Int32 marzo { get; set; }
        [Description("abril")]
        public Int32 abril { get; set; }
        [Description("mayo")]
        public Int32 mayo { get; set; }
        [Description("junio")]
        public Int32 junio { get; set; }
        [Description("julio")]
        public Int32 julio { get; set; }
        [Description("agosto")]
        public Int32 agosto { get; set; }
        [Description("septiembre")]
        public Int32 septiembre { get; set; }
        [Description("octubre")]
        public Int32 octubre { get; set; }
        [Description("noviembre")]
        public Int32 noviembre { get; set; }
        [Description("diciembre")]
        public Int32 diciembre { get; set; }
        // AVANCES
        [Description("eneroAV")]
        public Decimal eneroAV { get; set; }
        [Description("febreroAV")]
        public Decimal febreroAV { get; set; }
        [Description("marzoAV")]
        public Decimal marzoAV { get; set; }
        [Description("abrilAV")]
        public Decimal abrilAV { get; set; }
        [Description("mayoAV")]
        public Decimal mayoAV { get; set; }
        [Description("junioAV")]
        public Decimal junioAV { get; set; }
        [Description("julioAV")]
        public Decimal julioAV { get; set; }
        [Description("agostoAV")]
        public Decimal agostoAV { get; set; }
        [Description("septiembreAV")]
        public Decimal septiembreAV { get; set; }
        [Description("octubreAV")]
        public Decimal octubreAV { get; set; }
        [Description("noviembreAV")]
        public Decimal noviembreAV { get; set; }
        [Description("diciembreAV")]
        public Decimal diciembreAV { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("TITULO")]
        public String TITULO { get; set; }
        [Description("CARTA")]
        public String CARTA { get; set; }
        [Description("NUM_RD")]
        public String NUM_RD { get; set; }
        [Description("FECHA_NOTIFICACION_TITULAR")]
        public String FECHA_NOTIFICACION_TITULAR { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        //para el reporte produccion por OD
        [Description("ORGANIZADOR")]
        public String ORGANIZADOR { get; set; }
        [Description("PUBLICO_OBJECTIVO")]
        public String PUBLICO_OBJECTIVO { get; set; }
        [Description("N_PARTICIPANTES")]
        public Int32 N_PARTICIPANTES { get; set; }
        [Description("MARCO_CONVENIO")]
        public Object MARCO_CONVENIO { get; set; }
        [Description("META")]
        public Int32 META { get; set; }

        #endregion
        public Ent_Reporte_ProduccionXDigitadores()
        {
            MesNum = -1;
            TH = -1;
            POA = -1;
            PM = -1;
            CN = -1;
            INF = -1;
            RD = -1;
            ILEG = -1;
            INTEC = -1;
            INTIT = -1;
            TOTAL = -1;
            TOTALGENERAL = -1;
            N_PARTICIPANTES = -1;
            SEMANAUNO = -1;
            SEMANADOS = -1;
            SEMANATRES = -1;
            SEMANACUATRO = -1;
            SEMANACINCO = -1;
            PMTC = -1;
            PMTI = -1;
            ISUPM = -1;
            ISUPNM = -1;
            POAM = -1;
            POANMAD = -1;
            THV = -1;
            Anio = -1;
            CAP = -1;
            NOT_FISC = -1;
            CAPPART = -1;
            CAPENC = -1;

            ISUP = -1;
            GTF = -1;
            IFUN = -1;
            //NUM_POA = -1;
            CN_NTF = -1;
            NOT_FISC_NTF = -1;

            // reporte de registro de informacion SIGO
            enero = -1;
            febrero = -1;
            marzo = -1;
            abril = -1;
            mayo = -1;
            junio = -1;
            julio = -1;
            agosto = -1;
            septiembre = -1;
            octubre = -1;
            noviembre = -1;
            diciembre = -1;
            META = -1;
            //AVANCES
            eneroAV = -1;
            febreroAV = -1;
            marzoAV = -1;
            abrilAV = -1;
            mayoAV = -1;
            junioAV = -1;
            julioAV = -1;
            agostoAV = -1;
            septiembreAV = -1;
            octubreAV = -1;
            noviembreAV = -1;
            diciembreAV = -1;
        }
    }
}
