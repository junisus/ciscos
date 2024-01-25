using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisCoS
{
    public class Concepto
    {
        public string Descripcion { get; set; }
        public string Tarifa { get; set; }
        public string Monto { get; set; }
        
        public List<Concepto> GetConcepto(String idCot)
        {
            string connStr = "server=localhost;user=root;database=filesystem;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            List<Concepto> conceptos = new List<Concepto>();

            try
            {
                conn.Open(); 
                MySqlCommand cmd = new MySqlCommand("CALL GetServicio(@idCotizacion);", conn);
                cmd.Parameters.AddWithValue("@idCotizacion", idCot);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["TipoServicio"].ToString() == "Concepto")
                    {
                        Concepto c = new Concepto();
                        c.Descripcion = rdr["descripcion"].ToString();
                        c.Tarifa = rdr["tarifa"].ToString();
                        c.Monto = rdr["subtotal"].ToString();
                        conceptos.Add(c);
                    }
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

            return conceptos;
        }
        
    }
}
