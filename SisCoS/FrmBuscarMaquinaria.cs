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
    public partial class FrmBuscarMaquinaria : Form
    {
        private SqlConnection cn;
        private string id, desc, placa;
        public FrmBuscarMaquinaria()
        {
            InitializeComponent();
            //cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmBuscarMaquinaria_Load(object sender, EventArgs e)
        {
            getMaquinaria();
        }

        private void getMaquinaria()
        {
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_BuscarMaquinaria";
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
            getMaquinaria();
        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmCotizacion.idMaquinaria= dgvDirectorio.Rows[e.RowIndex].Cells[0].Value.ToString();

            FrmCotizacion.descm = dgvDirectorio.Rows[e.RowIndex].Cells[1].Value.ToString();

           OrdenServicio.idMaquinaria = dgvDirectorio.Rows[e.RowIndex].Cells[0].Value.ToString();

           OrdenServicio.descm = dgvDirectorio.Rows[e.RowIndex].Cells[1].Value.ToString();


            

            this.Dispose();
            this.Close();
        }
    }
}
