using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisCoS
{
    public class Producto
    {
        public string Descripcion { get; set; }
        public string PesoBruto { get; set; }
        public string Cantidad { get; set; }
        public string Bl { get; set; }

        public List<Producto> GetProducto(String idCot)
        {
            string connStr = "server=localhost;user=root;database=filesystem;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            List<Producto> productos = new List<Producto>();

            try
            {
                conn.Open(); 
                MySqlCommand cmd = new MySqlCommand("CALL GetProducto(@idCotizacion);", conn);
                cmd.Parameters.AddWithValue("@idCotizacion", idCot);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Producto c = new Producto();
                    c.Descripcion = rdr["descripcion"].ToString();
                    c.PesoBruto = rdr["peso"].ToString();
                    c.Cantidad = rdr["cantidad"].ToString();
                    c.Bl = rdr["bl"].ToString();
                    productos.Add(c);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Fallo al intentar llamar al sp en getConcepto(idCot): " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return productos;
        }
    }
}
