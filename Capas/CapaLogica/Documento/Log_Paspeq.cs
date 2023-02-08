//using CapaDatos.DOC;
//using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using CDatos = CapaDatos.DOC.Dat_Paspeq;
//using CEntidad = CapaEntidad.DOC.Ent_Paspeq;
//using CEntidad2 = CapaEntidad.DOC.Ent_Paspeq_Detalle;

namespace CapaLogica.DOC
{
    public class Log_Paspeq
    {
        //private CDatos oCDatos = new CDatos();

        //public List<VM_PaspeqDetalle> AjustePaspeq(List<VM_PaspeqDetalle> listaPaspeq, Ent_Paspeq idPaspeq)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.AjustarPaspeq(cn, listaPaspeq, idPaspeq);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<VM_PaspeqDetalle> GetAllPaspeq(VM_PaspeqDetalle vm)
        //{
        //    Ent_Paspeq ent = new Ent_Paspeq();
        //    ent.NUM_PASPEQ = vm.num_paspeq;
        //    ent.PERIODO = vm.periodo;
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.ListaPaspeq(cn, ent);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public VM_Paspeq PaspeqSeleccion(int numPaspeq = 0, string periodo = "")
        {
            VM_Paspeq vm;
            vm = new VM_Paspeq();
            vm.num_paspeq = numPaspeq;
            vm.periodo = periodo;
            return vm;
        }

        //public bool SeleccionarPaspeq(VM_PaspeqDetalle vm)
        //{
        //    Ent_Paspeq ent = new Ent_Paspeq();
        //    ent.NUM_PASPEQ = vm.num_paspeq;
        //    ent.PERIODO = vm.periodo;
        //    try
        //    {
        //        return oCDatos.SeleccionarPaspeq(ent);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool EliminarPaspeq(VM_PaspeqDetalle vm)
        //{
        //    Ent_Paspeq ent = new Ent_Paspeq();
        //    ent.NUM_PASPEQ = vm.num_paspeq;
        //    ent.PERIODO = vm.periodo;
        //    try
        //    {
        //        return oCDatos.EliminarPaspeq(ent);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CEntidad2> ReportePaspeq(int num_paspeq, string periodo)
        //{
        //    CEntidad oCEntidad = new CEntidad();
        //    oCEntidad.NUM_PASPEQ = num_paspeq;
        //    oCEntidad.PERIODO = periodo;

        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.DatosReportePaspeq(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public ListResult CreatePaspeq()
        //{
        //    ListResult result = new ListResult();
        //    try
        //    {

        //        Ent_Paspeq ent = new Ent_Paspeq();
        //        ent.PERIODO = DateTime.Now.AddYears(1).Year.ToString();
        //        Dat_Paspeq dat = new Dat_Paspeq();
        //        string msj = "";
        //        if (dat.CreatePaspeq(ent))
        //        {
        //            result.success = true;
        //            msj = "El Paspeq se generó correctamente";
        //            result.msj = msj;
        //        }
        //        else
        //        {
        //            result.success = false;
        //            msj = "El Paspeq no se pudo generar";
        //            result.msj = msj;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.success = false;
        //        result.msj = ex.Message;
        //    }
        //    return result;
        //}
    }
}
