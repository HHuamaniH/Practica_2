using CapaEntidad.DOC;
using System;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_Reporte
    {
        
        public string NUM_INFORME { get; set; }
        public string TIPO { get; set; }
        public string RD_QUINQUENAL { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string TITULAR { get; set; }
        public DateTime FECHA_CREACION { get; set; }
    }
    public class VM_InformeQuinquenal
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public string hdfCodDirector { get; set; }
        public string lblDirector { get; set; }
        public string txtFechaEmision { get; set; }
        public string txtNumInform { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoInforme { get; set; }
        public string ddlTipoInformeId { get; set; }
        public string txtFechaInicioAuditoria { get; set; }
        public string txtFechaFinAuditoria { get; set; }

        //panel
        public bool pnlQuinquenal { get; set; }
        public bool pnlEvaluacionHallazgo { get; set; }
        public bool pnlEvaluacionDocumentaria { get; set; }
        public bool pnlEvaluacionCampo { get; set; }

        public string txtDerechoAprovechamiento { get; set; }
        public string txtDisposicionDO { get; set; }
        public string txtOrdenamientoForestal { get; set; }
        public string txtSistemaMarcado { get; set; }
        public string txtArbolesVolumenes { get; set; }
        public string txtProteccionConcesion { get; set; }
        public string txtRelacionPueblos { get; set; }
        public string txtOtrasDispocisiones { get; set; }
        public string txtRequerimientoConsecionario { get; set; }
        public string txtCategoriaOrdenamiento { get; set; }
        public string txtProteccionConcesion2 { get; set; }
        public string txtPlanificacionAprovechamiento { get; set; }
        public string txtAprovechamientoForestal { get; set; }
        public string txtAplicacionSilvi { get; set; }

        public string hdfCodProfesional { get; set; }
        public string txtProfesional { get; set; }
        
        public string txtDirector { get; set; }
        public List<Ent_GENEPERSONA> tbListProfesionales { get; set; }
        //public List<Ent_InfQuinquenal> tbListProfesionales { get; set; }

        public List<Ent_InfQuinquenal> tbListRDQuinquenal { get; set; }

        //hallazgos
        public List<Ent_InfQuinquenal> tbListHallazgos { get; set; }
        public string txtDocumentacionRevisada { get; set; }
        public string txtRecomendaciones { get; set; }

        //Quinquenal 
        public string txtAsunto { get; set; }
        public List<int> cantidadQuinquenio { get; set; }

        public IEnumerable<VM_Cbo> ddlAuditoriaOk { get; set; }
        public string ddlAuditoriaOkId { get; set; }
        public IEnumerable<VM_Cbo> ddlAmpliarContrato { get; set; }
        public string ddlAmpliarContratoId { get; set; }
        public string hdfManCodFCTipo { get; set; }
        public string hdfManCodTInforme { get; set; }
        public string lblTipoInforme { get; set; }
        
        public string txtConclusiones { get; set; }

        public string hdfcod_thabilitante { get; set; }
        
        public string txtHallazgos { get; set; }
        public int hdfRegEstado { get; set; }
        public VM_InformeQuinquenal()
        {
            this.hdfManCodTInforme = "";
            this.ddlTipoInforme= new List<VM_Cbo>()
            {
                    new VM_Cbo() { Value = "0000000",Text = "Seleccionar" },
                    new VM_Cbo() { Value = "0000010",Text = "INFORME DE AUDITORÍA QUINQUENAL" },
                    new VM_Cbo() { Value = "0000014",Text = "INFORME DE HALLAZGOS" }
            };
            this.ddlTipoInformeId = "0000000";
            hdfRegEstado = 1;
            vmControlCalidad = new VM_ControlCalidad_2();
            ddlAuditoriaOkId = "SN";
            ddlAmpliarContratoId = "SN";
            ddlAmpliarContrato = new List<VM_Cbo>()
            {
                    new VM_Cbo() { Value = "SN",Text = "Seleccionar" },
                    new VM_Cbo() { Value = "SI",Text = "SI" },
                    new VM_Cbo() { Value = "NO",Text = "NO" }
            };
            ddlAuditoriaOk = new List<VM_Cbo>()
            {
                    new VM_Cbo() { Value = "SN",Text = "Seleccionar" },
                    new VM_Cbo() { Value = "SI",Text = "SI" },
                    new VM_Cbo() { Value = "NO",Text = "NO" }
            };
            tbListProfesionales = new List<Ent_GENEPERSONA>();
            tbListRDQuinquenal = new List<Ent_InfQuinquenal>();
            tbListHallazgos = new List<Ent_InfQuinquenal>();

            pnlQuinquenal = false;
            pnlEvaluacionHallazgo = false;
            pnlEvaluacionDocumentaria = false;
            pnlEvaluacionCampo = false;

            cantidadQuinquenio = new List<int>();
        }
    }
}
