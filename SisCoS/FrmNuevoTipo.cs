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
    public partial class FrmNuevoTipo : Form
    {
        MySqlConnection cn;
        public FrmNuevoTipo()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void limpiarControls()
        {
            txtDesc.Text = "";
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmNuevoTipo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text != "")
            {
                try
                {

                    MySqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_guardartiposervicio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_descr", MySqlDbType.VarChar, 50).Value = txtDesc.Text;

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
                    MessageBox.Show("Tipo de Servicio Registrado","ATIPANA");
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
    }
}
