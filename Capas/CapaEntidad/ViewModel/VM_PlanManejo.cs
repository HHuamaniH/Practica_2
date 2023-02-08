using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
namespace CapaEntidad.ViewModel
{
    public class VM_PlanManejo
    {
        //titulo habilitante
        public string hdfItemCod_THabilitante { get; set; }
        public string hdfItemCOD_PMANEJO { get; set; }
        public string hdfItemIndicador { get; set; }
        public string hdfItemCod_MTipo { get; set; }
        public string lblTituloEstado { get; set; }
        public string ddlItemIndicadorId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemIndicador { get; set; }
        public IEnumerable<VM_Cbo> ddlODRegistro { get; set; }
        public string txtItemNumPlanComplementario { get; set; }
        public string hdfManRegEstado { get; set; }
        public string lblUsuarioRegistro { get; set; }
        public string lblUsuarioControl { get; set; }
        public string lblItemTHModalidad { get; set; }
        public string lblItemTHNumero { get; set; }
        public string lblItemTHTitular { get; set; }
        public string ddlODRegistroId { get; set; }
        public bool ddlItemIndicadorEnable { get; set; }
        public string txtItemFechaPresentacion { get; set; }
        public string lblItemConsultorNombre { get; set; }
        public string hdlblItemConsultorNombre { get; set; }
        public string lblItemConsultorDNI { get; set; }
        public string txtItemConsultorNRConsultor { get; set; }
        public string lblItemConsultorNRProfesional { get; set; }
        public string txtItemItecnico_Iocular_Num { get; set; }
        public string txtItemItecnico_Iocular_Fecha { get; set; }
        public string txtItemItecnico_Raprobacion_Num { get; set; }
        public string txtItemItecnico_Raprobacion_Fecha { get; set; }
        public string txtItemAresolucion_Num { get; set; }
        public string txtItemAresolucion_Fecha { get; set; }
        public string lblItemARFuncionario { get; set; }
        public string hdlblItemARFuncionario { get; set; }
        public bool chkItemAcorde_Tdr_Vigente { get; set; } //bloque trItemTdrVigente
        public string txtItemObservacion { get; set; }
        public string txtItemTaraAManejo { get; set; } //bloque trItemTaraAManejo
        public string txtItemTaraAPredio { get; set; } //bloque trItemTaraAPredio
        public string txtItemTara_ACapacitacion { get; set; }
        public string txtItemTara_MComercializacion { get; set; }
        public string txtItemTara_AnoEPlantacion { get; set; }
        public string lbtItemTaraInventarioSelec { get; set; }
        public bool chkItemActividadPrioritaria { get; set; }
        public string txtAPROB_ACTIVIDAD_FECHA { get; set; }
        public string txtAPROB_ACTIVIDAD_AUTORIZACION { get; set; }
        public string txtAPROB_ACTIVIDAD_RESOLUCION { get; set; }
        public string lblAPROB_ACTIVIDAD_NOM_FUNCIONARIO { get; set; }
        public string hdlblAPROB_ACTIVIDAD_NOM_FUNCIONARIO { get; set; }
        public bool OBSERV_SUBSANAR { get; set; }
        public string txtControlCalidadObservaciones { get; set; }
        //bloque trItemDuracionIS
        public string txtItemISDuracionFInicio { get; set; }
        public string txtItemISDuracionFFin { get; set; }

        public String txtItemConsultorNRRegente { get; set; }
        public bool visiblePlanComplementario { get; set; }

        public String txtCodUbigeo { get; set; }
        public String txtUbigeo { get; set; }
        public String txtDirecion { get; set; }

        public List<Ent_PLAN_MANEJO> ListPMDTTIOCULAR { get; set; }//grvItemIOcular 1
        public List<Ent_PLAN_MANEJO> ListPMDTTRAPROBACION { get; set; }//grvItemTRAprobacion 2
        public List<Ent_PLAN_MANEJO> ListPMTDPPAPROVECHAMIENTO { get; set; }//grvItemTaraPApro  6
        public List<Ent_PLAN_MANEJO> ListPMTDOOPCIONESEAPROVE { get; set; }//grvItemTaraESistemaA  7
        public List<Ent_PLAN_MANEJO> ListPMTDOOPCIONESPSILVI { get; set; }//grvItemTaraPSilvicultural  8
        public List<Ent_PLAN_MANEJO> ListPMDISITUFLORA { get; set; }//grvItemISituInvFlora  5
        public List<Ent_PLAN_MANEJO> ListPMDISITUFAUNA { get; set; }//grvItemISituInvFauna 4
        public List<Ent_PLAN_MANEJO> ListPMDISITUCAREA { get; set; }//grvItemISituCArea   3
        //tara
        public List<Ent_PLAN_MANEJO> ListPMTCOORDENADAUTM { get; set; }//grvItemTaraCUTM 10
        public List<Ent_PLAN_MANEJO> ListPMTAAPROVECHAMIENTO { get; set; }//grvItemTaraAEAprov 11
        public List<Ent_PLAN_MANEJO> ListPMTAUTORIZADAEXTRA { get; set; }//grvItemTaraAutoExtraer 12
        //Ecoturismo
        public List<Ent_PLAN_MANEJO> ListPMECOTPROGIMPLEMENTAR { get; set; }//grvItemEcotPImplementar  9
        public List<Ent_PLAN_MANEJO> ListPMINFORME_ANUAL { get; set; }//grvItemEcotInformeAnual 13

        public List<Ent_PLAN_MANEJO> ListPMTINVENTARIO { get; set; }
        public List<Ent_PLAN_MANEJO> ListEliTABLA { get; set; }

        public List<VM_Cbo> ddlDependencia { get; set; }
        public string ddlDependenciaId { get; set; }
        //
        public string appClient { get; set; }
        public string appData { get; set; }
        public Int16 opRegresar { get; set; }

        //Error Material
        public List<Ent_ERRORMATERIAL> ListPMErrorMaterialG { get; set; }
        public List<Ent_ERRORMATERIAL> ListPMErrorMaterialA { get; set; }

    }
    public class VM_PlanManejoList
    {

        public List<Dictionary<string, string>> ListPMDTTIOCULAR { get; set; }//grvItemIOcular 1
        public List<Dictionary<string, string>> ListPMDTTRAPROBACION { get; set; }//grvItemTRAprobacion 2
        public List<Dictionary<string, string>> ListPMTDPPAPROVECHAMIENTO { get; set; }//grvItemTaraPApro  6
        public List<Dictionary<string, string>> ListPMTDOOPCIONESEAPROVE { get; set; }//grvItemTaraESistemaA  7
        public List<Dictionary<string, string>> ListPMTDOOPCIONESPSILVI { get; set; }//grvItemTaraPSilvicultural  8
        public List<Dictionary<string, string>> ListPMDISITUFLORA { get; set; }//grvItemISituInvFlora  5
        public List<Dictionary<string, string>> ListPMDISITUFAUNA { get; set; }//grvItemISituInvFauna 4
        public List<Dictionary<string, string>> ListPMDISITUCAREA { get; set; }//grvItemISituCArea   3
                                                                               //tara
        public List<Dictionary<string, string>> ListPMTCOORDENADAUTM { get; set; }//grvItemTaraCUTM 10
        public List<Dictionary<string, string>> ListPMTAAPROVECHAMIENTO { get; set; }//grvItemTaraAEAprov 11
        public List<Dictionary<string, string>> ListPMTAUTORIZADAEXTRA { get; set; }//grvItemTaraAutoExtraer 12
                                                                                    //Ecoturismo
        public List<Dictionary<string, string>> ListPMECOTPROGIMPLEMENTAR { get; set; }//grvItemEcotPImplementar  9
        public List<Dictionary<string, string>> ListPMINFORME_ANUAL { get; set; }//grvItemEcotInformeAnual 13

        public List<Dictionary<string, string>> ListPMTINVENTARIO { get; set; }

        public List<Dictionary<string, string>> ListPMErrorMaterialG { get; set; }//Error Material Datos General
        public List<Dictionary<string, string>> ListPMErrorMaterialA { get; set; }//Error Material Datos Adicional
    }

}
