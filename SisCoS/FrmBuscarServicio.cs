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
    public partial class FrmBuscarServicio : Form
    {
        private MySqlConnection cn;
        public string id, desc, stock, pc, pv;
        public FrmBuscarServicio()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
            dgvDirectorio.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDesc.Select();
            txtDesc.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           //getServicio();
        }

        private void getServicio()
        {
            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_getServicioConcepto";
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
            getServicio();
        }

        private void dgvDirectorio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*FrmCotizacion.idpro = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProducto"].Value.ToString();


            FrmCotizacion.nombpro = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();

            FrmCotizacion.tarifa = dgvDirectorio.Rows[e.RowIndex].Cells["clmStock"].Value.ToString();*/



            // FrmCotizacion.precioventa = dgvDirectorio.Rows[e.RowIndex].Cells["clmPrecioV"].Value.ToString();


            FrmCotizacion2.idpro = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProducto"].Value.ToString();
            FrmCotizacion2.nombpro = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();
            FrmCotizacion2.tarifa = dgvDirectorio.Rows[e.RowIndex].Cells["clmStock"].Value.ToString();

            OrdenServicio.idpro = dgvDirectorio.Rows[e.RowIndex].Cells["clmIdProducto"].Value.ToString();
            OrdenServicio.nombpro = dgvDirectorio.Rows[e.RowIndex].Cells["clmDescripcion"].Value.ToString();
            //OrdenServicio.precioventa = dgvDirectorio.Rows[e.RowIndex].Cells["clmPrecioV"].Value.ToString();
            this.Dispose();
            this.Close();
        }

        private void FrmBuscarServicio_Load(object sender, EventArgs e)
        {
            getServicio();
        }
    }
}
