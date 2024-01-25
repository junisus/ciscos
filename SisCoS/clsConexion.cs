using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;

namespace SisCoS
{
    public class clsConexion
    {
        private MySqlConnection guardaconexion;
        public MySqlConnection cn;

        public clsConexion()
        {
            guardaconexion = new MySqlConnection();
        }
        public MySqlConnection ConectarBD()
        {
            try
            {
                guardaconexion.ConnectionString = "server= localhost ;database=filesystem;User ID=root;Password='';";

                //guardaconexion.ConnectionString = "Data Source=LAPTOP-J7BFIHO3;Initial Catalog=MRTECHSOLUTIONS;Integrated Security=True";//User ID=sa;Password=sql123456";
                //guardaconexion.ConnectionString = "Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=srgato_MRTECHSOLUTIONS;User ID=srgato_MRTECHSOLUTIONS;Password=serolf9121";
                guardaconexion.Open();
                return guardaconexion;
            }

            catch (MySqlException)
            {
                return null;
            }
        }
    }
}
