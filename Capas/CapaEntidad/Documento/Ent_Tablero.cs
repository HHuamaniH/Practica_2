using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Tablero_Parametros
    {
        [Category("FECHA"), Description("VAFECINICIO")]
        public string VAFECINICIO { get; set; }
        [Category("FECHA"), Description("VAFECTERMINO")]
        public string VAFECTERMINO { get; set; }
        [Description("VACODDIRECCIONL")]
        public string VACODDIRECCIONL { get; set; }
        [Description("VAFILTRO")]
        public string VAFILTRO { get; set; }
        [Category("FECHA"), Description("VAFECINICIO_DOC")]
        public string VAFECINICIO_DOC { get; set; }
        [Category("FECHA"), Description("VAFECTERMINO_DOC")]
        public string VAFECTERMINO_DOC { get; set; }
    }

    public class Ent_Tablero_Resultados
    {
        [Description("DERIVADOS_DFFFS")]
        public Int32 DERIVADOS_DFFFS { get; set; }
        [Description("INF_EVALUADOS")]
        public Int32 INF_EVALUADOS { get; set; }
        [Description("INF_ARCHIVO")]
        public Int32 INF_ARCHIVO { get; set; }
        [Description("INF_DEVUELTOS")]
        public Int32 INF_DEVUELTOS { get; set; }
        [Description("INF_RSD_INICIO")]
        public Int32 INF_RSD_INICIO { get; set; }
        [Description("RSD_PENDIENTE")]
        public Int32 RSD_PENDIENTE { get; set; }
        [Description("CON_IFI_EMITIDOS")]
        public Int32 CON_IFI_EMITIDOS { get; set; }
        [Description("CON_IFI_PENDIENTES")]
        public Int32 CON_IFI_PENDIENTES { get; set; }
        [Description("RD_EMITIDOS")]
        public Int32 RD_EMITIDOS { get; set; }
        [Description("RD_PENDIENTES")]
        public Int32 RD_PENDIENTES { get; set; }
        [Description("RD_FIRMEZA")]
        public Int32 RD_FIRMEZA { get; set; }
        [Description("RD_PENDIENTE_FIRMEZA")]
        public Int32 RD_PENDIENTE_FIRMEZA { get; set; }
        [Description("DIAS_INFORME")]
        public Int32 DIAS_INFORME { get; set; }
        [Description("DIAS_EVALUACION")]
        public Int32 DIAS_EVALUACION { get; set; }
        [Description("DIAS_INSTRUCCION")]
        public Int32 DIAS_INSTRUCCION { get; set; }
        [Description("DIAS_DECISION")]
        public Int32 DIAS_DECISION { get; set; }
        [Description("MES_PAU")]
        public Int32 MES_PAU { get; set; }
        [Description("MES_INF_PAU")]
        public Int32 MES_INF_PAU { get; set; }
        [Description("IFI_EN_PLAZO")]
        public Int32 IFI_EN_PLAZO { get; set; }
        [Description("IFI_PARA_EMITIR")]
        public Int32 IFI_PARA_EMITIR { get; set; }
        [Description("RD_EN_PLAZO")]
        public Int32 RD_EN_PLAZO { get; set; }
        [Description("RD_PARA_EMITIR")]
        public Int32 RD_PARA_EMITIR { get; set; }
        [Description("FIRMEZA_EN_PLAZO")]
        public Int32 FIRMEZA_EN_PLAZO { get; set; }
        [Description("FIRMEZA_PARA_EMITIR")]
        public Int32 FIRMEZA_PARA_EMITIR { get; set; }
        [Description("PAU_NOT_PENDIENTE_IFI")]
        public Int32 PAU_NOT_PENDIENTE_IFI { get; set; }
        [Description("RD_APELADA_RESUELTA")]
        public Int32 RD_APELADA_RESUELTA { get; set; }
        [Description("RD_CONFIRMADA")]
        public Int32 RD_CONFIRMADA { get; set; }
        [Description("RD_RECONSIDERADA_RESUELTA")]
        public Int32 RD_RECONSIDERADA_RESUELTA { get; set; }
        [Description("RD_EMITIDA")]
        public Int32 RD_EMITIDA { get; set; }
        [Description("CON_RSD_INICIO_NOTIFICADO")]
        public Int32 CON_RSD_INICIO_NOTIFICADO { get; set; }
        [Description("RD_EMITIDOS_NOTIFICADOS")]
        public Int32 RD_EMITIDOS_NOTIFICADOS { get; set; }
        

    }
}
