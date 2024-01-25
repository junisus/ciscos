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
    public partial class FrmProducto : Form
    {
        SqlConnection cn;
        public FrmProducto()
        {
            InitializeComponent();
             //cn = FrmPrincipal.cn;
             txtDesc.Select();
             txtDesc.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void limpiarControls()
        {
            txtDesc.Text = "";
            txtStock.Text = "";
            txtStockMin.Text = "";
            txtPrecioC.Text = "";
            txtPrecioV.Text = "";
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text != "")
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_guardarProducto";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@descr", SqlDbType.VarChar, 50).Value = txtDesc.Text;
                    cmd.Parameters.Add("@cat", SqlDbType.Char, 5).Value = cmbCat.SelectedValue.ToString();
                    cmd.Parameters.Add("@stock", SqlDbType.Int).Value = txtStock.Text;
                    cmd.Parameters.Add("@stockMin", SqlDbType.Int).Value = txtStockMin.Text;
                    cmd.Parameters.Add("@precioC", SqlDbType.Decimal).Value = txtPrecioC.Text;
                    cmd.Parameters.Add("@precioV", SqlDbType.Decimal).Value = txtPrecioV.Text;
                    cmd.Parameters.Add("@idMed", SqlDbType.Char, 5).Value = cmbMed.SelectedValue.ToString();
                    cmd.Parameters.Add("@idMar", SqlDbType.Char, 5).Value = cmbMarca.SelectedValue.ToString();
                    cmd.Parameters.Add("@idPro", SqlDbType.Char, 5).Value = cmbPro.SelectedValue.ToString();

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

        private void cargarCategorias()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbCategoria";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbCat.DataSource = dta;
                cmbCat.DisplayMember = "Descripcion";
                cmbCat.ValueMember = "idCategoria";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarMedida()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbMedida";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbMed.DataSource = dta;
                cmbMed.DisplayMember = "Descripcion";
                cmbMed.ValueMember = "idMedida";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                cmbMarca.DataSource = dta;
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "idMarca";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void cargarProcedencia()
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_CmbProcedencia";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                cmbPro.DataSource = dta;
                cmbPro.DisplayMember = "Descripcion";
                cmbPro.ValueMember = "idProcedencia";

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message, "Sistema de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            cargarCategorias();
            cargarMedida();
            cargarMarca();
            cargarProcedencia();
        }
    }
}
