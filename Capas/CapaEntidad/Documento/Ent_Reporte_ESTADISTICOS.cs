using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    // 12/02/2020   EPB Se añade el parametro DSMILVEINTE Y 2020 para generar las estadisticas actualizadas
    public class Ent_Reporte_ESTADISTICOS
    {
        [Description("AÑO")]
        public Int32 ANIO { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusModalidad")]
        public String BusModalidad { get; set; }
        [Description("BusDireccion")]
        public String BusDireccion { get; set; }
        [Description("BusDireccion2")]
        public String BusDireccion2 { get; set; }
        [Description("BusRegion")]
        public String BusRegion { get; set; }
        [Description("BusAnio")]
        public String BusAnio { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("VOL_AUTORIZADO")]
        public Decimal VOL_AUTORIZADO { get; set; }
        [Description("VOL_MOVILIZADO")]
        public Decimal VOL_MOVILIZADO { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }

        [Description("EXISTENTES")]
        public Int32 EXISTENTES { get; set; }
        [Description("INEXISTENTES")]
        public Int32 INEXISTENTES { get; set; }
        [Description("TOTAL_ARBOLES")]
        public Int32 TOTAL_ARBOLES { get; set; }
        [Description("TOTAL_PLANES")]
        public Int32 TOTAL_PLANES { get; set; }

        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("CANT_ZOOL")]
        public Decimal CANT_ZOOL { get; set; }
        [Description("CANT_ZOOC")]
        public Decimal CANT_ZOOC { get; set; }
        [Description("CANT_CRES")]
        public Decimal CANT_CRES { get; set; }
        [Description("CANT_CCT")]
        public Decimal CANT_CCT { get; set; }
        [Description("CANT_NMCAST")]
        public Decimal CANT_NMCAST { get; set; }
        [Description("CANT_NMSHIR")]
        public Decimal CANT_NMSHIR { get; set; }
        [Description("CANT_NMAGU")]
        public Decimal CANT_NMAGU { get; set; }
        [Description("CANT_ECO")]
        public Decimal CANT_ECO { get; set; }
        [Description("CANT_CONS")]
        public Decimal CANT_CONS { get; set; }
        [Description("CANT_CFAUNA")]
        public Decimal CANT_CFAUNA { get; set; }
        [Description("CANT_PFAUNA")]
        public Decimal CANT_PFAUNA { get; set; }
        [Description("CANT_SISAG")]
        public Decimal CANT_SISAG { get; set; }
        [Description("CANT_CARRIZO")]
        public Decimal CANT_CARRIZO { get; set; }
        [Description("CANT_PMEDICI")]
        public Decimal CANT_PMEDICI { get; set; }
        [Description("CANT_CCCC_CCNN")]
        public Decimal CANT_CCCC_CCNN { get; set; }
        [Description("CANT_PNM")]
        public Decimal CANT_PNM { get; set; }
        [Description("CANT_BS")]
        public Decimal CANT_BS { get; set; }
        [Description("CANT_CCNN")]
        public Decimal CANT_CCNN { get; set; }
        [Description("CANT_PP")]
        public Decimal CANT_PP { get; set; }
        [Description("CANT_CCCC")]
        public Decimal CANT_CCCC { get; set; }
        [Description("CANT_TARA")]
        public Decimal CANT_TARA { get; set; }
        [Description("CANT_BL")]
        public Decimal CANT_BL { get; set; }
        [Description("CANT_CMADE")]
        public Decimal CANT_CMADE { get; set; }
        [Description("CANT_NM")]
        public Decimal CANT_NM { get; set; }
        [Description("CANT_FYR")]
        public Decimal CANT_FYR { get; set; }
        [Description("TOTAL")]
        public Decimal TOTAL { get; set; }

        [Description("DOSMILCINCO")]
        public Int32 DOSMILCINCO { get; set; }
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
        [Description("DOSMILDIECINUEVE")]
        public Int32 DOSMILDIECINUEVE { get; set; }
        [Description("DOSMILVEINTE")]
        public Int32 DOSMILVEINTE { get; set; }
        [Description("DOSMILVEINTIUNO")]
        public Int32 DOSMILVEINTIUNO { get; set; }
        [Description("DOSMILVEINTIDOS")]
        public Int32 DOSMILVEINTIDOS { get; set; }
        [Description("DOSMILVEINTITRES")]
        public Int32 DOSMILVEINTITRES { get; set; }
        [Description("DOSMILVEINTICUATRO")]
        public Int32 DOSMILVEINTICUATRO { get; set; }
        [Description("NUM_CAPACITACIONES")]
        public Int32 NUM_CAPACITACIONES { get; set; }
        [Description("NUM_PARTICIPANTES")]
        public Int32 NUM_PARTICIPANTES { get; set; }
        [Description("NUM_HOMBRES")]
        public Int32 NUM_HOMBRES { get; set; }
        [Description("NUM_MUJERES")]
        public Int32 NUM_MUJERES { get; set; }

        //Reporte Estado Procesos Fiscalización
        [Description("SUPERVISION")]
        public Int32 SUPERVISION { get; set; }
        [Description("CANTIDAD")]
        public Int32 CANTIDAD { get; set; }
        [Description("INICIO PAU")]
        public Int32 INI_PAU { get; set; }
        [Description("TERMINO PAU")]
        public Int32 TERMINO_PAU { get; set; }
        [Description("SANCIONADO_PAU")]
        public Int32 SANCIONADO_PAU { get; set; }
        [Description("CADUCADO_PAU")]
        public Int32 CADUCADO_PAU { get; set; }
        [Description("CADUCADO_PAU_TH")]
        public Int32 CADUCADO_PAU_TH { get; set; }
        [Description("SUPER_TERMINADO_PAU")]
        public Int32 SUPER_TERMINADO_PAU { get; set; }
        [Description("ARCHIVO_PRELIMINAR")]
        public Int32 ARCHIVO_PRELIMINAR { get; set; }
        [Description("ARCHIVO_PRELIMINAR_SIN")]
        public Int32 ARCHIVO_PRELIMINAR_SIN { get; set; }
        [Description("ARCHIVO_PAU")]
        public Int32 ARCHIVO_PAU { get; set; }
        [Description("MEDCAU_PAU")]
        public Int32 MEDCAU_PAU { get; set; }
        [Description("MEDPRECAU_PAU")]
        public Int32 MEDPRECAU_PAU { get; set; }
        [Description("SUPER_CASOS_INEX")]
        public Int32 SUPER_CASOS_INEX { get; set; }
        [Description("SUPER_ARBOLES_INEX")]
        public Int32 SUPER_ARBOLES_INEX { get; set; }
        [Description("VOL_INI_i_PAU")]
        public Decimal VOL_INI_i_PAU { get; set; }
        [Description("VOL_INI_w_PAU")]
        public Decimal VOL_INI_w_PAU { get; set; }
        [Description("VOL_TER_i_PAU")]
        public Decimal VOL_TER_i_PAU { get; set; }
        [Description("VOL_TER_w_PAU")]
        public Decimal VOL_TER_w_PAU { get; set; }
        [Description("UIT_TER_PAU")]
        public Decimal UIT_TER_PAU { get; set; }
        [Description("CASOS_SOLO_i_TER_PAU")]
        public Int32 CASOS_SOLO_i_TER_PAU { get; set; }
        [Description("CASOS_SOLO_w_TER_PAU")]
        public Int32 CASOS_SOLO_w_TER_PAU { get; set; }
        [Description("CASOS_SOLO_i_w_TER_PAU")]
        public Int32 CASOS_SOLO_i_w_TER_PAU { get; set; }
        [Description("CASOS_i_w_TER_PAU")]
        public Int32 CASOS_i_w_TER_PAU { get; set; }
        [Description("CASOS")]
        public Int32 CASOS { get; set; }
        [Description("AVANCE_CASOS")]
        public Decimal AVANCE_CASOS { get; set; }
        [Description("AVANCE")]
        public Decimal AVANCE { get; set; }
        [Description("AVANCE1")]
        public Decimal AVANCE1 { get; set; }

        [Category("LIST"), Description("ListCapacitacionRegion")]
        public List<Ent_Reporte_ESTADISTICOS> ListCapacitacionRegion { get; set; }
        [Category("LIST"), Description("ListCapacitacionParticipante")]
        public List<Ent_Reporte_ESTADISTICOS> ListCapacitacionParticipante { get; set; }
        [Category("LIST"), Description("ListISupervision_Region_Modalidad")]
        public List<Ent_Reporte_ESTADISTICOS> ListISupervision_Region_Modalidad { get; set; }
        [Category("LIST"), Description("ListISupervision_Modalidad_Anio")]
        public List<Ent_Reporte_ESTADISTICOS> ListISupervision_Modalidad_Anio { get; set; }
        [Category("LIST"), Description("ListISupervision_Region_Anio")]
        public List<Ent_Reporte_ESTADISTICOS> ListISupervision_Region_Anio { get; set; }

        //Columnas adicionales para el reporte de planes de manejo maderables supervisado por el OSINFOR
        [Description("REGENTES")]
        public Int32 REGENTES { get; set; }
        [Description("REGENTES_EXISTENTE")]
        public Int32 REGENTES_EXISTENTE { get; set; }
        [Description("FUNCIONARIOS")]
        public Int32 FUNCIONARIOS { get; set; }
        [Description("FUNCIONARIOS_EXISTENTE")]
        public Int32 FUNCIONARIOS_EXISTENTE { get; set; }

        //Departamentos, columnas nuevas para actualizar el reporte estadístico #2
        [Description("AMAZONAS")]
        public Decimal AMAZONAS { get; set; }
        [Description("ANCASH")]
        public Decimal ANCASH { get; set; }
        [Description("APURIMAC")]
        public Decimal APURIMAC { get; set; }
        [Description("AREQUIPA")]
        public Decimal AREQUIPA { get; set; }
        [Description("AYACUCHO")]
        public Decimal AYACUCHO { get; set; }
        [Description("CAJAMARCA")]
        public Decimal CAJAMARCA { get; set; }
        [Description("CALLAO")]
        public Decimal CALLAO { get; set; }
        [Description("CUSCO")]
        public Decimal CUSCO { get; set; }
        [Description("HUANCAVELICA")]
        public Decimal HUANCAVELICA { get; set; }
        [Description("HUANUCO")]
        public Decimal HUANUCO { get; set; }
        [Description("ICA")]
        public Decimal ICA { get; set; }
        [Description("JUNIN")]
        public Decimal JUNIN { get; set; }
        [Description("LALIBERTAD")]
        public Decimal LALIBERTAD { get; set; }
        [Description("LAMBAYEQUE")]
        public Decimal LAMBAYEQUE { get; set; }
        [Description("LIMA")]
        public Decimal LIMA { get; set; }
        [Description("LORETO")]
        public Decimal LORETO { get; set; }
        [Description("MADREDEDIOS")]
        public Decimal MADREDEDIOS { get; set; }
        [Description("MOQUEGUA")]
        public Decimal MOQUEGUA { get; set; }
        [Description("PASCO")]
        public Decimal PASCO { get; set; }
        [Description("PIURA")]
        public Decimal PIURA { get; set; }
        [Description("PUNO")]
        public Decimal PUNO { get; set; }
        [Description("SANMARTIN")]
        public Decimal SANMARTIN { get; set; }
        [Description("TACNA")]
        public Decimal TACNA { get; set; }
        [Description("TUMBES")]
        public Decimal TUMBES { get; set; }
        [Description("UCAYALI")]
        public Decimal UCAYALI { get; set; }

        public Ent_Reporte_ESTADISTICOS()
        {
            VOL_AUTORIZADO = -1;
            VOL_MOVILIZADO = -1;
            ANIO = -1;
            TOTAL_ARBOLES = -1;
            TOTAL_PLANES = -1;
            EXISTENTES = -1;
            INEXISTENTES = -1;
            CANT_BS = -1;
            CANT_CCNN = -1;
            CANT_PP = -1;
            CANT_CCCC = -1;
            CANT_TARA = -1;
            CANT_BL = -1;
            CANT_CMADE = -1;
            CANT_NM = -1;
            CANT_FYR = -1;
            TOTAL = -1;

            CANT_ZOOL = -1;
            CANT_ZOOC = -1;
            CANT_CRES = -1;
            CANT_CCT = -1;
            CANT_NMCAST = -1;
            CANT_NMSHIR = -1;
            CANT_NMAGU = -1;
            CANT_ECO = -1;
            CANT_CONS = -1;
            CANT_CFAUNA = -1;
            CANT_PFAUNA = -1;
            CANT_SISAG = -1;
            CANT_CARRIZO = -1;
            CANT_PMEDICI = -1;
            CANT_CCCC_CCNN = -1;
            CANT_PNM = -1;

            DOSMILCINCO = -1;
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
            DOSMILDIECINUEVE = -1;
            DOSMILVEINTE = -1;
            DOSMILVEINTIUNO = -1;
            DOSMILVEINTIDOS = -1;
            DOSMILVEINTITRES = -1;
            DOSMILVEINTICUATRO = -1;
            NUM_CAPACITACIONES = -1;
            NUM_PARTICIPANTES = -1;
            NUM_HOMBRES = -1;
            NUM_MUJERES = -1;

            SUPERVISION = -1;
            CANTIDAD = -1;
            INI_PAU = -1;
            TERMINO_PAU = -1;
            SANCIONADO_PAU = -1;
            CADUCADO_PAU = -1;
            CADUCADO_PAU_TH = -1;
            SUPER_TERMINADO_PAU = -1;
            ARCHIVO_PRELIMINAR = -1;
            ARCHIVO_PRELIMINAR_SIN = -1;
            ARCHIVO_PAU = -1;
            MEDCAU_PAU = -1;
            MEDPRECAU_PAU = -1;
            SUPER_CASOS_INEX = -1;
            SUPER_ARBOLES_INEX = -1;
            VOL_INI_i_PAU = -1;
            VOL_INI_w_PAU = -1;
            VOL_TER_i_PAU = -1;
            VOL_TER_w_PAU = -1;
            UIT_TER_PAU = -1;
            CASOS_SOLO_i_TER_PAU = -1;
            CASOS_SOLO_w_TER_PAU = -1;
            CASOS_SOLO_i_w_TER_PAU = -1;
            CASOS_i_w_TER_PAU = -1;
            CASOS = -1;
            AVANCE_CASOS = -1;
            AVANCE = -1;
            AVANCE1 = -1;

            REGENTES = -1;
            REGENTES_EXISTENTE = -1;
            FUNCIONARIOS = -1;
            FUNCIONARIOS_EXISTENTE = -1;

            AMAZONAS = -1;
            ANCASH = -1;
            APURIMAC = -1;
            AREQUIPA = -1;
            AYACUCHO = -1;
            CAJAMARCA = -1;
            CALLAO = -1;
            CUSCO = -1;
            HUANCAVELICA = -1;
            HUANUCO = -1;
            ICA = -1;
            JUNIN = -1;
            LALIBERTAD = -1;
            LAMBAYEQUE = -1;
            LIMA = -1;
            LORETO = -1;
            MADREDEDIOS = -1;
            MOQUEGUA = -1;
            PASCO = -1;
            PIURA = -1;
            PUNO = -1;
            SANMARTIN = -1;
            TACNA = -1;
            TUMBES = -1;
            UCAYALI = -1;
        }
    }
}
