using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisCoS
{
    public partial class Form2 : Form
    {
        public static MySqlConnection cn;
        public Form2()
        {
            InitializeComponent();
            cn = (new clsConexion()).ConectarBD();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*private void button1_Click_1(object sender, EventArgs e)
        {
            
        }*/

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_verificarUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("_pass", txtPass.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.Hide();
                    FrmPrincipal frmp = new FrmPrincipal(txtUsuario.Text);

                    frmp.Show();
                }
                else
                {
                    txtUsuario.Text = "";
                    txtPass.Text = "";
                    txtUsuario.Focus();
                    MessageBox.Show("Usuario o contraseña inválidos", "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
            }
            catch (MySqlException ex)
            { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}
