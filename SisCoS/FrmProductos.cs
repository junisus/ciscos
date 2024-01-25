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
    public partial class FrmProductos : Form
    {
        MySqlConnection cn;
        public FrmProductos()
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

        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text != "")
            {
                try
                {

                    MySqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_GuardarProducto";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_descr", MySqlDbType.VarChar, 200).Value = txtDesc.Text;

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
                    MessageBox.Show("Concepto Registrado");
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
