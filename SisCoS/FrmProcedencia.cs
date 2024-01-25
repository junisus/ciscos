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
    public partial class FrmProcedencia : Form
    {
        private SqlConnection cn;
        private string id, desc;
        public FrmProcedencia()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmProcedencia_Load(object sender, EventArgs e)
        {
            getProcedencia();
        }

        private void getProcedencia()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getProcedencia";
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

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getProcedencia();
        }

        private void dgvDirectorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProcedencia"].Value.ToString();
            txtid.Text = id;

            desc = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();
            txtdescrip.Text = desc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_modificarProcedencia";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Char, 5).Value = txtid.Text;
                cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = txtdescrip.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
                MessageBox.Show("Datos Actualizados");
                getProcedencia();
                txtid.Text = "";
                txtdescrip.Text = "";
            }


            catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
             
        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_modificarProcedenciaEstado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Char, 5).Value = txtid.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
                MessageBox.Show("Eliminado");
                getProcedencia();
                txtid.Text = "";
                txtdescrip.Text = "";

            }


            catch (SqlException ex) { MessageBox.Show(ex.Message, "SisCoS", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

    }
}
