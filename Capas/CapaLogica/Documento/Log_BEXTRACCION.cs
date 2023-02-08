using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using CDatos = CapaDatos.DOC.Dat_BEXTRACCION;

namespace CapaLogica.DOC
{
    public class Log_BEXTRACCION
    {
        private CDatos oCDatos;

        public Log_BEXTRACCION()
        {
            oCDatos = new CDatos();
        }

        public VM_BalanceExtraccion Init(string asCodTHabilitante, int aiNumPoa)
        {
            VM_BalanceExtraccion vm = new VM_BalanceExtraccion();
            Ent_BEXTRACCION bExt = oCDatos.RegMostrarItems(new Ent_BEXTRACCION() { COD_THABILITANTE = asCodTHabilitante, NUM_POA = aiNumPoa });

            vm.lblTituloCabecera = "Balance de Extracción";
            vm.lblTituloEstado = "Registro";
            vm.hdfCodTHabilitante = bExt.COD_THABILITANTE;
            vm.hdfNumPoa = bExt.NUM_POA;
            vm.txtNombrePoa = bExt.NOMBRE_POA;
            vm.txtResolucionPoa = bExt.ARESOLUCION_NUM;
            vm.txtTHabilitante = bExt.NUM_THABILITANTE;
            vm.txtTitular = bExt.TITULAR;
            vm.hdfCodMTipo = bExt.COD_MTIPO;
            vm.txtModalidad = bExt.MODALIDAD;
            vm.hdfEstadoOrigen = bExt.ESTADO_ORIGEN;
            vm.hdfIndicador = bExt.INDICADOR;

            return vm;
        }

        public List<Ent_BEXTRACCION_FECEMI> ListarBExtraccionPorPlan(string asCodTHabilitante, int aiNumPoa)
        {
            return oCDatos.ListarBExtraccionPorPlan(new Ent_BEXTRACCION() { COD_THABILITANTE = asCodTHabilitante, NUM_POA = aiNumPoa });
        }

        public ListResult GrabarBExtraccionFecEmi(Ent_BEXTRACCION_FECEMI dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                dto.COD_UCUENTA = asCodUCuenta;
                dto.OUTPUTPARAMDET01 = 0;
                oCDatos.GrabarBExtraccionFecEmi(dto);

                result.AddResultado("Datos registrados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult EliminarBExtraccion(Ent_BEXTRACCION_EliTABLA dto)
        {
            ListResult result = new ListResult();

            try
            {
                oCDatos.EliminarBExtraccion(dto);

                result.AddResultado("Registro eliminado correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public List<Ent_BEXTRACCION_MADE> ListarBExtraccionMaderable(string asCodTHabilitante, int aiNumPoa, int aiCodSecuencial)
        {
            return oCDatos.ListarBExtraccionMaderable(new Ent_BEXTRACCION_FECEMI() { COD_THABILITANTE = asCodTHabilitante, NUM_POA = aiNumPoa, COD_SECUENCIAL = aiCodSecuencial });
        }

        public ListResult GrabarBExtraccionMaderable(List<Ent_BEXTRACCION_MADE> lstMaderable, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                oCDatos.GrabarBExtraccionMaderable(lstMaderable, asCodUCuenta);

                result.AddResultado("Datos registrados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public List<Ent_BEXTRACCION_NOMADE> ListarBExtraccionNoMaderable(string asCodTHabilitante, int aiNumPoa, int aiCodSecuencial)
        {
            return oCDatos.ListarBExtraccionNoMaderable(new Ent_BEXTRACCION_FECEMI() { COD_THABILITANTE = asCodTHabilitante, NUM_POA = aiNumPoa, COD_SECUENCIAL = aiCodSecuencial });
        }

        public ListResult GrabarBExtraccionNoMaderable(List<Ent_BEXTRACCION_NOMADE> lstNoMaderable, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                oCDatos.GrabarBExtraccionNoMaderable(lstNoMaderable, asCodUCuenta);

                result.AddResultado("Datos registrados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public List<Ent_BEXTRACCION_KARDEX> ListarBExtraccionKardex(string asCodTHabilitante, int aiNumPoa)
        {
            return oCDatos.ListarBExtraccionKardex(new Ent_BEXTRACCION() { COD_THABILITANTE = asCodTHabilitante, NUM_POA = aiNumPoa });
        }

        public ListResult GrabarBExtraccionKardex(List<Ent_BEXTRACCION_KARDEX> lstKardex, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                oCDatos.GrabarBExtraccionKardex(lstKardex, asCodUCuenta);

                result.AddResultado("Datos registrados correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
    }
}
