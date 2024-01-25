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
    public partial class FrmBuscarCotizacion : Form
    {
        private SqlConnection cn;
        public FrmBuscarCotizacion()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmBuscarCotizacion_Load(object sender, EventArgs e)
        {
            getCotizar();
        }

        private void getCotizar()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getCotizacion";
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
            getCotizar();
        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           FrmContrato.id = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdCotizacion"].Value.ToString();


            FrmContrato.nom = dgvDirectorio.Rows[e.RowIndex].Cells["clmCliente"].Value.ToString();

            this.Dispose();
            this.Close();
        }
    }
}
