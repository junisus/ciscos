using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisCoS
{
    public class DepositoTemporal
    {
        public string Descripcion { get; set; }
        public string Tarifa { get; set; }
        public string Monto { get; set; }

        public List<DepositoTemporal> GetDepositoTemporal(String idCot)
        {
            string connStr = "server=localhost;user=root;database=filesystem;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            List<DepositoTemporal> depositos = new List<DepositoTemporal>();

            try
            {
                conn.Open(); 
                MySqlCommand cmd = new MySqlCommand("CALL GetServicio(@idCotizacion);", conn);
                cmd.Parameters.AddWithValue("@idCotizacion", idCot);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["TipoServicio"].ToString() == "Deposito Temporal o Almacen")
                    {
                        DepositoTemporal c = new DepositoTemporal();
                        c.Descripcion = rdr["descripcion"].ToString();
                        c.Tarifa = rdr["tarifa"].ToString();
                        c.Monto = rdr["subtotal"].ToString();
                        depositos.Add(c);
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

            return depositos;
        }
    }
}
