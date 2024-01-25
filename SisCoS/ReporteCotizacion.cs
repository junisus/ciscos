using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisCoS
{
    public class ReporteCotizacion
    {
        public string IdCotizacion { get; set; }
        public string Fecha { get; set; }
        public string NombreCl { get; set; }
        public string DireccionCl { get; set; }
        public string RucCl { get; set; }
        public string TelefonoCl { get; set; }

        public List<ReporteCotizacion> GetReporte(String idCot)
        {
            string connStr = "server=localhost;user=root;database=filesystem;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            List<ReporteCotizacion> reportes = new List<ReporteCotizacion>();

            try
            {
                conn.Open(); 
                MySqlCommand cmd = new MySqlCommand("CALL GetCliente(@idCotizacion);", conn);
                cmd.Parameters.AddWithValue("@idCotizacion", idCot);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ReporteCotizacion c = new ReporteCotizacion();
                    c.IdCotizacion = rdr["idCotizacion"].ToString();
                    c.Fecha = rdr["fecha"].ToString();
                    c.NombreCl = rdr["nombre"].ToString();
                    c.RucCl = rdr["ruc"].ToString();
                    c.DireccionCl = rdr["direccion"].ToString();
                    c.TelefonoCl = rdr["telefono"].ToString();
                    reportes.Add(c);
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

            return reportes;
        }
    }
}

