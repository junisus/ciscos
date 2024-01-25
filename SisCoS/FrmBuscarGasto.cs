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
    public partial class FrmBuscarGasto : Form
    {
        private MySqlConnection cn;
        public string id, desc, stock, pc, pv;

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //FrmCotizacion.id5 = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProducto"].Value.ToString();
            //FrmCotizacion.np5 = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();

            //FrmCotizacion.tarifa = dgvDirectorio.Rows[e.RowIndex].Cells["clmStock"].Value.ToString();

            //FrmCotizacion.pv5 = dgvDirectorio.Rows[e.RowIndex].Cells["clmPrecioV"].Value.ToString();


            //OrdenServicio.idpro = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProducto"].Value.ToString();
            //OrdenServicio.nombpro = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();
            //OrdenServicio.precioventa = dgvDirectorio.Rows[e.RowIndex].Cells["clmPrecioV"].Value.ToString();


            FrmCotizacion2.id5 = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProducto"].Value.ToString();
            FrmCotizacion2.np5 = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();

            this.Dispose();
            this.Close();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            getGasto();
        }

        public FrmBuscarGasto()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void FrmBuscarGasto_Load(object sender, EventArgs e)
        {
            getGasto();
        }

        private void getGasto()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getGasto";
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
    }
}
