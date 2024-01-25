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
    public partial class FrmBuscarServicioT : Form
    {
        private MySqlConnection cn;
        public string id1, desc1, stock1, pc1, pv1;

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvDirectorio2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            FrmCotizacion.id1 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmIdProductos"].Value.ToString();
            FrmCotizacion.np1 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmDescripcions"].Value.ToString()
            FrmCotizacion.t1 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmStocks"].Value.ToString();
            */

            FrmCotizacion2.id1 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmIdProductos"].Value.ToString();
            FrmCotizacion2.np1 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmDescripcions"].Value.ToString();
            FrmCotizacion2.t1 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmStocks"].Value.ToString();

            //  FrmCotizacion.pv1 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmPrecioVs"].Value.ToString();


            OrdenServicio.idpro = dgvDirectorio2.Rows[e.RowIndex].Cells["clmIdProductos"].Value.ToString();
            OrdenServicio.nombpro = dgvDirectorio2.Rows[e.RowIndex].Cells["clmDescripcions"].Value.ToString();
           // OrdenServicio.precioventa = dgvDirectorio2.Rows[e.RowIndex].Cells["clmPrecioVs"].Value.ToString();
            this.Dispose();
            this.Close();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getServicioT();
        }

        public FrmBuscarServicioT()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorio2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmBuscarServicioT_Load(object sender, EventArgs e)
        {
            getServicioT();
        }

        private void getServicioT()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getServicioGastoN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_desc", txtDesc.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorio2.DataSource = dta;
                dr.Close();
            }
            catch (MySqlException) { }
        }
    }
}
