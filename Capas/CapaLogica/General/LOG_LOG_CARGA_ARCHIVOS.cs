using CapaDatos.GENE;
using CapaEntidad.GENE;

namespace CapaLogica.GENE
{
    public class LOG_LOG_CARGA_ARCHIVOS
    {
        private Dat_LOG_CARGA_ARCHIVOS dat;
        public void registrarTranLog(Ent_LOG_CARGA_ARCHIVOS CENT)
        {
            dat = new Dat_LOG_CARGA_ARCHIVOS();
            dat.regTranLog(CENT);
        }
    }
}
