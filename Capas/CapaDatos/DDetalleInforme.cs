using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;


namespace CapaDatos
{
   public class DDetalleInforme
    {
       public Int32 InsertarDetalleinforme(SqlConnection cn, EDetalleInforme oCampo)
       {
           try
           {
               using (SqlCommand cmd = new SqlCommand("TEM_sp_insertardetalle_informe", cn))
               {
                   Int32 NumReg;
                   cmd.CommandType = CommandType.StoredProcedure;


                   SqlParameter part1 = cmd.Parameters.Add("@id_informe_supervision", SqlDbType.Char, 40);
                   part1.Direction = ParameterDirection.Input;
                   part1.Value = oCampo.id_informe_supervision;

                   SqlParameter part2 = cmd.Parameters.Add("@descripcion", SqlDbType.Text);
                   part2.Direction = ParameterDirection.Input;
                   part2.Value = oCampo.descripcion;

                   SqlParameter part6 = cmd.Parameters.Add("@idcategoria", SqlDbType.Int);
                   part6.Direction = ParameterDirection.Input;
                   part6.Value = oCampo.idcategoria;

                   SqlParameter part3 = cmd.Parameters.Add("@idsubcategoria", SqlDbType.Int);
                   part3.Direction = ParameterDirection.Input;
                   part3.Value = oCampo.idsubcategoria;

                   SqlParameter part4 = cmd.Parameters.Add("@iddetsubcategoria", SqlDbType.Int);
                   part4.Direction = ParameterDirection.Input;
                   part4.Value = oCampo.iddetsubcategoria;

                   SqlParameter part5 = cmd.Parameters.Add("@iddetsectorsubcategoria", SqlDbType.Int);
                   part5.Direction = ParameterDirection.Input;
                   part5.Value = oCampo.iddetsectorsubcategoria;

          
                  

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
