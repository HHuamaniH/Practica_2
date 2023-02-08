//using Oracle.ManagedDataAccess.Client;
using System;
//using System.Data.SqlClient;
using CDatos = CapaDatos.GENE.Dat_DEPENDENCIA_UBIGEO;
using CEntidad = CapaEntidad.GENE.Ent_DEPENDENCIA_UBIGEO;
namespace CapaLogica.GENE
{
    public class Log_DEPENDENCIA_UBIGEO
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            /* CEntidad oCampos = new CEntidad();
             oCampos.BusFormulario = "UBIGEO";
             oCampos.BusCriterio = "TODOS";*/
            try { return oCDatos.RegMostrarCombo(oCEntidad); }
            catch (Exception ex) { throw ex; }
        }

    }
}
