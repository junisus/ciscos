using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
using System.Threading;

namespace SisCoS
{
    public partial class FrmBuscarServicioE : Form
    {
        private MySqlConnection cn;
        public string id2, desc2, stock2, pc2, pv2;

        private void dgvDirectorio3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            FrmCotizacion.id2 = dgvDirectorio3.Rows[e.RowIndex].Cells["clmIdProductos"].Value.ToString();
            FrmCotizacion.np2 = dgvDirectorio3.Rows[e.RowIndex].Cells["clmDescripcions"].Value.ToString();
            FrmCotizacion.t2 = dgvDirectorio3.Rows[e.RowIndex].Cells["clmStocks"].Value.ToString();
            */

            FrmCotizacion2.id2 = dgvDirectorio3.Rows[e.RowIndex].Cells["clmIdProductos"].Value.ToString();
            FrmCotizacion2.np2 = dgvDirectorio3.Rows[e.RowIndex].Cells["clmDescripcions"].Value.ToString();
            FrmCotizacion2.t2 = dgvDirectorio3.Rows[e.RowIndex].Cells["clmStocks"].Value.ToString();

            //FrmCotizacion.pv2 = dgvDirectorio3.Rows[e.RowIndex].Cells["clmPrecioVs"].Value.ToString();
            this.Dispose();
            this.Close();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getServicioT();
        }

        public FrmBuscarServicioE()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorio3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmBuscarServicioE_Load(object sender, EventArgs e)
        {
            getServicioT();
        }
        private void getServicioT()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getServicioGastoD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_desc", txtDesc.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorio3.DataSource = dta;
                dr.Close();
            }
            catch (MySqlException) { }
        }
    }
}
