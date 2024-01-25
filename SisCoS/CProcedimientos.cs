using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace SisCoS
{
    public class CProcedimientos
    {
        public MySqlConnection cn;
        private MySqlDataAdapter da;


        public DataTable cargarDatos(string data)
        {
            DataTable dt = new DataTable();
            cn = FrmPrincipal.cn;


            MySqlCommand cmdd = cn.CreateCommand();
            cmdd.CommandText = "sr_cargardata";
            cmdd.CommandType = CommandType.StoredProcedure;


            MySqlDataReader drd = cmdd.ExecuteReader();
            dt.Load(drd);
            cn.Close();
            return dt;


        }
        public string GenerarCodigo(string data)
        {

            cn = FrmPrincipal.cn;
            string codigo = string.Empty;
            int total = 0;

            MySqlCommand cmdd = cn.CreateCommand();
            cmdd.CommandText = "sp_generarCodigo";
            cmdd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader drd = cmdd.ExecuteReader();

            if (drd.Read())
            {
                total = Convert.ToInt32(drd["totalRegistros"]) + 1;
            }
            drd.Close();

            if (total < 10)
            {
                codigo = "00000" + total;
            }
            else if (total < 100)
            {
                codigo = "0000" + total;
            }
            else if (total < 1000)
            {
                codigo = "000" + total;
            }
            else if (total < 100000)
            {
                codigo = "00" + total;
            }
            else if (total < 1000000)
            {
                codigo = "0" + total;
            }

            return codigo;
        }

       
    }
}

