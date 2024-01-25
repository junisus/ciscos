using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SisCoS
{
    public partial class FrmBackup : Form
    {
        public FrmBackup()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["cadena"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);


                SqlCommand cmd = new SqlCommand("backupdb", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cnn.Open();

                cmd.ExecuteNonQuery();


                MessageBox.Show("El backup fue realizado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
