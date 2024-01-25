using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SisCoS
{
    public partial class FrmAsistenciaP : Form
    {
        AutoCompleteStringCollection data;
        public MySqlConnection cn;
        public FrmAsistenciaP()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "ChecadorTrabajadores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id", txtDNI.Text);
                cmd.Parameters.AddWithValue("p_hora1", DateTime.Now.ToShortTimeString());
                cmd.Parameters.AddWithValue("p_desc", comboBoxEx1.SelectedItem);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
                MessageBox.Show("Registrado Asistencia", "ATIPANA");
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            textBoxX1.Clear();
            txtDNI.Clear();
            Clean();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void FrmAsistenciaP_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();

            data = new AutoCompleteStringCollection();
            autocompletar();
            txtDNI.AutoCompleteCustomSource = data;
        }

        private void autocompletar()
        {
            try
            {
                // string doc = txtDNI.Text.Replace(" ", "");
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getAdministrador1";
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(dr.GetString(0).ToString());
                }
                dr.Close();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, "Rey de Copas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Buscar()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_BuscarPorDNI";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_DNI", txtDNI.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    textBoxX1.Text = dr["USU_nombres"].ToString();
                    // label4.Text = dr["USU_Apellidos"].ToString();
                }
                dr.Close();
                /*MessageBox.Show("Exito");*/
            }
            catch (MySqlException) { }
        }

        public void Clean()
        {
            txtDNI.Text = "";
            textBoxX1.Text = "";
            //labelX2.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void txtDNI_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar();
                //Buscar2();

            }
        }
    }


}
