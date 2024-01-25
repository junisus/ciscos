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
    public partial class FrmMaquinaria : Form
    {
        SqlConnection cn;
        public FrmMaquinaria()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmMaquinaria_Load(object sender, EventArgs e)
        {
            cargarMarca();
            cargaModelo();
        }


        private void limpiarControls()
        {
            txtDesc.Text = "";
            txtPlaca.Text = "";
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void cargarMarca()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbMarca";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbMar.DataSource = dta;
                cmbMar.DisplayMember = "Descripcion";
                cmbMar.ValueMember = "idMarca";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void cargaModelo()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbModelo";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbMod.DataSource = dta;
                cmbMod.DisplayMember = "Descripcion";
                cmbMod.ValueMember = "idModelo";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text != "")
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_guardarMaquinaria";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@descr", SqlDbType.VarChar, 50).Value = txtDesc.Text;
                    cmd.Parameters.Add("@placa", SqlDbType.Char, 6).Value = txtPlaca.Text;
                    cmd.Parameters.Add("@idMarca", SqlDbType.Char, 5).Value = cmbMar.SelectedValue.ToString();
                    cmd.Parameters.Add("@idModelo", SqlDbType.Char, 5).Value = cmbMod.SelectedValue.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
