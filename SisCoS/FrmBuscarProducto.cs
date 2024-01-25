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
    public partial class FrmBuscarProducto : Form
    {
        private MySqlConnection cn;
        public string id5, desc5, stock, pc, pv;
        public FrmBuscarProducto()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmBuscarProducto_Load(object sender, EventArgs e)
        {
            getProducto();
        }

        private void getProducto()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getProductos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_desc", txtDesc.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorio.DataSource = dta;
                dr.Close();
            }
            catch (MySqlException) { }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getProducto();
        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            FrmCotizacion.id6 = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProducto"].Value.ToString();
            

            FrmCotizacion.np6 = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();
            */

            FrmCotizacion2.id6 = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProducto"].Value.ToString();
            FrmCotizacion2.np6 = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();


            //FrmCotizacion.stock = dgvDirectorio.Rows[e.RowIndex].Cells["clmStock"].Value.ToString();


            //FrmCotizacion.precioventa = dgvDirectorio.Rows[e.RowIndex].Cells["clmPrecioV"].Value.ToString();
            this.Dispose();
            this.Close();
        }
    }
}
