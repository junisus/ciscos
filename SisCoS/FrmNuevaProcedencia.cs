using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisCoS
{
    public partial class FrmNuevaProcedencia : Form
    {
        SqlConnection cn;
        public FrmNuevaProcedencia()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmNuevaProcedencia_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text != "")
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_guardarProcedencia";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@descr", SqlDbType.VarChar, 20).Value = txtDesc.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr.GetString(1).ToString().CompareTo("exito") == 0)
                        {
                            MessageBox.Show(dr.GetString(0), "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiarControls();
                        }
                        else
                        {
                            MessageBox.Show(dr.GetString(0), "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    dr.Close();
                }
                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Los campos con * son obligatorios", "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void limpiarControls()
        {
            txtDesc.Text = "";
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
