using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Log_POA log = new Log_POA();
                Ent_POA datModificar = new Ent_POA();

                Ent_POA oCamposMod = new Ent_POA();
                oCamposMod.COD_THABILITANTE = dto.COD_THABILITANTE;
                oCamposMod.NUM_POA = dto.NUM_POA;

                datModificar = log.RegMostrarListaItems(oCamposMod);

                var contEspeciesAprobadas = datModificar.ListRAprueba.Count;
                if(contEspeciesAprobadas <= 0)
                {
                    result.AddResultado("Debe ingresar al menos un registro en las especies aprobadas", false);
                } 
                else
                {
                    dto.COD_UCUENTA = asCodUCuenta;
                    dto.OUTPUTPARAMDET01 = 0;
                    oCDatos.GrabarBExtraccionFecEmi(dto);

                    var codSecuencial = ObtenerUltimoCodigoSecuencialDeLasFechasDelBalanceExtraccion(dto.COD_THABILITANTE, dto.NUM_POA);
                    InsertarBalanceExtraccionMaderableNoMaderable(datModificar.ListRAprueba, asCodUCuenta, codSecuencial, dto.COD_THABILITANTE, dto.NUM_POA);

                    result.AddResultado("Datos registrados correctamente", true);
                }
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

        public int InsertarBalanceExtraccionMaderableNoMaderable(List<Ent_POA> lista, string asCodUCuenta, int codSecuencial, string codTHabilitante, int numPOA)
        {
            List<Ent_BEXTRACCION_MADE> listaInsertar = new List<Ent_BEXTRACCION_MADE>();

            foreach (var item in lista)
            {
                // OBTENER TODOS LOS DATOS DEL REGISTRO SI ES EDITAR
                //var result = GrabarBExtraccionMaderable(listaInsertar, asCodUCuenta);

                Ent_BEXTRACCION_MADE guardar = new Ent_BEXTRACCION_MADE();
                //guardar.AUTORIZADO = -1;
                //guardar.CANTIDAD = -1;
                guardar.COD_SECUENCIAL_BEXT = codSecuencial;
                guardar.COD_THABILITANTE = codTHabilitante;
                guardar.COD_UCUENTA = null;
                guardar.ESPECIES = null;
                guardar.ESPECIES_SERFOR = null;
                //guardar.EXTRAIDO = -1;
                guardar.FECHA1 = null;
                guardar.FECHA2 = null;
                guardar.GUIA_TRANSPORTE = null;
                guardar.NUM_POA = numPOA;
                guardar.PC = null;
                guardar.RECIBO = null;
                //guardar.RegEstado = item.RegEstado;

                guardar.COD_ESPECIES = item.COD_ESPECIES;
                guardar.COD_ESPECIES_SERFOR = item.COD_ESPECIES_SERFOR;
                guardar.TOTAL_ARBOLES = item.NUM_ARBOLES;
                guardar.VOLUMEN_AUTORIZADO = item.VOLUMEN_KILOGRAMOS;
                guardar.UNIDAD_MEDIDA = item.UNIDAD_MEDIDA;
                guardar.TIPOMADERABLE = item.TIPOMADERABLE;
                guardar.PC = item.PCA;
                guardar.COD_SECUENCIAL = item.COD_SECUENCIAL;

                List<Ent_BEXTRACCION_MADE> resultados = ListarBExtraccionMaderable(codTHabilitante, numPOA, codSecuencial);
                //var encontrado = resultados.Where(x => x.COD_ESPECIES == guardar.COD_ESPECIES && x.COD_ESPECIES_SERFOR == guardar.COD_ESPECIES_SERFOR);
                var encontrado = resultados.Where(x => x.COD_SECUENCIAL == guardar.COD_SECUENCIAL);
                if (encontrado.Count() > 0)
                {
                    guardar.DMC = encontrado.FirstOrDefault().DMC;
                    guardar.VOLUMEN_MOVILIZADO = encontrado.FirstOrDefault().VOLUMEN_MOVILIZADO;
                    guardar.SALDO = encontrado.FirstOrDefault().SALDO;
                    guardar.OBSERVACION = encontrado.FirstOrDefault().OBSERVACION;
                    guardar.RegEstado = 2;
                }
                else
                {
                    guardar.DMC = 0;
                    guardar.VOLUMEN_MOVILIZADO = 0;
                    guardar.SALDO = 0;
                    guardar.RegEstado = 1;
                }

                listaInsertar.Add(guardar);
            }

            ListResult result = GrabarBExtraccionMaderable(listaInsertar, asCodUCuenta);

            return listaInsertar.Count();
        }

        public int ObtenerUltimoCodigoSecuencialDeLasFechasDelBalanceExtraccion(string codTHabilitante, int numPOA)
        {
            var result = ListarBExtraccionPorPlan(codTHabilitante, numPOA);
            result = result.OrderBy(x => x.COD_SECUENCIAL).Reverse().ToList();
            return result.FirstOrDefault().COD_SECUENCIAL;
        }
    }
}
