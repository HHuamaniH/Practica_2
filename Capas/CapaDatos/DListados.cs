using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;


namespace CapaDatos
{
    public class DListados
    {
        public List<EDetalleInforme> ListarDetalleInforme(SqlConnection cn, EDetalleInforme oCampo)
       {
           try
           {
                ///sdsd
               List<EDetalleInforme> ListObj = new List<EDetalleInforme>();
               using (SqlCommand cmd = new SqlCommand("TEM_sp_listarDetalleInforme", cn))
               {

                   cmd.CommandType = CommandType.StoredProcedure;
                   SqlParameter part1 = cmd.Parameters.Add("@id_informe_supervision", SqlDbType.Char,40);
                   part1.Direction = ParameterDirection.Input;
                   part1.Value = oCampo.id_informe_supervision;

                   SqlParameter part2 = cmd.Parameters.Add("@idcategoria", SqlDbType.Int);
                   part2.Direction = ParameterDirection.Input;
                   part2.Value = oCampo.idcategoria;


                   SqlParameter part3 = cmd.Parameters.Add("@idsubcategoria", SqlDbType.Int);
                   part3.Direction = ParameterDirection.Input;
                   part3.Value = oCampo.idsubcategoria;


                   

                   cmd.CommandType = CommandType.StoredProcedure;
                   SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                   if (drd != null)
                   {
                       if (drd.HasRows)
                       {
                           
                           int p1 = drd.GetOrdinal("descripcion");

                           EDetalleInforme oCampo2;
                           while (drd.Read())
                           {
                               oCampo2 = new EDetalleInforme();
                               oCampo2.descripcion = drd.GetString(p1);
                                
                               ListObj.Add(oCampo2);
                           }
                       }
                   }
               }
               return ListObj;

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

        public Int32 ModificarDetalleinforme(SqlConnection cn, EDetalleInforme oCampo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("TEM_sp_modificardetalle_informe", cn))
                {
                    Int32 NumReg;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter part1 = cmd.Parameters.Add("@descripcion", SqlDbType.Text);
                    part1.Direction = ParameterDirection.Input;
                    part1.Value = oCampo.descripcion;

                    SqlParameter part2 = cmd.Parameters.Add("@iddetinforme", SqlDbType.Int);
                    part2.Direction = ParameterDirection.Input;
                    part2.Value = oCampo.iddetinforme;



                    NumReg = cmd.ExecuteNonQuery();

                    if (NumReg <= 0)
                    {
                        return -1;
                    }
                    return NumReg;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
