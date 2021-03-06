﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SPV.BE
{
    public class NotaIngreso
    {
        string strSql;
        string strCadenaConexion;

        public NotaIngreso()
        {
            SPV.BE.DA_GENERAL Cadena = new SPV.BE.DA_GENERAL();
            strCadenaConexion = Cadena.ObtenerCadena();
        }

        public int ObtenerCorrelativoNotaIngreso()
        {
            SqlConnection cn = new SqlConnection(strCadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_sel_CorrelativoNotaIngreso", cn);

            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            int codigo = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return codigo;
        }


        public void RegistraNotaIngreso(int CodNotaIngreso, string CodGuiaRemision, string Fecha)
        {
            SqlConnection cn = new SqlConnection(strCadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_ins_NotaIngreso", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CodNotaIngreso", SqlDbType.Int).Value = CodNotaIngreso;
            cmd.Parameters.Add("@CodGuiaRemision", SqlDbType.VarChar).Value = CodGuiaRemision;
            cmd.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Fecha;
  
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void RegistraDetalleNotaIngreso(int CodNotaIngreso, int CodProducto, int Cantidad)
        {
            SqlConnection cn = new SqlConnection(strCadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_ins_DetalleNotaIngreso", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CodNotaIngreso", SqlDbType.Int).Value = CodNotaIngreso;
            cmd.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public DataTable ListaNotaIngresoCodigoOC(int CodigoOC)
        {

            strSql = "usp_sel_NotaIngresoCodigoOC";

            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(strCadenaConexion))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@CodigoOC", SqlDbType.Int).Value = CodigoOC;

                        sqlCmd.ExecuteNonQuery();

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        da.SelectCommand = sqlCmd;
                        da.Fill(ds);
                        dt = ds.Tables[0];
                        sqlCnx.Close();

                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public DataTable ListaNotaIngreso(int NotaIngreso)
        {

            strSql = "usp_sel_ListaNotaIngreso";

            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(strCadenaConexion))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@NotaIngreso", SqlDbType.Int).Value = NotaIngreso;

                        sqlCmd.ExecuteNonQuery();

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        da.SelectCommand = sqlCmd;
                        da.Fill(ds);
                        dt = ds.Tables[0];
                        sqlCnx.Close();

                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public DataTable ListaDetalleNotaIngreso(int NotaIngreso)
        {

            strSql = "usp_sel_DetalleNotaIngreso";

            try
            {
                using (SqlConnection sqlCnx = new SqlConnection(strCadenaConexion))
                {
                    sqlCnx.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnx))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@NotaIngreso", SqlDbType.Int).Value = NotaIngreso;

                        sqlCmd.ExecuteNonQuery();

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataTable dt = new DataTable();
                        da.SelectCommand = sqlCmd;
                        da.Fill(ds);
                        dt = ds.Tables[0];
                        sqlCnx.Close();

                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }




    }


}
