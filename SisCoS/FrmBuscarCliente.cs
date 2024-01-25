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
    public partial class FrmBuscarCliente : Form
    {
        private MySqlConnection cn;
        public string id, nom, ofi;
        public FrmCotizacion frmc = new FrmCotizacion();
        public FrmBuscarCliente()
        {
            InitializeComponent();
            cn = FrmPrincipal.cn;
           dgvDirectorioC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            getCliente();
            txtCliente.Select();
            txtCliente.Focus();
        }

        private void getCliente()
        {

            try
            {
                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "sp_BuscarCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_idCliente", txtCliente.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(dr);
                dgvDirectorioC.DataSource = dta;
                dr.Close();
            }
            catch (MySqlException) { }
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            getCliente();
        }

        

        private void dgvDirectorioC_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //FrmCotizacion.id = dgvDirectorioC.Rows[e.RowIndex].Cells[0].Value.ToString();
            //FrmCotizacion.nom = dgvDirectorioC.Rows[e.RowIndex].Cells[1].Value.ToString();
            //FrmCotizacion.ofi = dgvDirectorioC.Rows[e.RowIndex].Cells[2].Value.ToString();

            FrmCotizacion2.id = dgvDirectorioC.Rows[e.RowIndex].Cells[0].Value.ToString();
            FrmCotizacion2.nom = dgvDirectorioC.Rows[e.RowIndex].Cells[1].Value.ToString();
            FrmCotizacion2.ofi = dgvDirectorioC.Rows[e.RowIndex].Cells[2].Value.ToString();



            this.Dispose();
            this.Close();
        }

       

        
    }
}
