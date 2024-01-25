using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace SisCoS
{
    public class ClaseAyuda
    {
        private String cadenaConexion = "server= localhost ;database=filesystem;User ID=root;Password='';";
        //private String cadenaConexion = "Data Source=LAPTOP-4I02ICLR; Initial Catalog=examen2; Integrated Security=true";
        private MySqlDataAdapter da;

        public DataSet buscarArticulo(String descripcion)
        {
            DataSet ds = new DataSet();
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = cadenaConexion;
            cn.Open();
            da = new MySqlDataAdapter("SP_BuscarArticulo", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("_descripcion", descripcion);
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet buscarArticuloq(String descripcion)
        {
            DataSet ds = new DataSet();
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = cadenaConexion;
            cn.Open();
            da = new MySqlDataAdapter("SP_BuscarArticuloq", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("_desc", descripcion);
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet buscarArticulow(String descripcion)
        {
            DataSet ds = new DataSet();
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = cadenaConexion;
            cn.Open();
            da = new MySqlDataAdapter("SP_BuscarArticulow", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("_desc", descripcion);
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet buscarArticulot(String descripcion)
        {
            DataSet ds = new DataSet();
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server= localhost ;database=filesystem;User ID=root;Password='';";
            cn.Open();
            da = new MySqlDataAdapter("SP_BuscarArticulot", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("_desc", descripcion);
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
