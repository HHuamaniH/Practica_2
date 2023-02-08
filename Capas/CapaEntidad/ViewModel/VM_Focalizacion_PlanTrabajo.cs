using System;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_Focalizacion_PlanTrabajo_List
    {
        public string idPlanTrajo { get; set; }
        public DateTime fRegistro { get; set; }
        public string fRegistroText { get; set; }
        public string od { get; set; }
        public string periodo { get; set; }
        public string mes { get; set; }
        public string supervisor { get; set; }
        public string funcionario { get; set; }
        public string estadoDoc { get; set; }
        public bool estado { get; set; }
    }
    public class VM_Focalizacion_PlanTrabajo
    {

        public string idPlanTrajo { get; set; }
        public IEnumerable<VM_Cbo> ddlIOD { get; set; }
        public string ddlIODId { get; set; }
        public IEnumerable<VM_Cbo> ddlPeriodo { get; set; }
        public string ddlPeriodoId { get; set; }
        public IEnumerable<VM_Cbo> ddlMes { get; set; }
        public Int16 ddlMesId { get; set; }
        public string funcionarioResponsableId { get; set; }
        public string funcionarioResponsable { get; set; }
        public string funcionarioResponsableNA { get; set; }
        public string usuarioCreacion { get; set; }
        public string usuarioCreacionNA { get; set; }
        public string codUsuarioCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public bool ddlItemIndicadorEnable { get; set; }
        public string ddlItemIndicadorId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemIndicador { get; set; }
        public string observacionControl { get; set; }
        public bool observacionSubsanar { get; set; }
        public DateTime fCreacion { get; set; }
        public string od { get; set; }
        public string mesFocalizacion { get; set; }


    }
    public class VM_Focalizacion_PlanTrabajoDet
    {
        public long idPlanTrajoDet { get; set; }
        public string idPlanTrajo { get; set; }
        public string codPlan { get; set; }
        public int codSecuencial { get; set; }
        public int tipoSupId { get; set; }
        public int oportunidadSupId { get; set; }
        public string codUsuarioCreacion { get; set; }

    }
    public class VM_Focalizacion_PlanTrabajoDet_List
    {
        public string idPlan { get; set; }
        public long idPlanTrajoDet { get; set; }
        public string tipoSupervision { get; set; }
        public string oportunidadSupervision { get; set; }
        public string codTH { get; set; }
        public int numPoa { get; set; }
        public string tipoPManejo { get; set; }
        public string nombrePManejo { get; set; }
        public string titular { get; set; }
        public string numTH { get; set; }
        public string codMTipo { get; set; }
        public string modalidad { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string criterios { get; set; }
        public string OdAmbito { get; set; }
    }
}
