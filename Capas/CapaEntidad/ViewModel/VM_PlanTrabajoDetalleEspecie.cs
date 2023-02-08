using System;

namespace CapaEntidad.ViewModel
{
    public class VM_PlanTrabajoDetalleEspecie
    {
        public long idCabecera { get; set; } //COD_PLAN_TRABAJO_SUPERVISION_DETALLE
        public long id { get; set; } //COD_PLAN_T_DETALLE_ESPECIE
        public long idCodAdicional { get; set; } //COD_ESPECIE_ADICIONAL_SUPERVISAR
        public string codEspecie { get; set; }
        public string descripcionEspecie { get; set; }
        public int totalIndividuos { get; set; }
        public int numAprov { get; set; }
        public int numSemilleros { get; set; }
        public decimal volAutorizado { get; set; }
        public decimal volMovilizado { get; set; }

        //para las especies que son CITES
        public string AGRADO_CITE { get; set; }
        public bool TIENE_AGRADO_CITE { get; set; }
        public string Observacion { get; set; }

        public string PCA { get; set; }
        //datos calculados
        public decimal abundanciaCalificacion { get; set; }
        public int abundanciaPuntaje { get; set; }
        public decimal volAprobadoCalificacion { get; set; }
        public int volAprobadoPuntaje { get; set; }
        public decimal volMovilizadoCalificacion { get; set; }
        public int volMovilizadoPuntaje { get; set; }

        //datos a puntaje despues
        public Int32 puntajeEspeciesAmenazadas { get; set; }
        public string IdPuntajeEspeciesAmenazadas { get; set; }
        public Int32 puntajeCategoriaMad { get; set; }
        public string IdPuntajeCategoriaMad { get; set; }
        public string calEspeciesAmenazadas { get; set; }
        public string calCategoriaMad { get; set; }

        //puntaje total
        public int puntajeTotalCalificacion { get; set; }
        public decimal puntajeTotalPorcentaje { get; set; }

        //campos de muestra mínima

        public decimal? factorAprov { get; set; }
        public decimal? factorSem { get; set; }
        public Int32 muestraAprov { get; set; }
        public Int32 muestraSem { get; set; }
        public decimal muestraMinima { get; set; }

        public string obs { get; set; }

        public int tipo { get; set; }  //1. Especie adicional desde la calificación 2. Especie adicional desde muestra mínima 3. Especie CITE

        public int fuenteOrigen { get; set; }

        //Especie final a supervisar
        public Int32 muestraAprovFinal { get; set; }
        public Int32 muestraSemFinal { get; set; }
        public string obsFinal { get; set; }

        public Int32 perteneceMuestraMinima { get; set; }

        public Int64 idModificarFinal { get; set; }
    }
}
