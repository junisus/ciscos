using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace SisCoS
{
    public partial class FrmTipo : Form
    {
        SqlConnection cn;
        private string id, desc;
        public FrmTipo()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FrmTipo_Load(object sender, EventArgs e)
        {
            getModelo();
            getMarca();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtdescrip.Text != "")
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_guardarModelo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@descr", SqlDbType.VarChar, 20).Value = txtdescrip.Text;

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
                    getModelo();
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
            txtdescrip.Text = "";
            txtdescrip.Select();
            txtdescrip.Focus();
        }

        private void getModelo()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getModelo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorio.DataSource = dta;
                dr.Close();
            }
            catch (SqlException) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtdescrip.Select();
            txtdescrip.Focus();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getModelo();
            getMarca();
        }

        private void dgvDirectorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdModelo"].Value.ToString();
            txtid.Text = id;

            desc = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();
            txtdescrip.Text = desc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea modificar la fila", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarModelo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Char, 50).Value = txtid.Text;
                    cmd.Parameters.Add("@desc", SqlDbType.VarChar, 20).Value = txtdescrip.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Datos Actualizados", "SisCoS");
                    getModelo();
                    txtid.Text = "";
                    txtdescrip.Text = "";
                }


                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtdescMarca.Select();
            txtdescMarca.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtdescMarca.Text != "")
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_guardarMarca";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@descr", SqlDbType.VarChar, 50).Value = txtdescMarca.Text;

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
                    getMarca();
                }
                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Los campos con * son obligatorios", "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void getMarca()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getMarca";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desc", txtBMarcas.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvMarca.DataSource = dta;
                dr.Close();
            }
            catch (SqlException) { }
        }

        private void txtBMarcas_TextChanged(object sender, EventArgs e)
        {
            getMarca();
        }

        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvMarca.Rows[e.RowIndex].Cells["clmMarca"].Value.ToString();
            txtidMarca.Text = id;

            desc = dgvMarca.Rows[e.RowIndex].Cells["clmDescripcionM"].Value.ToString();
            txtdescMarca.Text = desc;
        }

        private void dgvMarca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar la fila", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarMarcaEstado";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Char, 5).Value = txtidMarca.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Eliminado");
                    getMarca();
                    txtid.Text = "";
                    txtdescrip.Text = "";

                }


                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea modificar la fila", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarMarca";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Char, 50).Value = txtidMarca.Text;
                    cmd.Parameters.Add("@desc", SqlDbType.VarChar, 20).Value = txtdescMarca.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Datos modificados", "SisCoS");
                    getModelo();
                    txtid.Text = "";
                    txtdescrip.Text = "";
                }


                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar la fila", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "sp_modificarModeloEstado";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Char, 5).Value = txtid.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    MessageBox.Show("Datos Eliminador", "SisCoS");
                    getMarca();
                    txtid.Text = "";
                    txtdescrip.Text = "";

                }


                catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
