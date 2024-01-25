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
    public partial class FrmBuscarServicioJ : Form
    {
        private MySqlConnection cn;
        public string id4, desc4, stock4, pc4, pv4;

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getServicioJ();
        }

        private void dgvDirectorio2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            FrmCotizacion.id4 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmIdProductos"].Value.ToString();


            FrmCotizacion.np4 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmDescripcions"].Value.ToString();

            FrmCotizacion.t4 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmStocks"].Value.ToString();
            */

            FrmCotizacion2.id4 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmIdProductos"].Value.ToString();
            FrmCotizacion2.np4 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmDescripcions"].Value.ToString();
            FrmCotizacion2.t4 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmStocks"].Value.ToString();

            // FrmCotizacion.pv4 = dgvDirectorio2.Rows[e.RowIndex].Cells["clmPrecioVs"].Value.ToString();


            OrdenServicio.idpro = dgvDirectorio2.Rows[e.RowIndex].Cells["clmIdProductos"].Value.ToString();
            OrdenServicio.nombpro = dgvDirectorio2.Rows[e.RowIndex].Cells["clmDescripcions"].Value.ToString();
         //   OrdenServicio.precioventa = dgvDirectorio2.Rows[e.RowIndex].Cells["clmPrecioVs"].Value.ToString();
            this.Dispose();
            this.Close();
        }

        public FrmBuscarServicioJ()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorio2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmBuscarServicioJ_Load(object sender, EventArgs e)
        {
            getServicioJ();
        }

        private void getServicioJ()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getServicioDerecho";
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
