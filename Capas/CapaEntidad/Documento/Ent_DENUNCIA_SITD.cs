using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_DENUNCIA_SITD
    {
        [Description("COD_TRAMITE_SITD")]
        public Int32 COD_TRAMITE_SITD { get; set; }
        [Description("PERTENECE_SECTOR_FORESTAL")]
        public String PERTENECE_SECTOR_FORESTAL { get; set; }
        [Description("CORRESPONDE_AREA_OSINFOR")]
        public String CORRESPONDE_AREA_OSINFOR { get; set; }
        [Description("COMPETENCIA_OSINFOR")]
        public String COMPETENCIA_OSINFOR { get; set; }
        [Description("TRASLADAR_OTRA_ENTIDAD")]
        public object TRASLADAR_OTRA_ENTIDAD { get; set; }
        [Description("DESCRIPCION_OTRA_ENTIDAD")]
        public String DESCRIPCION_OTRA_ENTIDAD { get; set; }
        [Description("DISPONE_ITECNICO")]
        public object DISPONE_ITECNICO { get; set; }
        [Description("COD_PROFESIONAL_ITECNICO")]
        public String COD_PROFESIONAL_ITECNICO { get; set; }
        [Description("PROFESIONAL_ITECNICO")]
        public String PROFESIONAL_ITECNICO { get; set; }
        [Description("DISPONE_EMISION_CARTA")]
        public object DISPONE_EMISION_CARTA { get; set; }
        [Description("DISPONE_SOLINF_AFFS")]
        public object DISPONE_SOLINF_AFFS { get; set; }
        [Description("DISPONE_OTROS")]
        public object DISPONE_OTROS { get; set; }
        [Description("DESCRIPCION_OTROS")]
        public String DESCRIPCION_OTROS { get; set; }

        [Description("NUM_DREFERENCIA")]
        public String NUM_DREFERENCIA { get; set; }
        [Category("FECHA"), Description("FECHA_SITD")]
        public Object FECHA_SITD { get; set; }
        [Description("ESTADO_DREFERENCIA")]
        public String ESTADO_DREFERENCIA { get; set; }
        [Description("OBSERVACION_TRANSFERENCIA")]
        public String OBSERVACION_TRANSFERENCIA { get; set; }
        [Description("ASUNTO")]
        public String ASUNTO { get; set; }
        [Description("PDF_TRAMITE_SITD")]
        public String PDF_TRAMITE_SITD { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("BusAnio")]
        public String BusAnio { get; set; }

        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }

        //Reporte Gestión de Denuncias
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("COD_ANIO_MES")]
        public String COD_ANIO_MES { get; set; }
        [Description("ANIO_MES")]
        public String ANIO_MES { get; set; }
        [Description("N_DENUNCIA")]
        public Int32 N_DENUNCIA { get; set; }
        [Description("N_DENUNCIA_PENDIENTE")]
        public Int32 N_DENUNCIA_PENDIENTE { get; set; }
        [Description("N_DENUNCIA_REVISADO")]
        public Int32 N_DENUNCIA_REVISADO { get; set; }
        [Description("N_DENUNCIA_ANULADO")]
        public Int32 N_DENUNCIA_ANULADO { get; set; }
        [Description("N_SECTOR_FORESTAL")]
        public Int32 N_SECTOR_FORESTAL { get; set; }
        [Description("N_COMPETENCIA_OSINFOR")]
        public Int32 N_COMPETENCIA_OSINFOR { get; set; }
        [Description("N_DENUNCIA_ATENDIDA")]
        public Int32 N_DENUNCIA_ATENDIDA { get; set; }
        [Description("ENTIDAD")]
        public String ENTIDAD { get; set; }
        [Category("FECHA"), Description("FECHA_ATENCION")]
        public Object FECHA_ATENCION { get; set; }
        [Description("NUM_DREFERENCIA_ASOCIADO")]
        public String NUM_DREFERENCIA_ASOCIADO { get; set; }
        [Description("DISPONE")]
        public String DISPONE { get; set; }
        [Description("DISPONE_DOCUMENTO")]
        public String DISPONE_DOCUMENTO { get; set; }
        [Description("ASUNTO_DOCUMENTO")]
        public String ASUNTO_DOCUMENTO { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR_PAU_TRAMITE")]
        public String TITULAR_PAU_TRAMITE { get; set; }
        [Description("REQUIERE_SUPERVISION")]
        public String REQUIERE_SUPERVISION { get; set; }
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }

        public Ent_DENUNCIA_SITD()
        {
            COD_TRAMITE_SITD = -1;
            EliVALOR02 = -1;
            N_DENUNCIA = -1;
            N_DENUNCIA_PENDIENTE = -1;
            N_DENUNCIA_REVISADO = -1;
            N_DENUNCIA_ANULADO = -1;
            N_SECTOR_FORESTAL = -1;
            N_COMPETENCIA_OSINFOR = -1;
            N_DENUNCIA_ATENDIDA = -1;
        }
    }
}
