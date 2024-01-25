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
    public partial class FrmNuevoUsuario : Form
    {
        MySqlConnection cn;
        public FrmNuevoUsuario()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
        }




        private void limpiarControls()
        {
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtNombre.Text = "";
            txtUsuario.Select();
            txtUsuario.Focus();
            txtcelular.Text = "";
            txtDireccion.Text = "";
            txtDNI.Text = "";
            

        }

        

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtPass.Text != "" && txtNombre.Text != "")
            {
                try
                {

                    MySqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_guardarUsuario";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_usuario", MySqlDbType.VarChar, 20).Value = txtUsuario.Text;
                    cmd.Parameters.Add("_pass", MySqlDbType.VarChar, 20).Value = txtPass.Text;
                    cmd.Parameters.Add("_nombre", MySqlDbType.VarChar, 150).Value = txtNombre.Text;
                    cmd.Parameters.Add("_direccion", MySqlDbType.VarChar, 50).Value = txtDireccion.Text;
                    cmd.Parameters.Add("_DNI", MySqlDbType.VarChar, 150).Value = txtDNI.Text;
                    cmd.Parameters.Add("_celular", MySqlDbType.VarChar, 150).Value = txtcelular.Text;
                   // cmd.Parameters.Add("_tipo", MySqlDbType.VarChar, 150).Value = cmbMed.SelectedItem.ToString();

                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr.GetString(1).ToString().CompareTo("exito") == 0)
                        {
                            MessageBox.Show(dr.GetString(0), "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiarControls();
                        }
                        else
                        {
                            MessageBox.Show(dr.GetString(0), "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    dr.Close();
                    MessageBox.Show("Datos del usuario registrado", "ATIPANA");
                    limpiarControls();
                }
                catch (MySqlException ex) { MessageBox.Show(ex.Message, "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Los campos con * son obligatorios", "ATIPANA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void FrmNuevoUsuario_Load(object sender, EventArgs e)
        {
            cmbMed.Items.Add("Administrador");
            cmbMed.Items.Add("Usuario");
        }


    }
}
